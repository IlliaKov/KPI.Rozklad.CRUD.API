﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rozklad.CRUD.DAL.Repositories;

namespace Rozklad.CRUD.DAL.Migrations
{
    [DbContext(typeof(RozkladContext))]
    partial class RozkladContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Rozklad.CRUD.DAL.Entities.Evaluation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClassId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Day")
                        .HasColumnType("datetime2");

                    b.Property<int>("Mark")
                        .HasColumnType("int");

                    b.Property<Guid?>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.HasIndex("UserId");

                    b.ToTable("Evaluations");
                });

            modelBuilder.Entity("Rozklad.CRUD.DAL.Entities.Schedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClassId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsSecondWeek")
                        .HasColumnType("bit");

                    b.Property<int>("Lesson")
                        .HasColumnType("int");

                    b.Property<Guid?>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Weekday")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.HasIndex("UserId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("Rozklad.CRUD.DAL.Entities.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Rozklad.CRUD.DAL.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserClassId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserClassId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Rozklad.CRUD.DAL.Entities.UserClass", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserClasses");
                });

            modelBuilder.Entity("Rozklad.CRUD.DAL.Entities.Evaluation", b =>
                {
                    b.HasOne("Rozklad.CRUD.DAL.Entities.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId");

                    b.HasOne("Rozklad.CRUD.DAL.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Subject");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Rozklad.CRUD.DAL.Entities.Schedule", b =>
                {
                    b.HasOne("Rozklad.CRUD.DAL.Entities.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId");

                    b.HasOne("Rozklad.CRUD.DAL.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Subject");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Rozklad.CRUD.DAL.Entities.User", b =>
                {
                    b.HasOne("Rozklad.CRUD.DAL.Entities.UserClass", "UserClass")
                        .WithMany()
                        .HasForeignKey("UserClassId");

                    b.Navigation("UserClass");
                });
#pragma warning restore 612, 618
        }
    }
}
