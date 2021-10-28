using System;
using SqlSugar;

namespace MyModel.Model
{
    public class TypeInfo:BaseId
    {
        [SugarColumn(ColumnDataType="nvarchar(12)")]
        public String Name { get; set; }
        
    }
}