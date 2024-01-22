﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SimpleFormApp.Database;

#nullable disable

namespace SimpleFormApp.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240122185715_ChangeRequestFormReqs")]
    partial class ChangeRequestFormReqs
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SimpleFormApp.Database.RequestFormRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("ApplicationArea")
                        .HasColumnType("integer");

                    b.Property<string>("ContactEmail")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("Resolved")
                        .HasColumnType("boolean");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("VideoUrl")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("RequestForms");
                });

            modelBuilder.Entity("SimpleFormApp.Database.RequestFormRecord", b =>
                {
                    b.OwnsOne("SimpleFormApp.Database.Tag", "Tag", b1 =>
                        {
                            b1.Property<Guid>("RequestFormRecordId")
                                .HasColumnType("uuid");

                            b1.Property<string[]>("Tags")
                                .IsRequired()
                                .HasColumnType("text[]");

                            b1.HasKey("RequestFormRecordId");

                            b1.ToTable("RequestForms");

                            b1.ToJson("Tag");

                            b1.WithOwner()
                                .HasForeignKey("RequestFormRecordId");
                        });

                    b.Navigation("Tag")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}