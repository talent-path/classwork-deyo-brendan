﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlannerAPI.Persistence;

namespace PlannerAPI.Migrations
{
    [DbContext(typeof(PlannerDbContext))]
    partial class PlannerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PlannerAPI.Models.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Activity");
                });

            modelBuilder.Entity("PlannerAPI.Models.Attendee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Attendee");
                });

            modelBuilder.Entity("PlannerAPI.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("OrganizerId")
                        .HasColumnType("int");

                    b.Property<int?>("ScheduleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrganizerId");

                    b.HasIndex("ScheduleId");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("PlannerAPI.Models.EventActivities", b =>
                {
                    b.Property<int?>("ActivityId")
                        .HasColumnType("int");

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.HasIndex("ActivityId");

                    b.HasIndex("EventId");

                    b.ToTable("EventActivities");
                });

            modelBuilder.Entity("PlannerAPI.Models.EventAttendees", b =>
                {
                    b.Property<int?>("AttendeeId")
                        .HasColumnType("int");

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.HasIndex("AttendeeId");

                    b.HasIndex("EventId");

                    b.ToTable("EventAttendees");
                });

            modelBuilder.Entity("PlannerAPI.Models.EventOrganizer", b =>
                {
                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<int?>("OrganizerId")
                        .HasColumnType("int");

                    b.HasIndex("EventId");

                    b.HasIndex("OrganizerId");

                    b.ToTable("EventOrganizer");
                });

            modelBuilder.Entity("PlannerAPI.Models.Organizer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Organizer");
                });

            modelBuilder.Entity("PlannerAPI.Models.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Schedule");
                });

            modelBuilder.Entity("PlannerAPI.Models.Activity", b =>
                {
                    b.HasOne("PlannerAPI.Models.Event", null)
                        .WithMany("Activities")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlannerAPI.Models.Attendee", b =>
                {
                    b.HasOne("PlannerAPI.Models.Event", null)
                        .WithMany("Attendees")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlannerAPI.Models.Event", b =>
                {
                    b.HasOne("PlannerAPI.Models.Organizer", null)
                        .WithMany("OrganizedEvents")
                        .HasForeignKey("OrganizerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlannerAPI.Models.Schedule", null)
                        .WithMany("Events")
                        .HasForeignKey("ScheduleId");
                });

            modelBuilder.Entity("PlannerAPI.Models.EventActivities", b =>
                {
                    b.HasOne("PlannerAPI.Models.Activity", "Activity")
                        .WithMany()
                        .HasForeignKey("ActivityId");

                    b.HasOne("PlannerAPI.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId");

                    b.Navigation("Activity");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("PlannerAPI.Models.EventAttendees", b =>
                {
                    b.HasOne("PlannerAPI.Models.Attendee", "Attendee")
                        .WithMany()
                        .HasForeignKey("AttendeeId");

                    b.HasOne("PlannerAPI.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId");

                    b.Navigation("Attendee");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("PlannerAPI.Models.EventOrganizer", b =>
                {
                    b.HasOne("PlannerAPI.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId");

                    b.HasOne("PlannerAPI.Models.Organizer", "Organizer")
                        .WithMany()
                        .HasForeignKey("OrganizerId");

                    b.Navigation("Event");

                    b.Navigation("Organizer");
                });

            modelBuilder.Entity("PlannerAPI.Models.Event", b =>
                {
                    b.Navigation("Activities");

                    b.Navigation("Attendees");
                });

            modelBuilder.Entity("PlannerAPI.Models.Organizer", b =>
                {
                    b.Navigation("OrganizedEvents");
                });

            modelBuilder.Entity("PlannerAPI.Models.Schedule", b =>
                {
                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
