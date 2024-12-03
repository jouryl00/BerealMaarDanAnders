using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace crudfototut.Models
{
    [Table("themes")]

    public class Theme

    {
        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("assignments")]
        //klopt dit?!?
        public List<Assignment> Assignments { get; set; }


    }
}
