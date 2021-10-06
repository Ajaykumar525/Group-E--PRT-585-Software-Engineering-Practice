﻿// <auto-generated />
using System;
using DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20211004133824_ProductEntity")]
    partial class ProductEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Entities.Applicant", b =>
                {
                    b.Property<long>("ApplicantID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Applicant_BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Applicant_CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Applicant_ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Applicant_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Applicant_Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contact_Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contact_Number")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ApplicantID");

                    b.ToTable("Applicants");
                });

            modelBuilder.Entity("DAL.Entities.Application", b =>
                {
                    b.Property<long>("ApplicationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ApplicantID")
                        .HasColumnType("bigint");

                    b.Property<long>("ApplicationStatusID")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Application_CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Application_ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("GradeID")
                        .HasColumnType("bigint");

                    b.Property<int>("SchoolYear")
                        .HasColumnType("int");

                    b.HasKey("ApplicationID");

                    b.HasIndex("ApplicantID");

                    b.HasIndex("ApplicationStatusID");

                    b.HasIndex("GradeID");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("DAL.Entities.ApplicationStatus", b =>
                {
                    b.Property<long>("ApplicationStatusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ApplicationStatus_CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ApplicationStatus_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ApplicationtStatus_ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ApplicationStatusID");

                    b.ToTable("ApplicationStatuses");
                });

            modelBuilder.Entity("DAL.Entities.Book", b =>
                {
                    b.Property<long>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("DAL.Entities.Computer", b =>
                {
                    b.Property<long>("ComputerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ComputerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastUser")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ComputerId");

                    b.ToTable("Computers");
                });

            modelBuilder.Entity("DAL.Entities.Grade", b =>
                {
                    b.Property<long>("GradeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Grade_Capacity")
                        .HasColumnType("int");

                    b.Property<DateTime>("Grade_CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Grade_ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Grade_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Grade_Number")
                        .HasColumnType("int");

                    b.HasKey("GradeID");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("DAL.Entities.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DAL.Entities.Student", b =>
                {
                    b.Property<long>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Student_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("DAL.Entities.Teacher", b =>
                {
                    b.Property<long>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeacherId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("DAL.Entities.Application", b =>
                {
                    b.HasOne("DAL.Entities.Applicant", "Applicant")
                        .WithMany("Applications")
                        .HasForeignKey("ApplicantID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.ApplicationStatus", "ApplicationStatus")
                        .WithMany("Applications")
                        .HasForeignKey("ApplicationStatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.Grade", "Grade")
                        .WithMany("Applications")
                        .HasForeignKey("GradeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Applicant");

                    b.Navigation("ApplicationStatus");

                    b.Navigation("Grade");
                });

            modelBuilder.Entity("DAL.Entities.Applicant", b =>
                {
                    b.Navigation("Applications");
                });

            modelBuilder.Entity("DAL.Entities.ApplicationStatus", b =>
                {
                    b.Navigation("Applications");
                });

            modelBuilder.Entity("DAL.Entities.Grade", b =>
                {
                    b.Navigation("Applications");
                });
#pragma warning restore 612, 618
        }
    }
}
