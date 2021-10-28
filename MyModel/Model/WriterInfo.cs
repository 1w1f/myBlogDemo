using System;
using SqlSugar;

namespace MyModel.Model
{
    public class WriterInfo:BaseId
    {
        [SugarColumn(ColumnDataType="nvarchar(12)")]
        public String Name { get; set; }
        [SugarColumn(ColumnDataType="nvarchar(16)")]
        public string UserName { get; set; }
        [SugarColumn(ColumnDataType="nvarchar(64)")]
        public String PassWord{ get; set; }
    }
}