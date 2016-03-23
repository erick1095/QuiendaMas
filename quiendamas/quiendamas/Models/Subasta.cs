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
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public string ganador { get; set; }

        //una subasta puede tener muchos participantes y solo un articulo
        public int articuloID { get; set; }
        public virtual Articulo articulo { get; set; }

        public virtual ICollection<Puja> pujas { get; set; }


    }
}