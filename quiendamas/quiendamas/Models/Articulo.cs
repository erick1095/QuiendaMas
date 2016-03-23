using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;

namespace quiendamas.Models
{
    public class Articulo
    {   
        [Key]
        public int articuloID { get; set; }
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Display(Name = "Estado")]
        public string estadoArticulo { get; set; }
        [Display(Name = "Costo")]
        public decimal costo { get; set; }
        [Display(Name = "Descripcion")]
        public string descripcion { get; set; }
        //public Image fotografia { get; set; }


        //un articulo puede estar en barias subastas
        [Display(Name = "Administrador")]
        public String UserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<Subasta> subastas { get; set; }
    }
}