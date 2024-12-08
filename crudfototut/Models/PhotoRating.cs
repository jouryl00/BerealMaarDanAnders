using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace crudfototut.Models
{
    [Table("photo_ratings")]
    public class PhotoRating
    {
        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public int Id { get; set; }
        [Column("photo_id")]
        public int PhotoId { get; set; }
        [Ignore]
        public Photo Photo { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }
        [Ignore]
        public User User { get; set; }
        [Column("rating")]
        public int Rating { get; set; }
        //[Column("timestamp")]
        //public DateTime Timestamp { get; set; }

    }
}
