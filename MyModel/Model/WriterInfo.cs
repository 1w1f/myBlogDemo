using System.Collections.Generic;
using System;
using SqlSugar;

namespace MyModel.Model
{
    public class WriterInfo : BaseId
    {
        [SugarColumn(ColumnDataType = "nvarchar(12)")]
        public string Name { get; set; }
        [SugarColumn(ColumnDataType = "nvarchar(16)",IsNullable=true)]
        public string UserName { get; set; }
        
        [SugarColumn(ColumnDataType = "nvarchar(64)")]

        public string PassWord { get; set; }
    }
}