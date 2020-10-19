using DevExpress.DashboardCommon;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraVerticalGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PieTotalExtension
{
    public partial class PieTotalSettingsDialog : Form
    {
        PieTotalSettings _settings;
        List<Measure> _measures;
        public PieTotalSettings Settings { get { return _settings; } }

        public PieTotalSettingsDialog()
        {
            InitializeComponent();
        }
        public PieTotalSettingsDialog(PieTotalSettings settings, List<Measure> measures)
        {
            InitializeComponent();
            _settings = settings;
            _measures = measures;
            SetupEditors(measures);
        }

        public PieTotalSettingsDialog(string settings, List<Measure> measures)
        {
            InitializeComponent();
            _settings = PieTotalSettings.FromJson(settings);
            _measures = measures;
            SetupEditors(measures);

        }

        void SetupEditors(List<Measure> measures)
        {
            lookUpEdit1.Properties.DisplayMember = "DisplayText";
            lookUpEdit1.Properties.ValueMember = "UniqueId";
            lookUpEdit1.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DisplayText"));
            lookUpEdit1.Properties.DataSource = measures.Select(m => new { UniqueId = m.UniqueId, DisplayText = m.ToString() });
            if (string.IsNullOrEmpty(Settings.MeasureId) || !measures.Where(m => m.UniqueId == Settings.MeasureId).Any())
                lookUpEdit1.EditValue = measures.FirstOrDefault().UniqueId;
            else
                lookUpEdit1.EditValue = Settings.MeasureId;
            textEdit1.Text = Settings.Prefix;
            textEdit2.Text = Settings.Postfix;
            UpdatePreview();
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            Settings.Prefix = textEdit1.Text;
            UpdatePreview();
        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {
            Settings.Postfix = textEdit2.Text;
            UpdatePreview();
        }

        void UpdatePreview()
        {
            string selectedMeasure = _measures.Where(m=>m.UniqueId == lookUpEdit1.EditValue.ToString()).FirstOrDefault().ToString();
            memoEdit1.Lines = new string[] { Settings.Prefix, selectedMeasure, Settings.Postfix };
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            Settings.MeasureId = lookUpEdit1.EditValue.ToString();
            UpdatePreview();
        }
    }
}
