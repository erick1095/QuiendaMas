using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace quiendamas.Models
{
    public class Subasta
    {
        [Key]
        public int subastaID { get; set; }
        public Boolean estado { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha Inicio")]
        public DateTime fechaInicio { get; set; }
        [Display(Name = "Fecha Fin")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fechaFin { get; set; }
        [Display(Name = "Ganador")]
        public string ganador { get; set; }
        [Display(Name = "Tiempo")]
        public TimeSpan tiempo { get; set; }

        //una subasta puede tener muchos participantes y solo un articulo
        public int articuloID { get; set; }
        public virtual Articulo articulo { get; set; }

        public virtual ICollection<Puja> pujas { get; set; }
    }
}