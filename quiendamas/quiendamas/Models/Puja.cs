using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace quiendamas.Models
{
    public class Puja
    {
        [Key]
        public int pujaID { get; set; }
        [Display(Name = "Cantidad De Tokens")]
        public int cantidadParticipaciones { get; set; }
        [Display(Name = "Fecha Del Token")]
        public DateTime fechaPuja { get; set; }

        public int subastaID { get; set; }
        public virtual Subasta subasta { get; set; }

        public String Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}