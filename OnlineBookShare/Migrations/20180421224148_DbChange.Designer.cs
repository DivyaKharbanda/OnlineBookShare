﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using OnlineBookShare.Models;
using System;

namespace OnlineBookShare.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20180421224148_DbChange")]
    partial class DbChange
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OnlineBookShare.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password");

                    b.Property<string>("UserName");

                    b.HasKey("UserId");

                    b.ToTable("Login");
                });

            modelBuilder.Entity("OnlineBookShare.Models.UserDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<int>("ContactNumber");

                    b.Property<string>("Email");

                    b.Property<int?>("LoginDetailsUserId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("LoginDetailsUserId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserDeatils");
                });

            modelBuilder.Entity("OnlineBookShare.Models.UserDetails", b =>
                {
                    b.HasOne("OnlineBookShare.Models.User", "LoginDetails")
                        .WithMany()
                        .HasForeignKey("LoginDetailsUserId");

                    b.HasOne("OnlineBookShare.Models.User", "User")
                        .WithOne("UserDetails")
                        .HasForeignKey("OnlineBookShare.Models.UserDetails", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
