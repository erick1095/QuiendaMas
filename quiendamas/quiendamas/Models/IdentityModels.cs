using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Drawing;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace quiendamas.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string colonia { get; set; }
        public int codigoPostal { get; set; }
        public string pais { get; set; }
        public string ciudad { get; set; }
        public string telefono { get; set; }
        public int noCasa { get; set; }
        //public Image fotografia { get; set; }



        public virtual ICollection<Puja> pujas { get; set; }
        public virtual ICollection<Articulo> articulos { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("ConexionQuiendamas", throwIfV1Schema: false)
        {


        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }



        public DbSet<Articulo> Articulo { get; set; }
        public DbSet<Subasta> Subasta { get; set; }
        public DbSet<Puja> Puja { get; set; }
    }
}