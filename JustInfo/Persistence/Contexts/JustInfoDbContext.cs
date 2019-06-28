using System;
using JustInfo.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JustInfo.Persistence.Contexts
{
    public class JustInfoDbContext : IdentityDbContext<AppUser>
    {
        public JustInfoDbContext(DbContextOptions options) : base(options) { }

        public DbSet<UserInfo> UserInfo { get; set; }
    }
}
