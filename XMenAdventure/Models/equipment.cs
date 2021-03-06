﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string slot1Desc { get; set; }
        public string slot2Desc { get; set; }
        public string slot3Desc { get; set; }


    }
}