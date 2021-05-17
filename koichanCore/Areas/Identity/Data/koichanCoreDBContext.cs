using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using koichanCore.Areas.Identity.Data;
using koichanCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace koichanCore.Data
{
    public class koichanCoreDBContext : IdentityDbContext<koichanCoreUser>
    {
        public koichanCoreDBContext(DbContextOptions<koichanCoreDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        //public DbSet<AvatarsModel> AspNetUserAvatars { get; set; }
    }
}
