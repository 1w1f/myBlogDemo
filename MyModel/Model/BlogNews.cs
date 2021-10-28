using System.Reflection;
using System.Net.Sockets;
using System;
using SqlSugar;

namespace MyModel.Model
{
    public class BlogNews:BaseId
    {
        //nvarchar中文比较好
        [SugarColumn(ColumnDataType="nvarchar(30)")]
        public string  Title { get; set; }
        [SugarColumn(ColumnDataType="text")]
        public string Content { get; set; }
        public DateTime Time { get; set; }
        public int LikeCount { get; set; }
        


        public int WriterId { get; set; }
        public int TypeId { get; set; }

        [SugarColumn(IsIgnore=true)]
        public TypeInfo TypeInfo { get; set; }
        
        [SugarColumn(IsIgnore=true)]
        public WriterInfo WriterInfo { get; set; }
    }
}