﻿// <auto-generated />
using FavourPal.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FavourPal.Domain.Migrations
{
    [DbContext(typeof(FavourPalDbContext))]
    [Migration("20191002141940_romans")]
    partial class romans
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FavourPal.Api.Models.Requests", b =>
                {
                    b.Property<int>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Accepted")
                        .HasColumnType("bit");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int>("RequestFromUser")
                        .HasColumnType("int");

                    b.Property<int>("RequestToUser")
                        .HasColumnType("int");

                    b.HasKey("RequestId");

                    b.HasIndex("RequestFromUser");

                    b.HasIndex("RequestToUser");

                    b.ToTable("Requests","dbo");
                });

            modelBuilder.Entity("FavourPal.Api.Models.Users", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("UserId");

                    b.ToTable("Users","dbo");
                });

            modelBuilder.Entity("FavourPal.Api.Models.Requests", b =>
                {
                    b.HasOne("FavourPal.Api.Models.Users", "RequestFrom")
                        .WithMany("RequestsFrom")
                        .HasForeignKey("RequestFromUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FavourPal.Api.Models.Users", "RequestTo")
                        .WithMany("RequestsTo")
                        .HasForeignKey("RequestToUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
