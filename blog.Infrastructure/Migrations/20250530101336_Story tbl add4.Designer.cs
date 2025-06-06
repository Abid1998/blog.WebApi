﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using blog.Infrastructure.DatabaseContext;

#nullable disable

namespace blog.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250530101336_Story tbl add4")]
    partial class Storytbladd4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Tutorial", b =>
                {
                    b.Property<int>("tutorial_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("tutorial_id"));

                    b.Property<int>("category_id")
                        .HasColumnType("int");

                    b.Property<DateOnly>("created_at")
                        .HasColumnType("date");

                    b.Property<int>("created_by")
                        .HasColumnType("int");

                    b.Property<string>("schedule")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("tutorial_image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tutorial_meta")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("tutorial_slug")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("tutorial_title")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<DateOnly?>("updated_at")
                        .HasColumnType("date");

                    b.Property<int?>("updated_by")
                        .HasColumnType("int");

                    b.HasKey("tutorial_id");

                    b.HasIndex("category_id");

                    b.ToTable("TblTutorial");
                });

            modelBuilder.Entity("blog.Core.Entities.Categories", b =>
                {
                    b.Property<int>("category_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("category_id"));

                    b.Property<string>("category_description")
                        .HasColumnType("varchar(MAX)");

                    b.Property<string>("category_image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("category_meta")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("category_name")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("category_slug")
                        .HasColumnType("varchar(60)");

                    b.Property<string>("category_tags")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("category_type")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<DateOnly>("created_at")
                        .HasColumnType("date");

                    b.Property<int>("created_by")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<DateOnly?>("updated_at")
                        .HasColumnType("date");

                    b.Property<int?>("updated_by")
                        .HasColumnType("int");

                    b.HasKey("category_id");

                    b.ToTable("TblCategories");
                });

            modelBuilder.Entity("blog.Core.Entities.Comment", b =>
                {
                    b.Property<int>("comment_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("comment_id"));

                    b.Property<string>("comment_email")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("comment_message")
                        .HasColumnType("varchar(300)");

                    b.Property<string>("comment_name")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("comment_phone")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("comment_reply")
                        .HasColumnType("varchar(300)");

                    b.Property<string>("comment_url")
                        .HasColumnType("varchar(50)");

                    b.Property<DateOnly>("created_at")
                        .HasColumnType("date");

                    b.Property<int>("created_by")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<int?>("tutorial_id")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateOnly?>("updated_at")
                        .HasColumnType("date");

                    b.Property<int?>("updated_by")
                        .HasColumnType("int");

                    b.HasKey("comment_id");

                    b.ToTable("TblComment");
                });

            modelBuilder.Entity("blog.Core.Entities.Gallery", b =>
                {
                    b.Property<int>("gallery_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("gallery_id"));

                    b.Property<string>("gallery_img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("tutorial_id")
                        .HasColumnType("int");

                    b.HasKey("gallery_id");

                    b.HasIndex("tutorial_id");

                    b.ToTable("TblGallery");
                });

            modelBuilder.Entity("blog.Core.Entities.Tags", b =>
                {
                    b.Property<int>("tag_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("tag_id"));

                    b.Property<string>("tag_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("tutorial_id")
                        .HasColumnType("int");

                    b.HasKey("tag_id");

                    b.HasIndex("tutorial_id");

                    b.ToTable("TblTags");
                });

            modelBuilder.Entity("blog.Core.Entities.Tutorial_Details", b =>
                {
                    b.Property<int>("tutorial_details_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("tutorial_details_id"));

                    b.Property<string>("languages")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tutorial_description")
                        .HasColumnType("varchar(200)");

                    b.Property<int>("tutorial_id")
                        .HasColumnType("int");

                    b.HasKey("tutorial_details_id");

                    b.HasIndex("tutorial_id");

                    b.ToTable("TblTutorial_Details");
                });

            modelBuilder.Entity("blog.Core.Entities.WebStory", b =>
                {
                    b.Property<int>("story_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("story_id"));

                    b.Property<string>("cover_image_url")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateOnly>("created_at")
                        .HasColumnType("date");

                    b.Property<int>("created_by")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .HasColumnType("text");

                    b.Property<string>("schedule")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("slug")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateOnly?>("updated_at")
                        .HasColumnType("date");

                    b.Property<int?>("updated_by")
                        .HasColumnType("int");

                    b.HasKey("story_id");

                    b.ToTable("TblWebStory");
                });

            modelBuilder.Entity("blog.Core.Entities.WebStoryPage", b =>
                {
                    b.Property<int>("page_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("page_id"));

                    b.Property<string>("image_url")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("story_id")
                        .HasColumnType("int");

                    b.Property<string>("text_content")
                        .HasColumnType("text");

                    b.HasKey("page_id");

                    b.HasIndex("story_id");

                    b.ToTable("TblWebStoryPage");
                });

            modelBuilder.Entity("Tutorial", b =>
                {
                    b.HasOne("blog.Core.Entities.Categories", "Category")
                        .WithMany()
                        .HasForeignKey("category_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("blog.Core.Entities.Gallery", b =>
                {
                    b.HasOne("Tutorial", "Tutorial")
                        .WithMany("galleries")
                        .HasForeignKey("tutorial_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tutorial");
                });

            modelBuilder.Entity("blog.Core.Entities.Tags", b =>
                {
                    b.HasOne("Tutorial", "Tutorial")
                        .WithMany("tags")
                        .HasForeignKey("tutorial_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tutorial");
                });

            modelBuilder.Entity("blog.Core.Entities.Tutorial_Details", b =>
                {
                    b.HasOne("Tutorial", "Tutorial")
                        .WithMany("TutorialDetails")
                        .HasForeignKey("tutorial_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tutorial");
                });

            modelBuilder.Entity("blog.Core.Entities.WebStoryPage", b =>
                {
                    b.HasOne("blog.Core.Entities.WebStory", "WebStory")
                        .WithMany("WebStoryPage")
                        .HasForeignKey("story_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WebStory");
                });

            modelBuilder.Entity("Tutorial", b =>
                {
                    b.Navigation("TutorialDetails");

                    b.Navigation("galleries");

                    b.Navigation("tags");
                });

            modelBuilder.Entity("blog.Core.Entities.WebStory", b =>
                {
                    b.Navigation("WebStoryPage");
                });
#pragma warning restore 612, 618
        }
    }
}
