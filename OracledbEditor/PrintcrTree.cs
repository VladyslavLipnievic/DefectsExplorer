using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OracledbEditor
{
    public partial class PrintcrTree : Form
    {

        Configuration configuration;
        public PrintcrTree(Configuration configuration)
        {
            this.configuration = configuration;
            InitializeComponent();
        }




        private void PrintcrTree_Load(object sender, EventArgs e)
        {




        }

        private void loadCrystalReport()
        {


        }

        private void crystalReportViewe2_Load(object sender, EventArgs e)
        {
            Report1crtreeview3 cryRpt = new Report1crtreeview3();
            //MessageBox.Show(parameterCr);
           
            //string parameter = "select";
            crystalReportViewer2.ReportSource = cryRpt;
            cryRpt.Load(cryRpt.ToString());
            cryRpt.Refresh();
            //cryRpt.SetParameterValue("query", parameter);
            cryRpt.SetDatabaseLogon(configuration.userId, configuration.password, configuration.address, "");
            
          //  DateTime Now = DateTime.Now;
          //  string timeNow = Now.ToString("yyyy-MM-dd hh.mm.ss");
          // cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"D:\crystalReport" + dName + timeNow + ".pdf");
        }
    }
}
