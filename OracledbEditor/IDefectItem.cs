using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracledbEditor
{
    public interface IDefectItem
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        int nHidden { get; set; }
        string TableName { get; }
    }
}
