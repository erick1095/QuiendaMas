﻿using System;
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
        public DateTime fechaInicio { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fechaFin { get; set; }
        public string ganador { get; set; }
        public TimeSpan tiempo { get; set; }

        //una subasta puede tener muchos participantes y solo un articulo
        public int articuloID { get; set; }
        public virtual Articulo articulo { get; set; }

        public virtual ICollection<Puja> pujas { get; set; }



    }
}