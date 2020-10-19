using DevExpress.DashboardCommon;
using DevExpress.DashboardWin;
using DevExpress.XtraCharts;
using DevExpress.XtraReports.UI;
using PieTotalExtension;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignerSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dashboardDesigner1.CreateRibbon();
            PieTotalModule extension = new PieTotalModule();
            extension.Attach(dashboardDesigner1);
            dashboardDesigner1.LoadDashboard(@"..\..\Data\dashboard.xml");
            dashboardDesigner1.AsyncMode = true;

        }
    }
}
