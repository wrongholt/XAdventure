using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XMenAdventure.Models
{
    [Table("users")]
    public class user
    {
        [Key]
        public int id { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string character { get; set; }
        [ForeignKey("equipment")]
        public int equipId { get; set; }
        public virtual equipment equipment { get; set; }
        public int atk { get; set; }
        public int speed { get; set; }
        public int def { get; set; }
        public int charHealth { get; set; }
        public int currentHealth { get; set; }
        public string savePoint { get; set; }
    }
}