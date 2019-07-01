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
        public DbSet<Scrap> Scraps { get; set; }
        public DbSet<ScrapComment> ScrapComments { get; set; }
        public DbSet<ScrapLike> ScrapLikes { get; set; }
        public DbSet<ScrapCommentLikes> ScrapCommentLikes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserInfo>().HasMany(p => p.Scraps).WithOne(s => s.UserInfo);

            builder.Entity<Scrap>().HasKey(p => p.ScrapId);
            builder.Entity<Scrap>().HasMany(p => p.Comments).WithOne(s => s.Scrap).HasForeignKey(r => r.ScrapId);
            builder.Entity<Scrap>().Property(p => p.Post).IsRequired();
            builder.Entity<Scrap>().Property(p => p.Post).HasMaxLength(5000);
            builder.Entity<Scrap>().HasOne(p => p.UserInfo).WithMany(s => s.Scraps);
            builder.Entity<Scrap>().HasMany(l => l.ScrapLikes).WithOne(u => u.Scrap).HasForeignKey(f => f.ScrapId);
                

            builder.Entity<ScrapComment>().HasKey(p => p.CommentId);
            builder.Entity<ScrapComment>().HasOne(o => o.Scrap).WithMany(i => i.Comments).HasForeignKey(p => p.ScrapId);
            builder.Entity<ScrapComment>().Property(p => p.CommentDescription).IsRequired();
            builder.Entity<ScrapComment>().Property(p => p.CommentDescription).HasMaxLength(5000);
            builder.Entity<ScrapComment>().HasOne(u => u.UserInfo).WithMany(c => c.ScrapComments).HasForeignKey(f => f.IdentityId);
            builder.Entity<ScrapComment>().HasMany(l => l.ScrapCommentLikes).WithOne(s => s.ScrapComment).HasForeignKey(s => s.ScrapCommentId);

            builder.Entity<ScrapLike>().HasKey(k => k.LikeId);
            builder.Entity<ScrapLike>().HasOne(u => u.UserInfo).WithMany(l => l.ScrapLikes).HasForeignKey(f => f.IdentityId);
            builder.Entity<ScrapLike>().HasOne(u => u.Scrap).WithMany(i => i.ScrapLikes).HasForeignKey(f => f.ScrapId);

            builder.Entity<ScrapCommentLikes>().HasKey(k => k.ScrapCommentLikeId);
            builder.Entity<ScrapCommentLikes>().HasOne(u => u.UserInfo);
            builder.Entity<ScrapCommentLikes>().HasOne(u => u.ScrapComment).WithMany(i => i.ScrapCommentLikes).HasForeignKey(f => f.ScrapCommentId);

        }
    }
}
