﻿// <auto-generated />
using Beltretake.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Beltretake.Migrations
{
    [DbContext(typeof(ActivityContext))]
    partial class ActivityContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("Beltretake.Models.Activity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("creatorid");

                    b.Property<string>("description");

                    b.Property<TimeSpan>("duration");

                    b.Property<string>("name");

                    b.Property<DateTime>("start");

                    b.HasKey("id");

                    b.HasIndex("creatorid");

                    b.ToTable("_activities");
                });

            modelBuilder.Entity("Beltretake.Models.Join", b =>
                {
                    b.Property<int>("joinid")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("activityid");

                    b.Property<int>("userid");

                    b.HasKey("joinid");

                    b.HasIndex("activityid");

                    b.HasIndex("userid");

                    b.ToTable("_joins");
                });

            modelBuilder.Entity("Beltretake.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("email");

                    b.Property<string>("first");

                    b.Property<string>("last");

                    b.Property<string>("password");

                    b.HasKey("id");

                    b.ToTable("_users");
                });

            modelBuilder.Entity("Beltretake.Models.Activity", b =>
                {
                    b.HasOne("Beltretake.Models.User", "creator")
                        .WithMany()
                        .HasForeignKey("creatorid")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Beltretake.Models.Join", b =>
                {
                    b.HasOne("Beltretake.Models.Activity", "activity")
                        .WithMany("participating")
                        .HasForeignKey("activityid")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Beltretake.Models.User", "user")
                        .WithMany("participating")
                        .HasForeignKey("userid")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}