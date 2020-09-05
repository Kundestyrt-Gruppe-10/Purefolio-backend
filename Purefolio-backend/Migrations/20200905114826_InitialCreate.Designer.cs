﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Purefolio.DatabaseContext;

namespace Purefolio_backend.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20200905114826_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Purefolio.DatabaseContext.Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("blog_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Url")
                        .HasColumnName("url")
                        .HasColumnType("text");

                    b.HasKey("BlogId")
                        .HasName("pk_blogs");

                    b.ToTable("blogs");
                });

            modelBuilder.Entity("Purefolio.DatabaseContext.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("post_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("BlogId")
                        .HasColumnName("blog_id")
                        .HasColumnType("integer");

                    b.Property<string>("Content")
                        .HasColumnName("content")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnName("title")
                        .HasColumnType("text");

                    b.HasKey("PostId")
                        .HasName("pk_posts");

                    b.HasIndex("BlogId")
                        .HasName("ix_posts_blog_id");

                    b.ToTable("posts");
                });

            modelBuilder.Entity("Purefolio.DatabaseContext.Post", b =>
                {
                    b.HasOne("Purefolio.DatabaseContext.Blog", "Blog")
                        .WithMany("Posts")
                        .HasForeignKey("BlogId")
                        .HasConstraintName("fk_posts_blogs_blog_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}