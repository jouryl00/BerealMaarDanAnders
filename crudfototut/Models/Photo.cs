using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace crudfototut.Models
{
    [Table("photos")]
    public class Photo
    {
        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public int Id { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("assignment_id")]
        public int AssignmentId { get; set; }
        [Column("photo_url")]
        public string PhotoURL { get; set; }
        [Column("timestamp")]
        public DateTime Timestamp { get; set; }

    }
}
