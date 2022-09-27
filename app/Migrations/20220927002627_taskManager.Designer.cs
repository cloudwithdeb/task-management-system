﻿// <auto-generated />
using System;
using DbContextNamespace;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace app.Migrations
{
    [DbContext(typeof(DbContextEfCore))]
    [Migration("20220927002627_taskManager")]
    partial class taskManager
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RemainderModelsNamespace.RemainderModel", b =>
                {
                    b.Property<int>("RemainderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RemainderID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("endDate");

                    b.Property<DateTime>("IsActivatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("isActivatedDate");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("startDate");

                    b.Property<int>("task")
                        .HasColumnType("integer");

                    b.HasKey("RemainderID");

                    b.HasIndex("task");

                    b.ToTable("Remainder");
                });

            modelBuilder.Entity("TaskModelNamespace.TaskModel", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TaskId"));

                    b.Property<DateTime>("DT")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("dateCreated");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("user")
                        .HasColumnType("integer");

                    b.HasKey("TaskId");

                    b.HasIndex("user");

                    b.ToTable("Task");
                });

            modelBuilder.Entity("UsersNamespace.UsersModel", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("firstName");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("lastName");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RemainderModelsNamespace.RemainderModel", b =>
                {
                    b.HasOne("TaskModelNamespace.TaskModel", "TaskModel")
                        .WithMany("RemainderModel")
                        .HasForeignKey("task")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TaskModel");
                });

            modelBuilder.Entity("TaskModelNamespace.TaskModel", b =>
                {
                    b.HasOne("UsersNamespace.UsersModel", "UsersModel")
                        .WithMany("TaskModel")
                        .HasForeignKey("user")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UsersModel");
                });

            modelBuilder.Entity("TaskModelNamespace.TaskModel", b =>
                {
                    b.Navigation("RemainderModel");
                });

            modelBuilder.Entity("UsersNamespace.UsersModel", b =>
                {
                    b.Navigation("TaskModel");
                });
#pragma warning restore 612, 618
        }
    }
}