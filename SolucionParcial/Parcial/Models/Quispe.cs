using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Parcial.Models
{
    public enum Tipolista
    {
        universidad,
        colegio,
        clasesingles,
        clasesbaile,
        concierto,
    }

    public class Quispe
    {
        [Key]
        public int QuispeId { get; set; }
        [Required]
        [Display(Name = "Nombre Completo ")]
        [StringLength(24, MinimumLength = 4)]
        public string FriendofQuispe { get; set; }
        [Required]
        public Tipolista Lista { get; set; }
        public string Email { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd//MM/yyyy}", ApplyFormatInEditMode = true)]
        public int Brithdate { get; set; }
        public string Name { get; set; }
    }
}