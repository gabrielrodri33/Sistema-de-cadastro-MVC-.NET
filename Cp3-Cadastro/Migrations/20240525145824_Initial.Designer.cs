﻿// <auto-generated />
using Cp3_Cadastro.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace Cp3_Cadastro.Migrations
{
    [DbContext(typeof(OracleDbContext))]
    [Migration("20240525145824_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Cp3_Cadastro.Models.EnderecoModel", b =>
                {
                    b.Property<int>("id_endereco")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_endereco"));

                    b.Property<string>("bairro_endereco")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("cep_endereco")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("cidade_endereco")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("complemento_endereco")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("estado_endereco")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("id_pessoa")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("pessoaid_pessoa")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("rua_endereco")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("id_endereco");

                    b.HasIndex("pessoaid_pessoa");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("Cp3_Cadastro.Models.PessoaModel", b =>
                {
                    b.Property<int>("id_pessoa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_pessoa"));

                    b.Property<string>("cpf_pessoa")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("email_pessoa")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("nome_pessoa")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("senha_pessoa")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("id_pessoa");

                    b.ToTable("Pessoa");
                });

            modelBuilder.Entity("Cp3_Cadastro.Models.EnderecoModel", b =>
                {
                    b.HasOne("Cp3_Cadastro.Models.PessoaModel", "pessoa")
                        .WithMany("endereco")
                        .HasForeignKey("pessoaid_pessoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("pessoa");
                });

            modelBuilder.Entity("Cp3_Cadastro.Models.PessoaModel", b =>
                {
                    b.Navigation("endereco");
                });
#pragma warning restore 612, 618
        }
    }
}