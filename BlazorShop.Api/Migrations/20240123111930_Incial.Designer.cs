﻿// <auto-generated />
using BlazorShop.Api.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorShop.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240123111930_Incial")]
    partial class Incial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlazorShop.Api.Entities.Carrinho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("Carrinhos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            UsuarioId = 1
                        },
                        new
                        {
                            Id = 2,
                            UsuarioId = 2
                        });
                });

            modelBuilder.Entity("BlazorShop.Api.Entities.CarrinhoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarrinhoId")
                        .HasColumnType("int");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarrinhoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("CarrinhoItens");
                });

            modelBuilder.Entity("BlazorShop.Api.Entities.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("IconCSS")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Categorias");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IconCSS = "fas fa-spa",
                            Nome = "Beleza"
                        },
                        new
                        {
                            Id = 2,
                            IconCSS = "fas fa-couch",
                            Nome = "Moveis"
                        },
                        new
                        {
                            Id = 3,
                            IconCSS = "fas fa-headphones",
                            Nome = "Eletronicos"
                        },
                        new
                        {
                            Id = 4,
                            IconCSS = "fas fa-shoe-prints",
                            Nome = "Calcados"
                        });
                });

            modelBuilder.Entity("BlazorShop.Api.Entities.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ImagemUrl")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Produtos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoriaId = 1,
                            Descricao = "Um kit fornecido pela Natura, contendo produtos para cuidados com a pele",
                            ImagemUrl = "/Imagens/Beleza/Beleza1.png",
                            Nome = "Glossier - Beleza Kit",
                            Preco = 100m,
                            Quantidade = 100
                        },
                        new
                        {
                            Id = 2,
                            CategoriaId = 1,
                            Descricao = "Um kit fornecido pela Curology, contendo produtos para cuidados com a pele",
                            ImagemUrl = "/Imagens/Beleza/Beleza2.png",
                            Nome = "Curology - Kit para Pele",
                            Preco = 50m,
                            Quantidade = 45
                        },
                        new
                        {
                            Id = 3,
                            CategoriaId = 1,
                            Descricao = "Um kit fornecido pela Glossier, contendo produtos para cuidados com a pele",
                            ImagemUrl = "/Imagens/Beleza/Beleza3.png",
                            Nome = "Óleo de Coco Orgânico",
                            Preco = 20m,
                            Quantidade = 30
                        },
                        new
                        {
                            Id = 4,
                            CategoriaId = 1,
                            Descricao = "Um kit fornecido pela Curology, contendo produtos para cuidados com a pele",
                            ImagemUrl = "/Imagens/Beleza/Beleza4.png",
                            Nome = "Schwarzkopf - Kit de cuidados com a pele e cabelo",
                            Preco = 50m,
                            Quantidade = 60
                        },
                        new
                        {
                            Id = 5,
                            CategoriaId = 1,
                            Descricao = "Kit de cuidados com a pele, contendo produtos para cuidados com a pele e cabelos",
                            ImagemUrl = "/Imagens/Beleza/Beleza5.png",
                            Nome = "Kit de cuidados com a pele",
                            Preco = 30m,
                            Quantidade = 85
                        },
                        new
                        {
                            Id = 6,
                            CategoriaId = 3,
                            Descricao = "Air Pods - fones de ouvido sem fio intra-auriculares",
                            ImagemUrl = "/Imagens/Eletronicos/eletronico1.png",
                            Nome = "Fones de ouvidos",
                            Preco = 100m,
                            Quantidade = 120
                        },
                        new
                        {
                            Id = 7,
                            CategoriaId = 3,
                            Descricao = "Fones de ouvido dourados na orelha - esses fones de ouvido não são sem fio",
                            ImagemUrl = "/Imagens/Eletronicos/eletronico2.png",
                            Nome = "Fones de ouvido dourados",
                            Preco = 40m,
                            Quantidade = 200
                        },
                        new
                        {
                            Id = 8,
                            CategoriaId = 3,
                            Descricao = "Fones de ouvido pretos na orelha - esses fones de ouvido não são sem fio",
                            ImagemUrl = "/Imagens/Eletronicos/eletronico3.png",
                            Nome = "Fones de ouvido pretos",
                            Preco = 40m,
                            Quantidade = 300
                        },
                        new
                        {
                            Id = 9,
                            CategoriaId = 3,
                            Descricao = "Câmera Digital Sennheiser - Câmera digital de alta qualidade fornecida pela Sennheiser - inclui tripé",
                            ImagemUrl = "/Imagens/Eletronicos/eletronico4.png",
                            Nome = "Câmera digital Sennheiser com tripé",
                            Preco = 600m,
                            Quantidade = 20
                        },
                        new
                        {
                            Id = 10,
                            CategoriaId = 3,
                            Descricao = "Canon Digital Camera - Câmera digital de alta qualidade fornecida pela Canon",
                            ImagemUrl = "/Imagens/Eletronicos/eletronico5.png",
                            Nome = "Câmera Digital Canon",
                            Preco = 500m,
                            Quantidade = 15
                        },
                        new
                        {
                            Id = 11,
                            CategoriaId = 3,
                            Descricao = "Gameboy - Fornecido por Nintendo",
                            ImagemUrl = "/Imagens/Eletronicos/tecnologia6.png",
                            Nome = "Nintendo Gameboy",
                            Preco = 100m,
                            Quantidade = 60
                        },
                        new
                        {
                            Id = 12,
                            CategoriaId = 2,
                            Descricao = "Cadeira de escritório em couro preto muito confortável",
                            ImagemUrl = "/Imagens/Moveis/moveis1.png",
                            Nome = "Cadeira de escritório de couro preto",
                            Preco = 50m,
                            Quantidade = 212
                        },
                        new
                        {
                            Id = 13,
                            CategoriaId = 2,
                            Descricao = "Cadeira de escritório em couro rosa muito confortável",
                            ImagemUrl = "/Imagens/Moveis/moveis2.png",
                            Nome = "Cadeira de escritório de couro rosa",
                            Preco = 50m,
                            Quantidade = 112
                        },
                        new
                        {
                            Id = 14,
                            CategoriaId = 2,
                            Descricao = "Poltrona muito confortável",
                            ImagemUrl = "/Imagens/Moveis/moveis3.png",
                            Nome = "Espreguiçadeira",
                            Preco = 70m,
                            Quantidade = 90
                        },
                        new
                        {
                            Id = 15,
                            CategoriaId = 2,
                            Descricao = "Poltrona prateada muito confortável",
                            ImagemUrl = "/Imagens/Moveis/moveis4.png",
                            Nome = "Silver Lounge Chair",
                            Preco = 120m,
                            Quantidade = 95
                        },
                        new
                        {
                            Id = 16,
                            CategoriaId = 2,
                            Descricao = "Abajur de mesa de porcelana branco e azul",
                            ImagemUrl = "/Imagens/Moveis/moveis6.png",
                            Nome = "Luminária de mesa de porcelana",
                            Preco = 15m,
                            Quantidade = 100
                        },
                        new
                        {
                            Id = 17,
                            CategoriaId = 2,
                            Descricao = "Abajur de mesa de escritório",
                            ImagemUrl = "/Imagens/Moveis/moveis7.png",
                            Nome = "Office Table Lamp",
                            Preco = 20m,
                            Quantidade = 73
                        },
                        new
                        {
                            Id = 18,
                            CategoriaId = 4,
                            Descricao = "Tênis Puma confortáveis na maioria dos tamanhos",
                            ImagemUrl = "/Imagens/Calcados/calcado1.png",
                            Nome = "Tênis Puma",
                            Preco = 100m,
                            Quantidade = 50
                        },
                        new
                        {
                            Id = 19,
                            CategoriaId = 4,
                            Descricao = "Tênis coloridos - disponíveis na maioria dos tamanhos",
                            ImagemUrl = "/Imagens/Calcados/calcado2.png",
                            Nome = "Tênis Colodiros",
                            Preco = 150m,
                            Quantidade = 60
                        },
                        new
                        {
                            Id = 20,
                            CategoriaId = 4,
                            Descricao = "Tênis Nike azul - disponível na maioria dos tamanhos",
                            ImagemUrl = "/Imagens/Calcados/calcado3.png",
                            Nome = "Tênis Nike Azul",
                            Preco = 200m,
                            Quantidade = 70
                        },
                        new
                        {
                            Id = 21,
                            CategoriaId = 4,
                            Descricao = "Treinadores Hummel coloridos - disponíveis na maioria dos tamanhos",
                            ImagemUrl = "/Imagens/Calcados/calcado4.png",
                            Nome = "Tênis Hummel Coloridos",
                            Preco = 120m,
                            Quantidade = 120
                        },
                        new
                        {
                            Id = 22,
                            CategoriaId = 4,
                            Descricao = "Tênis Nike vermelho - disponível na maioria dos tamanhos",
                            ImagemUrl = "/Imagens/Calcados/calcado5.png",
                            Nome = "Tênis Nike Vermelho",
                            Preco = 200m,
                            Quantidade = 100
                        },
                        new
                        {
                            Id = 23,
                            CategoriaId = 4,
                            Descricao = "Sandálias Birkenstock - disponíveis na maioria dos tamanhos",
                            ImagemUrl = "/Imagens/Calcados/calcado6.png",
                            Nome = "Sandálidas Birkenstock",
                            Preco = 50m,
                            Quantidade = 150
                        });
                });

            modelBuilder.Entity("BlazorShop.Api.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NomeUsuario")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NomeUsuario = "Macoratti"
                        },
                        new
                        {
                            Id = 2,
                            NomeUsuario = "Janice"
                        });
                });

            modelBuilder.Entity("BlazorShop.Api.Entities.Carrinho", b =>
                {
                    b.HasOne("BlazorShop.Api.Entities.Usuario", null)
                        .WithOne("Carrinho")
                        .HasForeignKey("BlazorShop.Api.Entities.Carrinho", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BlazorShop.Api.Entities.CarrinhoItem", b =>
                {
                    b.HasOne("BlazorShop.Api.Entities.Carrinho", "Carrinho")
                        .WithMany("Itens")
                        .HasForeignKey("CarrinhoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorShop.Api.Entities.Produto", "Produto")
                        .WithMany("Itens")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carrinho");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("BlazorShop.Api.Entities.Produto", b =>
                {
                    b.HasOne("BlazorShop.Api.Entities.Categoria", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("BlazorShop.Api.Entities.Carrinho", b =>
                {
                    b.Navigation("Itens");
                });

            modelBuilder.Entity("BlazorShop.Api.Entities.Categoria", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("BlazorShop.Api.Entities.Produto", b =>
                {
                    b.Navigation("Itens");
                });

            modelBuilder.Entity("BlazorShop.Api.Entities.Usuario", b =>
                {
                    b.Navigation("Carrinho");
                });
#pragma warning restore 612, 618
        }
    }
}
