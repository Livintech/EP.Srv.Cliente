﻿// <auto-generated />
using System;
using EP.Srv.Cliente.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EP.Srv.Cliente.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EP.Srv.Cliente.Domain.Entities.Banco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Agencia")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("AtualizadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<int>("Conta")
                        .HasColumnType("int");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataSaldoInicio")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<string>("Instituicao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal?>("SaldoInicial")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Bancos", (string)null);
                });

            modelBuilder.Entity("EP.Srv.Cliente.Domain.Entities.CentroCustos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("AtualizadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CodigoEmpresa")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("CentroCustos", (string)null);
                });

            modelBuilder.Entity("EP.Srv.Cliente.Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("AtualizadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CodigoEmpresa")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DataSituacao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NomeRazao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Clientes", (string)null);
                });

            modelBuilder.Entity("EP.Srv.Cliente.Domain.Entities.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("AtualizadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DataSituacao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NomeRazao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Empresas", (string)null);
                });

            modelBuilder.Entity("EP.Srv.Cliente.Domain.Entities.FormaPagamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("AtualizadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CodigoEmpresa")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("FormasPagamentos", (string)null);
                });

            modelBuilder.Entity("EP.Srv.Cliente.Domain.Entities.PlanoContas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("AtualizadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CodigoEmpresa")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Natureza")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TipoNatureza")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("PlanoContas", (string)null);
                });

            modelBuilder.Entity("EP.Srv.Cliente.Domain.Entities.ProdutosServicos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("AtualizadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CodigoEmpresa")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("ProdutosServicos", (string)null);
                });

            modelBuilder.Entity("EP.Srv.Cliente.Domain.Entities.Banco", b =>
                {
                    b.HasOne("EP.Srv.Cliente.Domain.Entities.Empresa", "Empresa")
                        .WithMany("Bancos")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("EP.Srv.Cliente.Domain.Entities.CentroCustos", b =>
                {
                    b.HasOne("EP.Srv.Cliente.Domain.Entities.Empresa", "Empresa")
                        .WithMany("CentroCustos")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("EP.Srv.Cliente.Domain.Entities.Cliente", b =>
                {
                    b.HasOne("EP.Srv.Cliente.Domain.Entities.Empresa", "Empresa")
                        .WithMany("Clientes")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("EP.Srv.Cliente.Domain.Entities.FormaPagamento", b =>
                {
                    b.HasOne("EP.Srv.Cliente.Domain.Entities.Empresa", "Empresa")
                        .WithMany("FormaPagamentos")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("EP.Srv.Cliente.Domain.Entities.ProdutosServicos", b =>
                {
                    b.HasOne("EP.Srv.Cliente.Domain.Entities.Empresa", "Empresa")
                        .WithMany("ProdutosServicos")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("EP.Srv.Cliente.Domain.Entities.Empresa", b =>
                {
                    b.Navigation("Bancos");

                    b.Navigation("CentroCustos");

                    b.Navigation("Clientes");

                    b.Navigation("FormaPagamentos");

                    b.Navigation("ProdutosServicos");
                });
#pragma warning restore 612, 618
        }
    }
}
