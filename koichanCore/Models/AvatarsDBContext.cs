using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace koichanCore.Models
{
    public class AvatarsDBContext:DbContext
    {
        public AvatarsDBContext(DbContextOptions<AvatarsDBContext> options)
            : base(options)
        {
        }

        public DbSet<AvatarsModel> AspNetUserAvatars { get; set; }
    }
}
