using Microsoft.PowerBI.Api.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace OracledbEditor
{
    public partial class reportPrint : Form
    {
        string itemTypeId;
        string dName;
        DbOperations db;
        Configuration configuration;
        public reportPrint(DbOperations db, string itemTypeId, Configuration configuration, string dName)
        {
            InitializeComponent();
            this.db = db;
            this.dName = dName;
            this.itemTypeId = itemTypeId;
            this.configuration = configuration;
           // MessageBox.Show(itemTypeId);
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

            report_with_images_3 cryRpt = new report_with_images_3();
            cryRpt.Load(cryRpt.ToString());
            string parameterCr = "";
            if (itemTypeId != "0")
            {
               parameterCr = "and d.nid =" + itemTypeId;
            }

            //cryRpt.SetDatabaseLogon("praktika_Vladyslav", "praktika", "192.168.0.188:1521/startas", "");
            cryRpt.SetDatabaseLogon(configuration.userId, configuration.password, configuration.address, "");
            cryRpt.SetParameterValue("defect_id", parameterCr.ToString());

            DateTime Now = DateTime.Now;
            string timeNow = Now.ToString("yyyy-MM-dd hh.mm.ss");
            cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"D:\crystalReport"+ dName + timeNow+ ".pdf");

            crystalReportViewer1.ReportSource = cryRpt;
            crystalReportViewer1.Refresh();
        }
    }
}
