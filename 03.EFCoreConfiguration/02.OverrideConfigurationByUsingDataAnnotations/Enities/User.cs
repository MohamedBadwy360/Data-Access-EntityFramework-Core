using System.ComponentModel.DataAnnotations.Schema;

namespace Enities
{
    [Table("tblUsers")]
    public class User
    {
        [Column("UserId")]
        public int Id { get; set; }
        public string UserName { get; set; }
    }
}
