﻿// <auto-generated />
using System;
using DashboardIoT.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DashboardIoT.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20210603185345_AddAlarm")]
    partial class AddAlarm
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("DashboardIoT.Models.Alarm", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<DateTime>("Time")
                        .HasColumnType("TEXT")
                        .HasColumnName("time");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Alarms");
                });
#pragma warning restore 612, 618
        }
    }
}