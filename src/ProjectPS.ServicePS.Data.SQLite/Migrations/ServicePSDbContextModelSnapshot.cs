﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectPS.ServicePS.Data.SQLite.Context;

namespace ProjectPS.ServicePS.Data.SQLite.Migrations
{
    [DbContext(typeof(ServicePSDbContext))]
    partial class ServicePSDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846");

            modelBuilder.Entity("ProjectPS.ServicePS.Core.Models.AppSetting", b =>
                {
                    b.Property<string>("Key")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("IsReadOnly");

                    b.Property<int>("Status");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime>("UpdatedOn");

                    b.Property<string>("Value")
                        .IsRequired();

                    b.Property<string>("Version");

                    b.HasKey("Key");

                    b.ToTable("AppSetting");
                });
#pragma warning restore 612, 618
        }
    }
}
