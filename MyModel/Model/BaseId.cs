using SqlSugar;
namespace MyModel.Model
{
    public class BaseId
    {
        [SugarColumn(IsIdentity  = true,IsPrimaryKey  = true)]
        public int Id { get; set; }
    }
}