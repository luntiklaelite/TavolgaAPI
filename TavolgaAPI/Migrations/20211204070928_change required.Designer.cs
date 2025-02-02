﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TavolgaAPI.Models;

namespace TavolgaAPI.Migrations
{
    [DbContext(typeof(EfModel))]
    [Migration("20211204070928_change required")]
    partial class changerequired
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("EventValuatorBase", b =>
                {
                    b.Property<int>("EventsId")
                        .HasColumnType("int");

                    b.Property<int>("ValuatorsEditedId")
                        .HasColumnType("int");

                    b.HasKey("EventsId", "ValuatorsEditedId");

                    b.HasIndex("ValuatorsEditedId");

                    b.ToTable("EventValuatorBase");
                });

            modelBuilder.Entity("NominationValuatorBase", b =>
                {
                    b.Property<int>("NominationsId")
                        .HasColumnType("int");

                    b.Property<int>("ValuatorsId")
                        .HasColumnType("int");

                    b.HasKey("NominationsId", "ValuatorsId");

                    b.HasIndex("ValuatorsId");

                    b.ToTable("NominationValuatorBase");
                });

            modelBuilder.Entity("TavolgaAPI.Models.Entityes.ContestantScore", b =>
                {
                    b.Property<int>("CriteriaId")
                        .HasColumnType("int");

                    b.Property<int>("AccessorId")
                        .HasColumnType("int");

                    b.Property<int>("ContestantId")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.HasKey("CriteriaId", "AccessorId", "ContestantId");

                    b.HasIndex("AccessorId");

                    b.HasIndex("ContestantId");

                    b.ToTable("ContestantScores");
                });

