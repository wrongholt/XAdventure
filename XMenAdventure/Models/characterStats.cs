using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace XMenAdventure.Models
{
    [Table("characterStats")]
    public class characterStats
    {
        [Key]
        public int statsId { get; set; }
        public string name { get; set; }
        public int charAtk { get; set; }
        public int charSpeed { get; set; }
        public int charDef { get; set; }
        public string special { get; set; }
        public int specialBonus { get; set; }
        public int health { get; set; }
        public string picture { get; set; }


       

    }
}