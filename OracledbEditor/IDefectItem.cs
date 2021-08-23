﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracledbEditor
{
    interface IDefectItem
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string TableName { get; }
    }
}
