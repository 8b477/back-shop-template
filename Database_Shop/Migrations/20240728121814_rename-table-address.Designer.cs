﻿// <auto-generated />
using System;
using Database_Shop.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Database_Shop.Migrations
{
    [DbContext(typeof(ShopDB))]
    [Migration("20240728121814_rename-table-address")]
    partial class renametableaddress
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("Database_Shop.Entity.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(85)
                        .HasColumnType("TEXT")
                        .HasColumnName("City")
                        .HasComment("Ville");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("TEXT")
                        .HasColumnName("Country")
                        .HasComment("Pays");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT")
                        .HasColumnName("PhoneNumber")
                        .HasComment("Numéro de téléphone");

                    b.Property<int>("PostalCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValue(0)
                        .HasColumnName("PostalCode")
                        .HasComment("Code postal");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("StreetName")
                        .HasComment("Nom de rue");

                    b.Property<int>("StreetNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValue(0)
                        .HasColumnName("StreetNumber")
                        .HasComment("Numéro de rue");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Addresse", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Charleroi",
                            Country = "Belgique",
                            PhoneNumber = "",
                            PostalCode = 6000,
                            StreetName = "rue de la Force",
                            StreetNumber = 10,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            City = "Lille",
                            Country = "France",
                            PhoneNumber = "0687654321",
                            PostalCode = 69001,
                            StreetName = "rue des fous",
                            StreetNumber = 5,
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            City = "Nismes",
                            Country = "Belgique",
                            PhoneNumber = "",
                            PostalCode = 5670,
                            StreetName = "rue longue",
                            StreetNumber = 5,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("Database_Shop.Entity.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("REAL")
                        .HasDefaultValue(0.0);

                    b.Property<bool>("Promo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(false);

                    b.Property<int>("Stock")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.ToTable("Article");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Tomate",
                            Price = 0.25,
                            Promo = false,
                            Stock = 100
                        },
                        new
                        {
                            Id = 2,
                            Name = "Banane",
                            Price = 1.3,
                            Promo = true,
                            Stock = 50
                        },
                        new
                        {
                            Id = 3,
                            Name = "Vodka",
                            Price = 14.949999999999999,
                            Promo = false,
                            Stock = 20
                        },
                        new
                        {
                            Id = 4,
                            Name = "Chips Lays Nature",
                            Price = 2.9500000000000002,
                            Promo = false,
                            Stock = 10
                        },
                        new
                        {
                            Id = 5,
                            Name = "Chips Lays Paprika",
                            Price = 4.9900000000000002,
                            Promo = false,
                            Stock = 200
                        },
                        new
                        {
                            Id = 6,
                            Name = "Fritte",
                            Price = 4.9900000000000002,
                            Promo = false,
                            Stock = 200
                        },
                        new
                        {
                            Id = 7,
                            Name = "Thon",
                            Price = 3.9500000000000002,
                            Promo = false,
                            Stock = 15
                        });
                });

            modelBuilder.Entity("Database_Shop.Entity.ArticleCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArticleId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ArticleCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArticleId = 1,
                            CategoryId = 4
                        },
                        new
                        {
                            Id = 2,
                            ArticleId = 1,
                            CategoryId = 6
                        },
                        new
                        {
                            Id = 3,
                            ArticleId = 1,
                            CategoryId = 7
                        },
                        new
                        {
                            Id = 4,
                            ArticleId = 2,
                            CategoryId = 4
                        },
                        new
                        {
                            Id = 5,
                            ArticleId = 2,
                            CategoryId = 7
                        },
                        new
                        {
                            Id = 6,
                            ArticleId = 3,
                            CategoryId = 1
                        },
                        new
                        {
                            Id = 7,
                            ArticleId = 3,
                            CategoryId = 2
                        },
                        new
                        {
                            Id = 8,
                            ArticleId = 4,
                            CategoryId = 3
                        },
                        new
                        {
                            Id = 9,
                            ArticleId = 4,
                            CategoryId = 8
                        },
                        new
                        {
                            Id = 10,
                            ArticleId = 5,
                            CategoryId = 3
                        },
                        new
                        {
                            Id = 11,
                            ArticleId = 5,
                            CategoryId = 8
                        },
                        new
                        {
                            Id = 12,
                            ArticleId = 6,
                            CategoryId = 5
                        },
                        new
                        {
                            Id = 13,
                            ArticleId = 7,
                            CategoryId = 9
                        });
                });

            modelBuilder.Entity("Database_Shop.Entity.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Boisson"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Alcool"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Snack"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Frais"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Surgeler"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Légume"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Fruit"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Sec"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Conserve"
                        });
                });

            modelBuilder.Entity("Database_Shop.Entity.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("SentAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SentAt = new DateTime(2023, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Livré",
                            UserId = 2
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2023, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "En attente",
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2023, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "En attente",
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2023, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SentAt = new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Livré",
                            UserId = 4
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2023, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SentAt = new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Livré",
                            UserId = 4
                        });
                });

            modelBuilder.Entity("Database_Shop.Entity.OrderArticle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArticleId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderArticle");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArticleId = 1,
                            OrderId = 1
                        },
                        new
                        {
                            Id = 2,
                            ArticleId = 1,
                            OrderId = 2
                        },
                        new
                        {
                            Id = 3,
                            ArticleId = 2,
                            OrderId = 2
                        },
                        new
                        {
                            Id = 4,
                            ArticleId = 1,
                            OrderId = 3
                        },
                        new
                        {
                            Id = 5,
                            ArticleId = 2,
                            OrderId = 3
                        },
                        new
                        {
                            Id = 6,
                            ArticleId = 3,
                            OrderId = 3
                        },
                        new
                        {
                            Id = 7,
                            ArticleId = 1,
                            OrderId = 4
                        },
                        new
                        {
                            Id = 8,
                            ArticleId = 2,
                            OrderId = 4
                        },
                        new
                        {
                            Id = 9,
                            ArticleId = 3,
                            OrderId = 4
                        },
                        new
                        {
                            Id = 10,
                            ArticleId = 4,
                            OrderId = 4
                        },
                        new
                        {
                            Id = 11,
                            ArticleId = 1,
                            OrderId = 5
                        },
                        new
                        {
                            Id = 12,
                            ArticleId = 2,
                            OrderId = 5
                        },
                        new
                        {
                            Id = 13,
                            ArticleId = 3,
                            OrderId = 5
                        },
                        new
                        {
                            Id = 14,
                            ArticleId = 4,
                            OrderId = 5
                        },
                        new
                        {
                            Id = 15,
                            ArticleId = 5,
                            OrderId = 5
                        },
                        new
                        {
                            Id = 16,
                            ArticleId = 6,
                            OrderId = 5
                        },
                        new
                        {
                            Id = 17,
                            ArticleId = 7,
                            OrderId = 5
                        });
                });

            modelBuilder.Entity("Database_Shop.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Pseudo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Pwd")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Mail = "admin@mail.be",
                            Pseudo = "admin",
                            Pwd = "$2a$11$JH3NvMdgD3yud4ygjab/5.R8Ejaf6q2msKAGLCodqmxCAR4UB9Mnu",
                            Role = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Mail = "user@mail.be",
                            Pseudo = "user",
                            Pwd = "$2a$11$1qdMP5pesSwBxAUlsq/uh.LgbK/TakB7KZrk8auIu7lPNplF7hwv6",
                            Role = "User"
                        },
                        new
                        {
                            Id = 3,
                            Mail = "user2@mail.be",
                            Pseudo = "user2",
                            Pwd = "$2a$11$wnGuUMwp0quJIB87tV76duG5TLUNKZc6waGxYxOdVPSdaErVuCBEq",
                            Role = "User"
                        },
                        new
                        {
                            Id = 4,
                            Mail = "user3@mail.be",
                            Pseudo = "user3",
                            Pwd = "$2a$11$3NAL5bC.viRwzvFY0bK/EOrzv7KIR7/xNMqki1QtJydF5HTVapNPa",
                            Role = "User"
                        },
                        new
                        {
                            Id = 5,
                            Mail = "user4@mail.be",
                            Pseudo = "user4",
                            Pwd = "$2a$11$.7XQfmZNHL/JeD8ltPeQu.C891RcLK/Kt..INYPc.FjGZnfktcZOe",
                            Role = "User"
                        });
                });

            modelBuilder.Entity("Database_Shop.Entity.Address", b =>
                {
                    b.HasOne("Database_Shop.Entity.User", "User")
                        .WithOne("Address")
                        .HasForeignKey("Database_Shop.Entity.Address", "UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Database_Shop.Entity.ArticleCategory", b =>
                {
                    b.HasOne("Database_Shop.Entity.Article", "Article")
                        .WithMany("ArticleCategories")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database_Shop.Entity.Category", "Category")
                        .WithMany("ArticleCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Database_Shop.Entity.Order", b =>
                {
                    b.HasOne("Database_Shop.Entity.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Database_Shop.Entity.OrderArticle", b =>
                {
                    b.HasOne("Database_Shop.Entity.Article", "Article")
                        .WithMany("OrdersArticles")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database_Shop.Entity.Order", "Order")
                        .WithMany("OrderArticles")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Database_Shop.Entity.Article", b =>
                {
                    b.Navigation("ArticleCategories");

                    b.Navigation("OrdersArticles");
                });

            modelBuilder.Entity("Database_Shop.Entity.Category", b =>
                {
                    b.Navigation("ArticleCategories");
                });

            modelBuilder.Entity("Database_Shop.Entity.Order", b =>
                {
                    b.Navigation("OrderArticles");
                });

            modelBuilder.Entity("Database_Shop.Entity.User", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
