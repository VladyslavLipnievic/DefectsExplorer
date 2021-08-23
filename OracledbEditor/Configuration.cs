using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OracledbEditor
{
    public class Configuration
    {
        public string address { get; set; }
        public string userId { get; set; }
        public string password { get; set; }
    }






    /* TreeNode treeNode = treeView1.Nodes.Add(qs.defectlist[0].Name);
     treeNode.Tag = qs.defectlist[0];
             treeNode = treeView1.Nodes.Add(qs.defectlist[1].Name);
             treeNode.Tag = qs.defectlist[1];
             treeNode = treeNode.Nodes.Add(qs.defectlist[2].Name);
             treeNode.Tag = qs.defectlist[2];*/

    /*
                TreeNode defectNode;
                TreeNode defectTypeNode;
                TreeNode defectPositionNode;
                foreach (var defect in qs.defectlist)
                {
                    defectNode = treeView1.Nodes.Add(defect.Name);
                    foreach (var defectType in qs.defectTypeList)
                    {
                        if (defectType.Defectid == defect.Id)
                        {
                            defectTypeNode = defectNode.Nodes.Add(defectType.Name);
                            foreach (var DefectPosition in qs.defectPositionList)
                            {
                                if (DefectPosition.DefectTypeId == defectType.Id)
                                {
                                    defectPositionNode = defectTypeNode.Nodes.Add(DefectPosition.Name);
                                }
                            }
                        }

                    }
                }*/
}
