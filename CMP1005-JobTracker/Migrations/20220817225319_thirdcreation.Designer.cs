﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CMP1005_JobTracker.Migrations
{
    [DbContext(typeof(JobTrackerContext))]
    [Migration("20220817225319_thirdcreation")]
    partial class thirdcreation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("CMP1005_JobTracker.Models.DTR", b =>
                {
                    b.Property<int>("DTRId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("JobId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TimeIn")
                        .HasColumnType("TEXT");

                    b.Property<string>("TimeOut")
                        .HasColumnType("TEXT");

                    b.HasKey("DTRId");

                    b.HasIndex("JobId");

                    b.ToTable("DTR");
                });

            modelBuilder.Entity("CMP1005_JobTracker.Models.Job", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Detail")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("JobId");

                    b.ToTable("Job");
                });

            modelBuilder.Entity("CMP1005_JobTracker.Models.Reminder", b =>
                {
                    b.Property<int>("RemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<int>("JobId")
                        .HasColumnType("INTEGER");

                    b.HasKey("RemId");

                    b.HasIndex("JobId");

                    b.ToTable("Reminder");
                });

            modelBuilder.Entity("CMP1005_JobTracker.Models.DTR", b =>
                {
                    b.HasOne("CMP1005_JobTracker.Models.Job", "Jobs")
                        .WithMany()
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("CMP1005_JobTracker.Models.Reminder", b =>
                {
                    b.HasOne("CMP1005_JobTracker.Models.Job", "Jobs")
                        .WithMany()
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Jobs");
                });
#pragma warning restore 612, 618
        }
    }
}
