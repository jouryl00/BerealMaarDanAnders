using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace crudfototut.Models
{
    //HOW TO MAKE FOREIGN KEYS?
    //VIEWMODELS MVVM?
    //METHODES IN MODEL?
    //hOE FOTO MAKEN  
    //user geeft de informatie mee voor de foto
    //maak foto van (cuurent user) voor (current assignment)
    //ergens anders opslaan dan in librbaby
    //multipliciteit omdraaien
    [Table("photos")]
    public class Photo
    {
        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public int Id { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }
        [Ignore]
        public User User { get; set; }
        [Column("assignment_id")]
        public int AssignmentId { get; set; }
        [Ignore]
        public Assignment Assignment { get; set; }
        [Column("photo_url")]
        public string PhotoURL { get; set; }
        [Column("timestamp")]
        public DateTime Timestamp { get; set; }
        [Column("comments")]
        public string Comments { get; set; }


    }
}
