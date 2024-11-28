using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace crudfototut.Models
{
    [Table("users")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("is_super_member")]
        public bool IsSuperMember { get; set; }
        [Column("points")]
        public int Points { get; set; }
    }
}
