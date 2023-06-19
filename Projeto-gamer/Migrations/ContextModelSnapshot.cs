﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projeto_gamer.Infra;

#nullable disable

namespace Projeto_gamer.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.1.23111.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Projeto_gamer.Models.Equipe", b =>
                {
                    b.Property<int>("IdEquipe")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEquipe"));

                    b.Property<string>("Imagem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEquipe");

                    b.ToTable("Equipe");
                });

            modelBuilder.Entity("Projeto_gamer.Models.Jogador", b =>
                {
                    b.Property<int>("IdJogador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdJogador"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdEquipe")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdJogador");

                    b.HasIndex("IdEquipe");

                    b.ToTable("jogador");
                });

            modelBuilder.Entity("Projeto_gamer.Models.Jogador", b =>
                {
                    b.HasOne("Projeto_gamer.Models.Equipe", "Equipe")
                        .WithMany("Jogador")
                        .HasForeignKey("IdEquipe")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipe");
                });

            modelBuilder.Entity("Projeto_gamer.Models.Equipe", b =>
                {
                    b.Navigation("Jogador");
                });
#pragma warning restore 612, 618
        }
    }
}
