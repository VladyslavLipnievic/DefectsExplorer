﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracledbEditor
{
    public class DefectType : IDefectItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Defectid { get; set; }
        public string TableName { get; } = "defect_types";
    }
}
