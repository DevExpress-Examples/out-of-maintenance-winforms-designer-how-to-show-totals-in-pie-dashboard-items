using DevExpress.DashboardCommon;
using DevExpress.DashboardCommon.ViewerData;
using DevExpress.DashboardWin;
using DevExpress.DashboardWin.Native;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraCharts;
using DevExpress.XtraReports.UI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieTotalExtension
{
    public class PieTotalModule
    {
        const string customPropertyName = "PieTotalSettings";
        const string barButtonShowCaption = "Show Total";
        const string barButtonSettingsCaption = "Total Settings";
        const string ribonPageGroupName = "Custom Properties";
        IDashboardControl dashboardControl;
        DashboardDesigner dashboardDesigner
        {
            get { return dashboardControl as DashboardDesigner; }
        }
        BarCheckItem showTotalBarItem;
        BarButtonItem totalSettingsBarItem;

        #region Assigning Logic
        public void Attach(IDashboardControl dashboardControl)
        {
            Detach();
            this.dashboardControl = dashboardControl;
            this.dashboardControl.CalculateHiddenTotals = true;
            this.dashboardControl.DashboardItemControlUpdated += DashboardItemControlUpdated;
            this.dashboardControl.DashboardItemControlCreated += DashboardItemControlCreated;
            this.dashboardControl.CustomExport += CustomExport;

            if (dashboardDesigner != null)
            {
                AddButtonToRibbon();
                dashboardDesigner.DashboardItemSelected += DashboardDesigner_DashboardItemSelected;
            }
        }
        public void Detach()
        {
            if (dashboardControl == null) return;
            if (dashboardDesigner != null)
                RemoveButtonFromRibbon();
            this.dashboardControl.DashboardItemControlUpdated -= DashboardItemControlUpdated;
            this.dashboardControl.DashboardItemControlCreated -= DashboardItemControlCreated;
            this.dashboardControl.CustomExport -= CustomExport;
            if (dashboardDesigner != null)
            {
                RemoveButtonFromRibbon();
                dashboardDesigner.DashboardItemSelected -= DashboardDesigner_DashboardItemSelected;
            }
            dashboardControl = null;
        }
        #endregion

        #region Common Logic
        private void CustomExport(object sender, CustomExportEventArgs e)
        {
            foreach (var printControl in e.GetPrintableControls())
            {
                if (printControl.Value is XRChart)
                {
                    var pieItemName = printControl.Key;
                    IDashboardControl dashboardControl = (IDashboardControl)sender;
                    PieDashboardItem pieDashboardItem = dashboardControl.Dashboard.Items[pieItemName] as PieDashboardItem;
                    if (pieDashboardItem == null) return;
                    XRChart pieChart = printControl.Value as XRChart;
                    if (pieChart == null || pieChart.Diagram == null) return;
                    pieChart.Diagram.Tag = pieItemName;
                    pieChart.CustomizePieTotalLabel += (s, args) => {
                        string componentName = (s as XRChart).Diagram.Tag.ToString();
                        MultiDimensionalData data = e.GetItemData(componentName);
                        CustomizePieTotalLabel(componentName, data, args);
                    };
                    foreach (Series series in pieChart.Series)
                    {
                        (series.View as PieSeriesView).TotalLabel.Visible = true;
                    }
                }
            }
        }
        private void DashboardItemControlCreated(object sender, DashboardItemControlEventArgs e)
        {
            if (e.ChartControl != null)
            {
                PieDashboardItem pieItem = dashboardControl.Dashboard.Items[e.DashboardItemName] as PieDashboardItem;
                if (pieItem == null) return;
                e.ChartControl.CustomizePieTotalLabel += (s, args) => {
                    string componentName = (s as ChartControl).Diagram.Tag.ToString();
                    MultiDimensionalData data = dashboardControl.GetItemData(componentName);
                    CustomizePieTotalLabel(componentName, data, args);
                };
            }
        }
        private void DashboardItemControlUpdated(object sender, DashboardItemControlEventArgs e)
        {
            if (e.ChartControl != null)
            {
                PieDashboardItem pieItem = dashboardControl.Dashboard.Items[e.DashboardItemName] as PieDashboardItem;
                if (pieItem == null || e.ChartControl.Diagram == null) return;
                e.ChartControl.Diagram.Tag = e.DashboardItemName;
                PieTotalSettings settings = PieTotalSettings.FromJson(pieItem.CustomProperties.GetValue(customPropertyName));
                if(settings.Enabled)
                    foreach (Series series in e.ChartControl.Series)
                    {
                        (series.View as PieSeriesView).TotalLabel.Visible = true;
                    }
            }
        }
        void CustomizePieTotalLabel(string componentName, MultiDimensionalData data, CustomizePieTotalLabelEventArgs e)
        {
            PieTotalSettings settings = PieTotalSettings.FromJson(dashboardControl.Dashboard.Items[componentName].CustomProperties[customPropertyName]);
            string resultText = string.Empty;
            if (!string.IsNullOrEmpty(settings.Prefix))
                resultText += settings.Prefix + Environment.NewLine;



            MeasureDescriptor measure = data.GetMeasures().First();
            if (!string.IsNullOrEmpty(settings.MeasureId) ||
                data.GetMeasures().Where(m => m.ID == settings.MeasureId).Any())
                measure = data.GetMeasures().FirstOrDefault(m => m.ID == settings.MeasureId);
            if (measure != null)
            {
                AxisPoint axisPoint = e.Series.Tag as AxisPoint;
                resultText += data.GetSlice(axisPoint).GetValue(measure).DisplayText;
            }
            if (!string.IsNullOrEmpty(settings.Postfix))
                resultText += Environment.NewLine + settings.Postfix;
            e.Text = resultText;
        }
        AxisPoint EnsureInstancePoint(MultiDimensionalData data, AxisPoint axisPoint)
        {
            IEnumerable<DimensionDescriptor> axisDimensions = data.GetDimensions(axisPoint.AxisName);
            DimensionDescriptor instanceDimension = axisDimensions.FirstOrDefault(dim => dim.ID == axisPoint.Dimension.ID);
            IEnumerable<AxisPoint> points = data.GetAxisPointsByDimension(instanceDimension);
            return points.Single(p => p.Equals(axisPoint));
        }
        #endregion

        #region Designer Logic
        private void DashboardDesigner_DashboardItemSelected(object sender, DashboardItemSelectedEventArgs e)
        {
            UpdateTotalSettingsBarItem();
        }
        void UpdateTotalSettingsBarItem()
        {
            if(dashboardDesigner.SelectedDashboardItem is PieDashboardItem)
            {
                PieTotalSettings settings = PieTotalSettings.FromJson(dashboardDesigner.SelectedDashboardItem.CustomProperties[customPropertyName]);
                totalSettingsBarItem.Enabled = settings.Enabled;
            }

        }
        BarCheckItem CreateShowTotalBarItem()
        {
            BarCheckItem barItem = new BarCheckItem();
            barItem.Caption = barButtonShowCaption;
            barItem.ImageOptions.SvgImage = global::PieTotalExtension.Properties.Resources.EnablePieTotals;
            barItem.RibbonStyle = RibbonItemStyles.All;
            barItem.ItemClick += OnShowTotalsClick;
            return barItem;
        }
        private void OnShowTotalsClick(object sender, ItemClickEventArgs e)
        {
            DashboardItem dashboardItem = dashboardDesigner.SelectedDashboardItem;
            PieTotalSettings settings = PieTotalSettings.FromJson(dashboardItem.CustomProperties.GetValue(customPropertyName));
            settings.Enabled = !settings.Enabled;
            string status = settings.Enabled == true ? "enabled" : "disabled";
            CustomPropertyHistoryItem historyItem = new CustomPropertyHistoryItem(dashboardItem, customPropertyName, settings.ToJson(), $"Totals for {dashboardItem.ComponentName} is {status}");
            dashboardDesigner.AddToHistory(historyItem);
            UpdateTotalSettingsBarItem();
        }
        BarButtonItem CreateSettingsBarItem()
        {
            BarButtonItem barItem = new BarButtonItem();
            barItem.Caption = barButtonSettingsCaption;
            barItem.ImageOptions.SvgImage = global::PieTotalExtension.Properties.Resources.CustomizePieTotals;

            barItem.ItemClick += OnSettingsClick;
            barItem.RibbonStyle = RibbonItemStyles.All;
            return barItem;
        }
        void AddButtonToRibbon()
        {
            RibbonControl ribbon = dashboardDesigner.Ribbon;
            RibbonPage page = ribbon.GetDashboardRibbonPage(DashboardBarItemCategory.PiesTools, DashboardRibbonPage.Design);
            RibbonPageGroup group = page.GetGroupByName(ribonPageGroupName);
            if (group == null)
            {
                group = new RibbonPageGroup(ribonPageGroupName) { Name = ribonPageGroupName };
                page.Groups.Add(group);
            }
            showTotalBarItem = CreateShowTotalBarItem();
            totalSettingsBarItem = CreateSettingsBarItem();

            group.ItemLinks.Add(showTotalBarItem);
            group.ItemLinks.Add(totalSettingsBarItem);
        }
        void RemoveButtonFromRibbon()
        {
            RibbonControl ribbon = dashboardDesigner.Ribbon;
            RibbonPage page = ribbon.GetDashboardRibbonPage(DashboardBarItemCategory.PiesTools, DashboardRibbonPage.Design);
            RibbonPageGroup group = page.GetGroupByName(ribonPageGroupName);
            page.Groups.Remove(group);
        }
        void OnSettingsClick(object sender, ItemClickEventArgs e)
        {
            PieDashboardItem dashboardItem = dashboardDesigner.SelectedDashboardItem as PieDashboardItem;

            using (PieTotalSettingsDialog dialog = new PieTotalSettingsDialog(
                dashboardItem.CustomProperties[customPropertyName],
                dashboardItem.GetMeasures()))
            {
                if(dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK )
                {
                    PieTotalSettings settings = dialog.Settings;
                    CustomPropertyHistoryItem historyItem = new CustomPropertyHistoryItem(dashboardItem, customPropertyName, settings.ToJson(), $"Total settings for {dashboardItem.ComponentName} has been changed");
                    dashboardDesigner.AddToHistory(historyItem);
                    UpdateTotalSettingsBarItem();
                }
            }
        }

        #endregion
    }
}