            modelBuilder.Entity("TavolgaAPI.Models.Entityes.Criteria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(1024)
                        .HasColumnType("varchar(1024)");

                    b.Property<int>("MaxScore")
                        .HasColumnType("int");

                    b.Property<int>("MinScore")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("NominationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NominationId");

                    b.ToTable("Criterias");
                });

            modelBuilder.Entity("TavolgaAPI.Models.Entityes.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(1024)
                        .HasColumnType("varchar(1024)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("TavolgaAPI.Models.Entityes.FinalScore", b =>
                {
                    b.Property<int>("ContestantId")
                        .HasColumnType("int");

                    b.Property<int>("CriteriaId")
                        .HasColumnType("int");

                    b.Property<bool>("IsAccepted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("JuriId")
                        .HasColumnType("int");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.HasKey("ContestantId", "CriteriaId");

                    b.HasIndex("CriteriaId");

                    b.HasIndex("JuriId");

                    b.ToTable("FinalScores");
                });

            modelBuilder.Entity("TavolgaAPI.Models.Entityes.Nomination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(1024)
                        .HasColumnType("varchar(1024)");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Nominations");
                });

            modelBuilder.Entity("TavolgaAPI.Models.Entityes.Users.AdminUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.Property<string>("FIO")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.HasKey("Id");

                    b.ToTable("AdminUsers");
                });

            modelBuilder.Entity("TavolgaAPI.Models.Entityes.Users.Contestant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.Property<string>("FIO")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.HasKey("Id");

                    b.ToTable("Contestants");
                });

            modelBuilder.Entity("TavolgaAPI.Models.Entityes.Users.ValuatorBase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.Property<string>("FIO")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.HasKey("Id");

                    b.ToTable("ValuatorBase");
                });

            modelBuilder.Entity("TavolgaAPI.Models.Entityes.Users.Accessor", b =>
                {
                    b.HasBaseType("TavolgaAPI.Models.Entityes.Users.ValuatorBase");

                    b.ToTable("Accessors");
                });

            modelBuilder.Entity("TavolgaAPI.Models.Entityes.Users.Jury", b =>
                {
                    b.HasBaseType("TavolgaAPI.Models.Entityes.Users.ValuatorBase");

                    b.ToTable("Jurys");
                });

            modelBuilder.Entity("EventValuatorBase", b =>
                {
                    b.HasOne("TavolgaAPI.Models.Entityes.Event", null)
                        .WithMany()
                        .HasForeignKey("EventsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TavolgaAPI.Models.Entityes.Users.ValuatorBase", null)
                        .WithMany()
                        .HasForeignKey("ValuatorsEditedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NominationValuatorBase", b =>
                {
                    b.HasOne("TavolgaAPI.Models.Entityes.Nomination", null)
                        .WithMany()
                        .HasForeignKey("NominationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TavolgaAPI.Models.Entityes.Users.ValuatorBase", null)
                        .WithMany()
                        .HasForeignKey("ValuatorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TavolgaAPI.Models.Entityes.ContestantScore", b =>
                {
                    b.HasOne("TavolgaAPI.Models.Entityes.Users.Accessor", "Accessor")
                        .WithMany("contestantScores")
                        .HasForeignKey("AccessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TavolgaAPI.Models.Entityes.Users.Contestant", "Contestant")
                        .WithMany("ContestantScores")
                        .HasForeignKey("ContestantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TavolgaAPI.Models.Entityes.Criteria", "Criteria")
                        .WithMany("ContestantScores")
                        .HasForeignKey("CriteriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Accessor");

                    b.Navigation("Contestant");

                    b.Navigation("Criteria");
                });

            modelBuilder.Entity("TavolgaAPI.Models.Entityes.Criteria", b =>
                {
                    b.HasOne("TavolgaAPI.Models.Entityes.Nomination", "Nomination")
                        .WithMany("Criteries")
                        .HasForeignKey("NominationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Nomination");
                });

            modelBuilder.Entity("TavolgaAPI.Models.Entityes.FinalScore", b =>
                {
                    b.HasOne("TavolgaAPI.Models.Entityes.Users.Contestant", "contestant")
                        .WithMany()
                        .HasForeignKey("ContestantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TavolgaAPI.Models.Entityes.Criteria", "Criteria")
                        .WithMany("FinalScores")
                        .HasForeignKey("CriteriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TavolgaAPI.Models.Entityes.Users.Jury", "Juri")
                        .WithMany("FinalScores")
                        .HasForeignKey("JuriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("contestant");

                    b.Navigation("Criteria");

                    b.Navigation("Juri");
                });

            modelBuilder.Entity("TavolgaAPI.Models.Entityes.Nomination", b =>
                {
                    b.HasOne("TavolgaAPI.Models.Entityes.Event", "Event")
                        .WithMany("Nominations")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("TavolgaAPI.Models.Entityes.Users.Accessor", b =>
                {
                    b.HasOne("TavolgaAPI.Models.Entityes.Users.ValuatorBase", null)
                        .WithOne()
                        .HasForeignKey("TavolgaAPI.Models.Entityes.Users.Accessor", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TavolgaAPI.Models.Entityes.Users.Jury", b =>
                {
                    b.HasOne("TavolgaAPI.Models.Entityes.Users.ValuatorBase", null)
                        .WithOne()
                        .HasForeignKey("TavolgaAPI.Models.Entityes.Users.Jury", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TavolgaAPI.Models.Entityes.Criteria", b =>
                {
                    b.Navigation("ContestantScores");

                    b.Navigation("FinalScores");
                });

            modelBuilder.Entity("TavolgaAPI.Models.Entityes.Event", b =>
                {
                    b.Navigation("Nominations");
                });

            modelBuilder.Entity("TavolgaAPI.Models.Entityes.Nomination", b =>
                {
                    b.Navigation("Criteries");
                });

            modelBuilder.Entity("TavolgaAPI.Models.Entityes.Users.Contestant", b =>
                {
                    b.Navigation("ContestantScores");
                });

            modelBuilder.Entity("TavolgaAPI.Models.Entityes.Users.Accessor", b =>
                {
                    b.Navigation("contestantScores");
                });

            modelBuilder.Entity("TavolgaAPI.Models.Entityes.Users.Jury", b =>
                {
                    b.Navigation("FinalScores");
                });
#pragma warning restore 612, 618
        }
    }
}
