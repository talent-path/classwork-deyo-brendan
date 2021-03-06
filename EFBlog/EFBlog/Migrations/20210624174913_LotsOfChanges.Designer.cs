﻿// <auto-generated />
using System;
using EFBlog.Repos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFBlog.Migrations
{
    [DbContext(typeof(BlogDbContext))]
    [Migration("20210624174913_LotsOfChanges")]
    partial class LotsOfChanges
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFBlog.Models.BlogPost", b =>
                {
                    b.Property<int>("BlogPostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AuthorBlogUserId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("BlogPostId");

                    b.HasIndex("AuthorBlogUserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("EFBlog.Models.BlogUser", b =>
                {
                    b.Property<int>("BlogUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("BlogUserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EFBlog.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentPostBlogPostId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CommentId");

                    b.HasIndex("ParentPostBlogPostId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("EFBlog.Models.BlogPost", b =>
                {
                    b.HasOne("EFBlog.Models.BlogUser", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorBlogUserId");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("EFBlog.Models.Comment", b =>
                {
                    b.HasOne("EFBlog.Models.BlogPost", "ParentPost")
                        .WithMany("Comments")
                        .HasForeignKey("ParentPostBlogPostId");

                    b.Navigation("ParentPost");
                });

            modelBuilder.Entity("EFBlog.Models.BlogPost", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
