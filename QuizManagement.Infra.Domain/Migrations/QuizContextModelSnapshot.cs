﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuizManagement.Infra.Domain;

#nullable disable

namespace QuizManagement.Infra.Domain.Migrations
{
    [DbContext(typeof(QuizContext))]
    partial class QuizContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("QuizManagement.Infra.Domain.Entities.Feedback", b =>
                {
                    b.Property<long>("FeedbackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("FeedbackId"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ParticipantId")
                        .HasColumnType("bigint");

                    b.Property<long>("QuizId")
                        .HasColumnType("bigint");

                    b.HasKey("FeedbackId");

                    b.HasIndex("ParticipantId");

                    b.HasIndex("QuizId");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("QuizManagement.Infra.Domain.Entities.OptionBank", b =>
                {
                    b.Property<long>("OptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("OptionId"));

                    b.Property<string>("Option")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("QuestionId")
                        .HasColumnType("bigint");

                    b.HasKey("OptionId");

                    b.HasIndex("QuestionId");

                    b.ToTable("OptionBanks");
                });

            modelBuilder.Entity("QuizManagement.Infra.Domain.Entities.Participant", b =>
                {
                    b.Property<long>("ParticipantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ParticipantId"));

                    b.Property<long>("QuizId")
                        .HasColumnType("bigint");

                    b.Property<decimal?>("Score")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("ParticipantId");

                    b.HasIndex("QuizId");

                    b.HasIndex("UserId");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("QuizManagement.Infra.Domain.Entities.QuestionAnswer", b =>
                {
                    b.Property<long>("QuestionAnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("QuestionAnswerId"));

                    b.Property<long>("ParticipantId")
                        .HasColumnType("bigint");

                    b.Property<long>("QuestionId")
                        .HasColumnType("bigint");

                    b.Property<long>("SelectedAnswer")
                        .HasColumnType("bigint");

                    b.HasKey("QuestionAnswerId");

                    b.HasIndex("ParticipantId");

                    b.HasIndex("QuestionId");

                    b.HasIndex("SelectedAnswer");

                    b.ToTable("QuestionAnswers");
                });

            modelBuilder.Entity("QuizManagement.Infra.Domain.Entities.QuestionBank", b =>
                {
                    b.Property<long>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("QuestionId"));

                    b.Property<long?>("CorrectOption")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("QuizId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.HasKey("QuestionId");

                    b.HasIndex("CorrectOption");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("QuizId");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("QuestionBanks");
                });

            modelBuilder.Entity("QuizManagement.Infra.Domain.Entities.Quiz", b =>
                {
                    b.Property<long>("QuizId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("QuizId"));

                    b.Property<string>("QRCodeImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuizName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalQuestions")
                        .HasColumnType("int");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("QuizId");

                    b.HasIndex("UserId");

                    b.ToTable("Quizzes");
                });

            modelBuilder.Entity("QuizManagement.Infra.Domain.Entities.Role", b =>
                {
                    b.Property<long>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("RoleId"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("QuizManagement.Infra.Domain.Entities.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("UserId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("GenerateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit");

                    b.Property<long>("OTP")
                        .HasColumnType("bigint");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("QuizManagement.Infra.Domain.Entities.UserRole", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("QuizManagement.Infra.Domain.Entities.Feedback", b =>
                {
                    b.HasOne("QuizManagement.Infra.Domain.Entities.Participant", "Participant")
                        .WithMany()
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuizManagement.Infra.Domain.Entities.Quiz", "Quiz")
                        .WithMany()
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Participant");

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("QuizManagement.Infra.Domain.Entities.OptionBank", b =>
                {
                    b.HasOne("QuizManagement.Infra.Domain.Entities.QuestionBank", "QuestionBank")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuestionBank");
                });

            modelBuilder.Entity("QuizManagement.Infra.Domain.Entities.Participant", b =>
                {
                    b.HasOne("QuizManagement.Infra.Domain.Entities.Quiz", "Quiz")
                        .WithMany()
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuizManagement.Infra.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quiz");

                    b.Navigation("User");
                });

            modelBuilder.Entity("QuizManagement.Infra.Domain.Entities.QuestionAnswer", b =>
                {
                    b.HasOne("QuizManagement.Infra.Domain.Entities.Participant", "Participant")
                        .WithMany()
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuizManagement.Infra.Domain.Entities.QuestionBank", "QuestionBank")
                        .WithMany("QuestionAnswers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuizManagement.Infra.Domain.Entities.OptionBank", "OptionBank")
                        .WithMany()
                        .HasForeignKey("SelectedAnswer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OptionBank");

                    b.Navigation("Participant");

                    b.Navigation("QuestionBank");
                });

            modelBuilder.Entity("QuizManagement.Infra.Domain.Entities.QuestionBank", b =>
                {
                    b.HasOne("QuizManagement.Infra.Domain.Entities.OptionBank", "OptionBank")
                        .WithMany()
                        .HasForeignKey("CorrectOption");

                    b.HasOne("QuizManagement.Infra.Domain.Entities.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("QuizManagement.Infra.Domain.Entities.Quiz", "Quiz")
                        .WithMany()
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuizManagement.Infra.Domain.Entities.User", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("UpdatedBy");

                    b.Navigation("CreatedUser");

                    b.Navigation("OptionBank");

                    b.Navigation("Quiz");

                    b.Navigation("UpdatedUser");
                });

            modelBuilder.Entity("QuizManagement.Infra.Domain.Entities.Quiz", b =>
                {
                    b.HasOne("QuizManagement.Infra.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("QuizManagement.Infra.Domain.Entities.User", b =>
                {
                    b.HasOne("QuizManagement.Infra.Domain.Entities.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("QuizManagement.Infra.Domain.Entities.User", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("UpdatedBy");

                    b.Navigation("CreatedUser");

                    b.Navigation("UpdatedUser");
                });

            modelBuilder.Entity("QuizManagement.Infra.Domain.Entities.UserRole", b =>
                {
                    b.HasOne("QuizManagement.Infra.Domain.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuizManagement.Infra.Domain.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("QuizManagement.Infra.Domain.Entities.QuestionBank", b =>
                {
                    b.Navigation("QuestionAnswers");
                });

            modelBuilder.Entity("QuizManagement.Infra.Domain.Entities.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("QuizManagement.Infra.Domain.Entities.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
