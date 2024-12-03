using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace crudfototut.Models
{
    [Table("assignments")]
    public class Assignment
    {
        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public int Id { get; set; }
        [Column("description")]
        public string Description { get; set; }
        //[Column("theme")]
        //public string Theme { get; set; }
        [Column("theme_id")]
        public string ThemeId { get; set; }


    }
}
