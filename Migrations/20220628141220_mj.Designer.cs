﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using mis_mmc.Models;

#nullable disable

namespace mis_mmc.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220628141220_mj")]
    partial class mj
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("mis_mmc.Models.AssignmentModel", b =>
                {
                    b.Property<int>("s_no")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("cid")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("due_date")
                        .HasColumnType("date");

                    b.Property<string>("file")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("points")
                        .HasColumnType("int");

                    b.Property<DateOnly>("published_date")
                        .HasColumnType("date");

                    b.Property<int>("tid")
                        .HasColumnType("int");

                    b.HasKey("s_no");

                    b.HasIndex("cid");

                    b.HasIndex("tid");

                    b.ToTable("AssignmentModels");
                });

            modelBuilder.Entity("mis_mmc.Models.AssignmentReturnModel", b =>
                {
                    b.Property<int>("s_no")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("aid")
                        .HasColumnType("int");

                    b.Property<int>("cid")
                        .HasColumnType("int");

                    b.Property<string>("file")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("is_checked")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("points")
                        .HasColumnType("int");

                    b.Property<DateOnly>("return_date")
                        .HasColumnType("date");

                    b.Property<int>("sid")
                        .HasColumnType("int");

                    b.Property<int>("tid")
                        .HasColumnType("int");

                    b.HasKey("s_no");

                    b.HasIndex("aid");

                    b.HasIndex("cid");

                    b.HasIndex("sid");

                    b.HasIndex("tid");

                    b.ToTable("AssignmentReturnModels");
                });

            modelBuilder.Entity("mis_mmc.Models.BookIssueModel", b =>
                {
                    b.Property<int>("s_no")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("bid")
                        .HasColumnType("int");

                    b.Property<DateOnly>("expiry_date")
                        .HasColumnType("date");

                    b.Property<bool?>("is_returned")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateOnly?>("issued_date")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("return_date")
                        .HasColumnType("date");

                    b.Property<int>("sid")
                        .HasColumnType("int");

                    b.Property<string>("uid")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("s_no");

                    b.HasIndex("bid");

                    b.HasIndex("sid");

                    b.ToTable("BookIssueModels");
                });

            modelBuilder.Entity("mis_mmc.Models.BookModel", b =>
                {
                    b.Property<int>("s_no")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("author")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool?>("is_issued")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("pid")
                        .HasColumnType("int");

                    b.Property<string>("publication")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("sem_year")
                        .HasColumnType("int");

                    b.Property<int>("stock")
                        .HasColumnType("int");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("s_no");

                    b.HasIndex("pid");

                    b.ToTable("BookModels");
                });

            modelBuilder.Entity("mis_mmc.Models.CollegeDetails", b =>
                {
                    b.Property<int>("s_no")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("college_name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("logo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("phone_number_one")
                        .HasColumnType("int");

                    b.HasKey("s_no");

                    b.ToTable("CollegeDetails");
                });

            modelBuilder.Entity("mis_mmc.Models.CourseModel", b =>
                {
                    b.Property<int>("s_no")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("file")
                        .HasColumnType("longtext");

                    b.Property<string>("lecturer")
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("pid")
                        .HasColumnType("int");

                    b.Property<int>("sem_year")
                        .HasColumnType("int");

                    b.Property<int?>("tid")
                        .HasColumnType("int");

                    b.Property<string>("uid")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("s_no");

                    b.HasIndex("pid");

                    b.HasIndex("tid");

                    b.ToTable("CourseModels");
                });

            modelBuilder.Entity("mis_mmc.Models.ExamDetailsModel", b =>
                {
                    b.Property<int>("s_no")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("cid")
                        .HasColumnType("int");

                    b.Property<int>("eid")
                        .HasColumnType("int");

                    b.Property<DateOnly>("exam_date")
                        .HasColumnType("date");

                    b.Property<int>("full_marks")
                        .HasColumnType("int");

                    b.Property<int>("pass_marks")
                        .HasColumnType("int");

                    b.Property<TimeOnly>("time")
                        .HasColumnType("time(6)");

                    b.HasKey("s_no");

                    b.HasIndex("cid");

                    b.HasIndex("eid");

                    b.ToTable("ExamDetailsModels");
                });

            modelBuilder.Entity("mis_mmc.Models.ExamModel", b =>
                {
                    b.Property<int>("s_no")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateOnly>("end_date")
                        .HasColumnType("date");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("pid")
                        .HasColumnType("int");

                    b.Property<string>("sem_year")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("start_date")
                        .HasColumnType("date");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("s_no");

                    b.HasIndex("pid");

                    b.ToTable("ExamModels");
                });

            modelBuilder.Entity("mis_mmc.Models.FacultyModel", b =>
                {
                    b.Property<int>("s_no")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("file")
                        .HasColumnType("longtext");

                    b.Property<string>("hod")
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("s_no");

                    b.ToTable("FacultyModels");
                });

            modelBuilder.Entity("mis_mmc.Models.LmsModel", b =>
                {
                    b.Property<int>("s_no")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("cid")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("file")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("published_date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("tid")
                        .HasColumnType("int");

                    b.HasKey("s_no");

                    b.HasIndex("cid");

                    b.HasIndex("tid");

                    b.ToTable("LmsModels");
                });

            modelBuilder.Entity("mis_mmc.Models.LoginModel", b =>
                {
                    b.Property<int>("uid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("uid");

                    b.ToTable("LoginModels");
                });

            modelBuilder.Entity("mis_mmc.Models.NtStaffsModel", b =>
                {
                    b.Property<int>("s_no")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("dob")
                        .HasColumnType("date");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("file")
                        .HasColumnType("longtext");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("phone")
                        .HasColumnType("int");

                    b.Property<int>("post")
                        .HasColumnType("int");

                    b.Property<string>("uid")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("s_no");

                    b.ToTable("NtStaffsModels");
                });

            modelBuilder.Entity("mis_mmc.Models.ProgramModel", b =>
                {
                    b.Property<int>("s_no")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("director")
                        .HasColumnType("longtext");

                    b.Property<int>("fid")
                        .HasColumnType("int");

                    b.Property<string>("file")
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("sem_year")
                        .HasColumnType("int");

                    b.Property<string>("system")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("s_no");

                    b.HasIndex("fid");

                    b.ToTable("ProgramModels");
                });

            modelBuilder.Entity("mis_mmc.Models.StudentModel", b =>
                {
                    b.Property<int>("s_no")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("dob")
                        .HasColumnType("date");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("file")
                        .HasColumnType("longtext");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("is_admitted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("phone")
                        .HasColumnType("int");

                    b.Property<int?>("pid")
                        .HasColumnType("int");

                    b.Property<int?>("roll_no")
                        .HasColumnType("int");

                    b.Property<int>("sem_year")
                        .HasColumnType("int");

                    b.Property<string>("uid")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("s_no");

                    b.HasIndex("pid");

                    b.ToTable("StudentModels");
                });

            modelBuilder.Entity("mis_mmc.Models.TeacherModel", b =>
                {
                    b.Property<int>("s_no")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("dob")
                        .HasColumnType("date");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("file")
                        .HasColumnType("longtext");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("phone")
                        .HasColumnType("int");

                    b.Property<string>("uid")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("s_no");

                    b.ToTable("TeacherModels");
                });

            modelBuilder.Entity("mis_mmc.Models.AssignmentModel", b =>
                {
                    b.HasOne("mis_mmc.Models.CourseModel", "CourseModel")
                        .WithMany()
                        .HasForeignKey("cid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mis_mmc.Models.TeacherModel", "TeacherModel")
                        .WithMany()
                        .HasForeignKey("tid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseModel");

                    b.Navigation("TeacherModel");
                });

            modelBuilder.Entity("mis_mmc.Models.AssignmentReturnModel", b =>
                {
                    b.HasOne("mis_mmc.Models.AssignmentModel", "AssignmentModel")
                        .WithMany("AssignmentReturnModels")
                        .HasForeignKey("aid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mis_mmc.Models.CourseModel", "CourseModel")
                        .WithMany()
                        .HasForeignKey("cid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mis_mmc.Models.StudentModel", "StudentModel")
                        .WithMany()
                        .HasForeignKey("sid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mis_mmc.Models.TeacherModel", "TeacherModel")
                        .WithMany()
                        .HasForeignKey("tid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssignmentModel");

                    b.Navigation("CourseModel");

                    b.Navigation("StudentModel");

                    b.Navigation("TeacherModel");
                });

            modelBuilder.Entity("mis_mmc.Models.BookIssueModel", b =>
                {
                    b.HasOne("mis_mmc.Models.BookModel", "BookModel")
                        .WithMany()
                        .HasForeignKey("bid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mis_mmc.Models.StudentModel", "StudentModel")
                        .WithMany()
                        .HasForeignKey("sid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookModel");

                    b.Navigation("StudentModel");
                });

            modelBuilder.Entity("mis_mmc.Models.BookModel", b =>
                {
                    b.HasOne("mis_mmc.Models.ProgramModel", "ProgramModel")
                        .WithMany("BookModels")
                        .HasForeignKey("pid");

                    b.Navigation("ProgramModel");
                });

            modelBuilder.Entity("mis_mmc.Models.CourseModel", b =>
                {
                    b.HasOne("mis_mmc.Models.ProgramModel", "ProgramModel")
                        .WithMany("CourseModels")
                        .HasForeignKey("pid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mis_mmc.Models.TeacherModel", "TeacherModel")
                        .WithMany()
                        .HasForeignKey("tid");

                    b.Navigation("ProgramModel");

                    b.Navigation("TeacherModel");
                });

            modelBuilder.Entity("mis_mmc.Models.ExamDetailsModel", b =>
                {
                    b.HasOne("mis_mmc.Models.CourseModel", "CourseModel")
                        .WithMany()
                        .HasForeignKey("cid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mis_mmc.Models.ExamModel", "ExamModel")
                        .WithMany("ExamDetailsModels")
                        .HasForeignKey("eid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseModel");

                    b.Navigation("ExamModel");
                });

            modelBuilder.Entity("mis_mmc.Models.ExamModel", b =>
                {
                    b.HasOne("mis_mmc.Models.ProgramModel", "ProgramModel")
                        .WithMany()
                        .HasForeignKey("pid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProgramModel");
                });

            modelBuilder.Entity("mis_mmc.Models.LmsModel", b =>
                {
                    b.HasOne("mis_mmc.Models.CourseModel", "CourseModel")
                        .WithMany()
                        .HasForeignKey("cid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mis_mmc.Models.TeacherModel", "TeacherModel")
                        .WithMany()
                        .HasForeignKey("tid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseModel");

                    b.Navigation("TeacherModel");
                });

            modelBuilder.Entity("mis_mmc.Models.ProgramModel", b =>
                {
                    b.HasOne("mis_mmc.Models.FacultyModel", "FacultyModel")
                        .WithMany("ProgramModels")
                        .HasForeignKey("fid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FacultyModel");
                });

            modelBuilder.Entity("mis_mmc.Models.StudentModel", b =>
                {
                    b.HasOne("mis_mmc.Models.ProgramModel", "ProgramModel")
                        .WithMany("StudentModels")
                        .HasForeignKey("pid");

                    b.Navigation("ProgramModel");
                });

            modelBuilder.Entity("mis_mmc.Models.AssignmentModel", b =>
                {
                    b.Navigation("AssignmentReturnModels");
                });

            modelBuilder.Entity("mis_mmc.Models.ExamModel", b =>
                {
                    b.Navigation("ExamDetailsModels");
                });

            modelBuilder.Entity("mis_mmc.Models.FacultyModel", b =>
                {
                    b.Navigation("ProgramModels");
                });

            modelBuilder.Entity("mis_mmc.Models.ProgramModel", b =>
                {
                    b.Navigation("BookModels");

                    b.Navigation("CourseModels");

                    b.Navigation("StudentModels");
                });
#pragma warning restore 612, 618
        }
    }
}
