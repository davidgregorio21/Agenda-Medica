﻿// <auto-generated />
using System;
using AgendaMedica.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AgendaMedica.Data.Migrations
{
    [DbContext(typeof(AgendaMedicaDbContext))]
    partial class AgendaMedicaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AgendaMedica.Domain.Entities.Agenda", b =>
                {
                    b.Property<int>("AgendaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataHoraFim");

                    b.Property<DateTime>("DataHoraInicio");

                    b.Property<int>("ProfissionalId");

                    b.HasKey("AgendaId");

                    b.HasIndex("ProfissionalId");

                    b.ToTable("Agenda");
                });

            modelBuilder.Entity("AgendaMedica.Domain.Entities.Consulta", b =>
                {
                    b.Property<int>("ConsultaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data");

                    b.Property<int>("EnderecoId");

                    b.Property<int>("EspecialidadeId");

                    b.Property<TimeSpan>("HoraFim");

                    b.Property<TimeSpan>("HoraInicio");

                    b.Property<int>("PacienteId");

                    b.Property<bool>("PagamentoConfirmado");

                    b.Property<int>("ProfissionalId");

                    b.HasKey("ConsultaId");

                    b.HasIndex("EnderecoId");

                    b.HasIndex("EspecialidadeId");

                    b.HasIndex("PacienteId");

                    b.HasIndex("ProfissionalId");

                    b.ToTable("Consulta");
                });

            modelBuilder.Entity("AgendaMedica.Domain.Entities.Endereco", b =>
                {
                    b.Property<int>("EnderecoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CEP");

                    b.Property<string>("Cidade");

                    b.Property<string>("Complemento");

                    b.Property<string>("Estado");

                    b.Property<int>("Numero");

                    b.Property<string>("Rua");

                    b.HasKey("EnderecoId");

                    b.ToTable("Endereco");

                    b.HasData(
                        new
                        {
                            EnderecoId = 1,
                            CEP = "29050-902",
                            Cidade = "Vitória",
                            Complemento = "Casa",
                            Estado = "ES",
                            Numero = 56,
                            Rua = "Av. Américo Buaiz"
                        },
                        new
                        {
                            EnderecoId = 2,
                            CEP = "29045-250",
                            Cidade = "Vitória",
                            Complemento = "Casa",
                            Estado = "ES",
                            Numero = 51,
                            Rua = "Juiz Alexandre Martins de Castro Filho"
                        },
                        new
                        {
                            EnderecoId = 3,
                            CEP = "29100-000",
                            Cidade = "Vila Velha",
                            Complemento = "Casa",
                            Estado = "ES",
                            Numero = 851,
                            Rua = "Av. São Paulo"
                        },
                        new
                        {
                            EnderecoId = 4,
                            CEP = "29166-820",
                            Cidade = "Serra",
                            Complemento = "Casa",
                            Estado = "ES",
                            Numero = 711,
                            Rua = "Av. Copacabana"
                        });
                });

            modelBuilder.Entity("AgendaMedica.Domain.Entities.Especialidade", b =>
                {
                    b.Property<int>("EspecialidadeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("EspecialidadeId");

                    b.ToTable("Especialidade");

                    b.HasData(
                        new
                        {
                            EspecialidadeId = 1,
                            Codigo = "ANSTSLG",
                            Nome = "Anestesiologia"
                        },
                        new
                        {
                            EspecialidadeId = 2,
                            Codigo = "CIRUR. PLAST.",
                            Nome = "Cirurgia Plástica"
                        },
                        new
                        {
                            EspecialidadeId = 3,
                            Codigo = "MED. ESP.",
                            Nome = "Medicina Esportiva"
                        },
                        new
                        {
                            EspecialidadeId = 4,
                            Codigo = "ORTOP. E TRAUM.",
                            Nome = "Ortopedia e Traumatologia"
                        });
                });

            modelBuilder.Entity("AgendaMedica.Domain.Entities.Horario", b =>
                {
                    b.Property<int>("HorarioId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AgendaId");

                    b.Property<int>("DiaSemana");

                    b.Property<TimeSpan>("HoraFim");

                    b.Property<TimeSpan>("HoraInicio");

                    b.HasKey("HorarioId");

                    b.HasIndex("AgendaId");

                    b.ToTable("Horario");
                });

            modelBuilder.Entity("AgendaMedica.Domain.Entities.HorarioExcecao", b =>
                {
                    b.Property<int>("HorarioExcecaoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AgendaId");

                    b.Property<bool>("Atende");

                    b.Property<DateTime>("Data");

                    b.Property<TimeSpan>("HoraFim");

                    b.Property<TimeSpan>("HoraInicio");

                    b.HasKey("HorarioExcecaoId");

                    b.HasIndex("AgendaId");

                    b.ToTable("HorarioExcecao");
                });

            modelBuilder.Entity("AgendaMedica.Domain.Entities.ManyToManys.UsuarioProfissionalEspecialidade", b =>
                {
                    b.Property<int>("EspecialidadeId");

                    b.Property<int>("Id");

                    b.HasKey("EspecialidadeId", "Id");

                    b.HasIndex("Id");

                    b.ToTable("UsuarioProfissionalEspecialidade");

                    b.HasData(
                        new
                        {
                            EspecialidadeId = 1,
                            Id = 3
                        },
                        new
                        {
                            EspecialidadeId = 3,
                            Id = 4
                        });
                });

            modelBuilder.Entity("AgendaMedica.Domain.Identity.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("AppUser");
                });

            modelBuilder.Entity("AgendaMedica.Domain.Identity.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("AgendaMedica.Domain.Identity.UserRole", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("AgendaMedica.Domain.Entities.Usuario", b =>
                {
                    b.HasBaseType("AgendaMedica.Domain.Identity.AppUser");

                    b.Property<DateTime>("DataNascimento");

                    b.Property<int?>("EnderecoId");

                    b.Property<string>("Nome");

                    b.Property<string>("SobreNome");

                    b.HasIndex("EnderecoId");

                    b.HasDiscriminator().HasValue("Usuario");
                });

            modelBuilder.Entity("AgendaMedica.Domain.Entities.UsuarioPaciente", b =>
                {
                    b.HasBaseType("AgendaMedica.Domain.Entities.Usuario");

                    b.Property<string>("Cpf");

                    b.HasDiscriminator().HasValue("UsuarioPaciente");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d7d50895-1e1c-4582-8bd1-6badd9daea7e",
                            Email = "vanessa@teste.com",
                            EmailConfirmed = false,
                            LockoutEnabled = true,
                            NormalizedEmail = "VANESSA@TESTE.COM",
                            NormalizedUserName = "VANESSA@TESTE.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEEVjXvqjVsNgg//Kp2nmmIc8cVqwehn9NayYOAl6iqthSU3yClvT5iQDdDc4J5lKHg==",
                            PhoneNumber = "994839210",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "KRV4CMQKAQCZGZYKSMRW3L7NIJ7CTS6C",
                            TwoFactorEnabled = false,
                            UserName = "vanessa@teste.com",
                            DataNascimento = new DateTime(1941, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EnderecoId = 1,
                            Nome = "Vanessa",
                            SobreNome = "Bianca da Cruz",
                            Cpf = "71985694719"
                        },
                        new
                        {
                            Id = 2,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d7d50895-1e1c-4582-8bd1-6badd9daea7e",
                            Email = "victor@teste.com",
                            EmailConfirmed = false,
                            LockoutEnabled = true,
                            NormalizedEmail = "VICTOR@TESTE.COM",
                            NormalizedUserName = "VICTOR@TESTE.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEEVjXvqjVsNgg//Kp2nmmIc8cVqwehn9NayYOAl6iqthSU3yClvT5iQDdDc4J5lKHg==",
                            PhoneNumber = "997965652",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "KRV4CMQKAQCZGZYKSMRW3L7NIJ7CTS6C",
                            TwoFactorEnabled = false,
                            UserName = "victor@teste.com",
                            DataNascimento = new DateTime(1946, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EnderecoId = 2,
                            Nome = "Victor",
                            SobreNome = "Nelson Martin Caldeira",
                            Cpf = "52435366442"
                        });
                });

            modelBuilder.Entity("AgendaMedica.Domain.Entities.UsuarioProfissional", b =>
                {
                    b.HasBaseType("AgendaMedica.Domain.Entities.Usuario");

                    b.Property<string>("Cnpj");

                    b.Property<string>("Estado");

                    b.Property<string>("Orgao");

                    b.Property<string>("Registro");

                    b.HasDiscriminator().HasValue("UsuarioProfissional");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d7d50895-1e1c-4582-8bd1-6badd9daea7e",
                            Email = "rodrigo@teste.com",
                            EmailConfirmed = false,
                            LockoutEnabled = true,
                            NormalizedEmail = "RODRIGO@TESTE.COM",
                            NormalizedUserName = "RODRIGO@TESTE.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEEVjXvqjVsNgg//Kp2nmmIc8cVqwehn9NayYOAl6iqthSU3yClvT5iQDdDc4J5lKHg==",
                            PhoneNumber = "99349-5462",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "KRV4CMQKAQCZGZYKSMRW3L7NIJ7CTS6C",
                            TwoFactorEnabled = false,
                            UserName = "rodrigo@teste.com",
                            DataNascimento = new DateTime(1971, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EnderecoId = 3,
                            Nome = "Rodrigo",
                            SobreNome = "Vitor Kevin Ferreira",
                            Cnpj = "63.029.660/0001-15"
                        },
                        new
                        {
                            Id = 4,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d7d50895-1e1c-4582-8bd1-6badd9daea7e",
                            Email = "augusto@teste.com",
                            EmailConfirmed = false,
                            LockoutEnabled = true,
                            NormalizedEmail = "AUGUSTO@TESTE.COM",
                            NormalizedUserName = "AUGUSTO@TESTE.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEEVjXvqjVsNgg//Kp2nmmIc8cVqwehn9NayYOAl6iqthSU3yClvT5iQDdDc4J5lKHg==",
                            PhoneNumber = "99598-2285",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "KRV4CMQKAQCZGZYKSMRW3L7NIJ7CTS6C",
                            TwoFactorEnabled = false,
                            UserName = "augusto@teste.com",
                            DataNascimento = new DateTime(1982, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EnderecoId = 4,
                            Nome = "Augusto",
                            SobreNome = "Menezes da Costa",
                            Cnpj = "35.172.039/0001-70"
                        });
                });

            modelBuilder.Entity("AgendaMedica.Domain.Entities.Agenda", b =>
                {
                    b.HasOne("AgendaMedica.Domain.Entities.UsuarioProfissional", "Profissional")
                        .WithMany("Agendas")
                        .HasForeignKey("ProfissionalId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("AgendaMedica.Domain.Entities.Consulta", b =>
                {
                    b.HasOne("AgendaMedica.Domain.Entities.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AgendaMedica.Domain.Entities.Especialidade", "Especialidade")
                        .WithMany()
                        .HasForeignKey("EspecialidadeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AgendaMedica.Domain.Entities.UsuarioPaciente", "Paciente")
                        .WithMany("Consultas")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("AgendaMedica.Domain.Entities.UsuarioProfissional", "Profissional")
                        .WithMany("Consultas")
                        .HasForeignKey("ProfissionalId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("AgendaMedica.Domain.Entities.Horario", b =>
                {
                    b.HasOne("AgendaMedica.Domain.Entities.Agenda", "Agenda")
                        .WithMany("Horarios")
                        .HasForeignKey("AgendaId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("AgendaMedica.Domain.Entities.HorarioExcecao", b =>
                {
                    b.HasOne("AgendaMedica.Domain.Entities.Agenda", "Agenda")
                        .WithMany("HorariosExcecoes")
                        .HasForeignKey("AgendaId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("AgendaMedica.Domain.Entities.ManyToManys.UsuarioProfissionalEspecialidade", b =>
                {
                    b.HasOne("AgendaMedica.Domain.Entities.Especialidade", "Especialidade")
                        .WithMany()
                        .HasForeignKey("EspecialidadeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AgendaMedica.Domain.Entities.UsuarioProfissional", "UsuarioProfissional")
                        .WithMany("Especialidades")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AgendaMedica.Domain.Identity.UserRole", b =>
                {
                    b.HasOne("AgendaMedica.Domain.Identity.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AgendaMedica.Domain.Identity.AppUser", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("AgendaMedica.Domain.Identity.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("AgendaMedica.Domain.Identity.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("AgendaMedica.Domain.Identity.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("AgendaMedica.Domain.Identity.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AgendaMedica.Domain.Entities.Usuario", b =>
                {
                    b.HasOne("AgendaMedica.Domain.Entities.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId");
                });
#pragma warning restore 612, 618
        }
    }
}
