using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace XMenAdventure.Models
{
    [Table("equipment")]
    public class equipment
    {
        [Key]
        public int equipId { get; set; }
        public string head { get; set; }
        public int? headId { get; set; }
        public string belt { get; set; }
        public int? beltId { get; set; }
        public string boots { get; set; }
        public int? bootsId { get; set; }
        public string equipSlot1 { get; set; }
        public string equipSlot2 { get; set; }
        public string equipSlot3 { get; set; }
        public string equipClass1 { get; set;}
        public string equipClass2 { get; set; }
        public string equipClass3 { get; set; }


    }
}