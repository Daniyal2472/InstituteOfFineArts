using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using InstituteOfFineArts.Models;

namespace InstituteOfFineArts.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<InstituteOfFineArts.Models.Student> Student { get; set; } = default!;
        public DbSet<InstituteOfFineArts.Models.Staff> Staff { get; set; } = default!;
        public DbSet<InstituteOfFineArts.Models.Painting> Painting { get; set; } = default!;
        public DbSet<InstituteOfFineArts.Models.Manager> Manager { get; set; } = default!;
    }
}
