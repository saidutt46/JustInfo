﻿// <auto-generated />
using System;
using JustInfo.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JustInfo.Migrations
{
    [DbContext(typeof(JustInfoDbContext))]
    partial class JustInfoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JustInfo.Domain.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("JustInfo.Domain.Models.Scrap", b =>
                {
                    b.Property<string>("ScrapId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IdentityId");

                    b.Property<string>("Post")
                        .IsRequired()
                        .HasMaxLength(5000);

                    b.HasKey("ScrapId");

                    b.HasIndex("IdentityId");

                    b.ToTable("Scraps");
                });

            modelBuilder.Entity("JustInfo.Domain.Models.ScrapComment", b =>
                {
                    b.Property<string>("CommentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CommentDescription")
                        .IsRequired()
                        .HasMaxLength(5000);

                    b.Property<string>("IdentityId");

                    b.Property<string>("ScrapId");

                    b.HasKey("CommentId");

                    b.HasIndex("IdentityId");

                    b.HasIndex("ScrapId");

                    b.ToTable("ScrapComments");
                });

            modelBuilder.Entity("JustInfo.Domain.Models.ScrapCommentLikes", b =>
                {
                    b.Property<string>("ScrapCommentLikeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IdentityId");

                    b.Property<string>("ScrapCommentId");

                    b.Property<string>("UserInfoId");

                    b.HasKey("ScrapCommentLikeId");

                    b.HasIndex("ScrapCommentId");

                    b.HasIndex("UserInfoId");

                    b.ToTable("ScrapCommentLikes");
                });

            modelBuilder.Entity("JustInfo.Domain.Models.ScrapLike", b =>
                {
                    b.Property<string>("LikeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IdentityId");

                    b.Property<string>("ScrapId");

                    b.HasKey("LikeId");

                    b.HasIndex("IdentityId");

                    b.HasIndex("ScrapId");

                    b.ToTable("ScrapLikes");
                });

            modelBuilder.Entity("JustInfo.Domain.Models.UserInfo", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ColorTheme");

                    b.Property<string>("Email");

                    b.Property<int>("Gender");

                    b.Property<string>("IdentityId");

                    b.Property<string>("Location");

                    b.Property<string>("ProfileName");

                    b.HasKey("Id");

                    b.HasIndex("IdentityId");

                    b.ToTable("UserInfo");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("JustInfo.Domain.Models.Scrap", b =>
                {
                    b.HasOne("JustInfo.Domain.Models.UserInfo", "UserInfo")
                        .WithMany("Scraps")
                        .HasForeignKey("IdentityId");
                });

            modelBuilder.Entity("JustInfo.Domain.Models.ScrapComment", b =>
                {
                    b.HasOne("JustInfo.Domain.Models.UserInfo", "UserInfo")
                        .WithMany("ScrapComments")
                        .HasForeignKey("IdentityId");

                    b.HasOne("JustInfo.Domain.Models.Scrap", "Scrap")
                        .WithMany("Comments")
                        .HasForeignKey("ScrapId");
                });

            modelBuilder.Entity("JustInfo.Domain.Models.ScrapCommentLikes", b =>
                {
                    b.HasOne("JustInfo.Domain.Models.ScrapComment", "ScrapComment")
                        .WithMany("ScrapCommentLikes")
                        .HasForeignKey("ScrapCommentId");

                    b.HasOne("JustInfo.Domain.Models.UserInfo", "UserInfo")
                        .WithMany()
                        .HasForeignKey("UserInfoId");
                });

            modelBuilder.Entity("JustInfo.Domain.Models.ScrapLike", b =>
                {
                    b.HasOne("JustInfo.Domain.Models.UserInfo", "UserInfo")
                        .WithMany("ScrapLikes")
                        .HasForeignKey("IdentityId");

                    b.HasOne("JustInfo.Domain.Models.Scrap", "Scrap")
                        .WithMany("ScrapLikes")
                        .HasForeignKey("ScrapId");
                });

            modelBuilder.Entity("JustInfo.Domain.Models.UserInfo", b =>
                {
                    b.HasOne("JustInfo.Domain.Models.AppUser", "Identity")
                        .WithMany()
                        .HasForeignKey("IdentityId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("JustInfo.Domain.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("JustInfo.Domain.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JustInfo.Domain.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("JustInfo.Domain.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
