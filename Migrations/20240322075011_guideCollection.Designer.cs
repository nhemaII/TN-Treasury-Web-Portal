﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TN_Treasury_Web_Portal.Data;

#nullable disable

namespace TN_Treasury_Web_Portal.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240322075011_guideCollection")]
    partial class guideCollection
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TN_Treasury_Web_Portal.Models.FAQ", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FAQ");
                });

            modelBuilder.Entity("TN_Treasury_Web_Portal.Models.Guide", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GuideId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GuideId");

                    b.ToTable("Guide");
                });

            modelBuilder.Entity("TN_Treasury_Web_Portal.Models.GuideSection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GuideId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GuideId");

                    b.ToTable("GuideSection");
                });

            modelBuilder.Entity("TN_Treasury_Web_Portal.Models.Guide", b =>
                {
                    b.HasOne("TN_Treasury_Web_Portal.Models.Guide", null)
                        .WithMany("Guides")
                        .HasForeignKey("GuideId");
                });

            modelBuilder.Entity("TN_Treasury_Web_Portal.Models.GuideSection", b =>
                {
                    b.HasOne("TN_Treasury_Web_Portal.Models.Guide", "Guide")
                        .WithMany()
                        .HasForeignKey("GuideId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guide");
                });

            modelBuilder.Entity("TN_Treasury_Web_Portal.Models.Guide", b =>
                {
                    b.Navigation("Guides");
                });
#pragma warning restore 612, 618
        }
    }
}
