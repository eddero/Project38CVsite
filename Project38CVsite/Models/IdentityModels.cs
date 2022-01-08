using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web;

namespace Project38CVsite.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(1024)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(1024)]
        public string LastName { get; set; }
        [Required]
        [StringLength(1024)]
        public string Address { get; set; }
        [Required]
        [StringLength(1024)]
        public string Education { get; set; }
        [Required]
        [StringLength(1024)]
        public string Skill { get; set; }
        [Required]
        [StringLength(1024)]
        public string Experience { get; set; }
        
        public bool IsPrivate { get; set; }
        public string ImagePath { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }


        public virtual ICollection<Project> WorkOn { get; set; }
       

        public ICollection<Project> ProjectManaging { get; set; }
   
        public ICollection<Message> Messages { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Project> projects { get; set; }
        public DbSet<Message> messages { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Project>().HasRequired(x => x.Manager).WithMany(p => p.ProjectManaging).WillCascadeOnDelete(false);


            modelBuilder.Entity<Message>().HasRequired(x => x.User).WithMany(p => p.Messages).WillCascadeOnDelete(false);


            modelBuilder.Entity<Project>()
               .HasMany<ApplicationUser>(s => s.Participants)
               .WithMany(c => c.WorkOn)
               .Map(cs =>
               {
                   cs.MapLeftKey("ProjectRefId");
                   cs.MapRightKey("UserRefId");
                   cs.ToTable("UserProject");
               });
        }

    }
  
}