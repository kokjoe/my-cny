﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using my_cny.API.Data;

namespace my_cny.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190219063928_visitsysfield")]
    partial class visitsysfield
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("my_cny.API.Model.CurrentMRN", b =>
                {
                    b.Property<int>("RunningId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Prefix")
                        .HasMaxLength(20);

                    b.Property<int>("RunningNum");

                    b.HasKey("RunningId");

                    b.ToTable("CurrentMRNs");
                });

            modelBuilder.Entity("my_cny.API.Model.EmergencyContact", b =>
                {
                    b.Property<int>("EmergencyContactId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContactNo")
                        .HasMaxLength(20);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("EditedDate");

                    b.Property<int>("IdentificationId");

                    b.Property<string>("IdentificationNo")
                        .HasMaxLength(20);

                    b.Property<bool>("IsAudit");

                    b.Property<int?>("PatientId");

                    b.Property<int>("RelationshipId");

                    b.Property<int>("Version");

                    b.HasKey("EmergencyContactId");

                    b.HasIndex("IdentificationId");

                    b.HasIndex("PatientId");

                    b.HasIndex("RelationshipId");

                    b.ToTable("EmergencyContacts");
                });

            modelBuilder.Entity("my_cny.API.Model.Identification", b =>
                {
                    b.Property<int>("IdentificationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("EditedDate");

                    b.Property<string>("IdentificationName")
                        .HasMaxLength(50);

                    b.Property<bool>("IsAudit");

                    b.Property<int>("Version");

                    b.HasKey("IdentificationId");

                    b.ToTable("Identifications");
                });

            modelBuilder.Entity("my_cny.API.Model.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime?>("DOB");

                    b.Property<DateTime>("EditedDate");

                    b.Property<string>("Gender")
                        .HasMaxLength(1);

                    b.Property<int?>("IdentificationId");

                    b.Property<string>("IdentificationNo")
                        .HasMaxLength(20);

                    b.Property<bool>("IsAudit");

                    b.Property<string>("MRN")
                        .HasMaxLength(20);

                    b.Property<string>("PatientName")
                        .HasMaxLength(100);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int>("Version");

                    b.Property<int?>("ZipCode");

                    b.HasKey("PatientId");

                    b.HasIndex("IdentificationId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("my_cny.API.Model.Relationship", b =>
                {
                    b.Property<int>("RelationshipId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("EditedDate");

                    b.Property<bool>("IsAudit");

                    b.Property<string>("RelationshipName")
                        .HasMaxLength(20);

                    b.Property<int>("Version");

                    b.HasKey("RelationshipId");

                    b.ToTable("Relationships");
                });

            modelBuilder.Entity("my_cny.API.Model.Visit", b =>
                {
                    b.Property<int>("VisitId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("EditedDate");

                    b.Property<bool>("IsAudit");

                    b.Property<int>("PatientId");

                    b.Property<int>("Version");

                    b.Property<DateTime>("VisitDate");

                    b.Property<string>("VisitNo")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("VisitType")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("VisitId");

                    b.HasIndex("PatientId");

                    b.ToTable("Visits");
                });

            modelBuilder.Entity("my_cny.API.Model.EmergencyContact", b =>
                {
                    b.HasOne("my_cny.API.Model.Identification", "Identification")
                        .WithMany()
                        .HasForeignKey("IdentificationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("my_cny.API.Model.Patient")
                        .WithMany("EmergencyContacts")
                        .HasForeignKey("PatientId");

                    b.HasOne("my_cny.API.Model.Relationship", "Relationship")
                        .WithMany()
                        .HasForeignKey("RelationshipId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("my_cny.API.Model.Patient", b =>
                {
                    b.HasOne("my_cny.API.Model.Identification", "Identification")
                        .WithMany()
                        .HasForeignKey("IdentificationId");
                });

            modelBuilder.Entity("my_cny.API.Model.Visit", b =>
                {
                    b.HasOne("my_cny.API.Model.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
