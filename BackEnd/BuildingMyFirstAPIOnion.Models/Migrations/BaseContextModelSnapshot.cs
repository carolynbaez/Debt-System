﻿// <auto-generated />
using System;
using BuildingMyFirstAPIOnion.Models.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BuildingMyFirstAPIOnion.Models.Migrations
{
    [DbContext(typeof(BaseContext))]
    partial class BaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BuildingMyFirstAPIOnion.Models.Entities.LoanEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("AmountPayments")
                        .HasColumnType("int");

                    b.Property<double>("AmountPerPayment")
                        .HasColumnType("float");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DebtorId")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int>("LenderId")
                        .HasColumnType("int");

                    b.Property<bool>("PaymentsCreated")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Term")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DebtorId");

                    b.HasIndex("LenderId");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("BuildingMyFirstAPIOnion.Models.Entities.LoanPayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int>("LoanEntityId")
                        .HasColumnType("int");

                    b.Property<int>("PaymentEntityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LoanEntityId");

                    b.HasIndex("PaymentEntityId");

                    b.ToTable("LoanPayment");
                });

            modelBuilder.Entity("BuildingMyFirstAPIOnion.Models.Entities.PaymentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime?>("DateRealization")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<bool>("Done")
                        .HasColumnType("bit");

                    b.Property<DateTime>("SetedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Voucher")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("BuildingMyFirstAPIOnion.Models.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityCard")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassWord")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BuildingMyFirstAPIOnion.Models.Entities.LoanEntity", b =>
                {
                    b.HasOne("BuildingMyFirstAPIOnion.Models.Entities.UserEntity", "Debtor")
                        .WithMany("LoansGiven")
                        .HasForeignKey("DebtorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BuildingMyFirstAPIOnion.Models.Entities.UserEntity", "Lender")
                        .WithMany("LoansTaken")
                        .HasForeignKey("LenderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Debtor");

                    b.Navigation("Lender");
                });

            modelBuilder.Entity("BuildingMyFirstAPIOnion.Models.Entities.LoanPayment", b =>
                {
                    b.HasOne("BuildingMyFirstAPIOnion.Models.Entities.LoanEntity", null)
                        .WithMany("LoanPayments")
                        .HasForeignKey("LoanEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BuildingMyFirstAPIOnion.Models.Entities.PaymentEntity", null)
                        .WithMany("LoanPayments")
                        .HasForeignKey("PaymentEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BuildingMyFirstAPIOnion.Models.Entities.LoanEntity", b =>
                {
                    b.Navigation("LoanPayments");
                });

            modelBuilder.Entity("BuildingMyFirstAPIOnion.Models.Entities.PaymentEntity", b =>
                {
                    b.Navigation("LoanPayments");
                });

            modelBuilder.Entity("BuildingMyFirstAPIOnion.Models.Entities.UserEntity", b =>
                {
                    b.Navigation("LoansGiven");

                    b.Navigation("LoansTaken");
                });
#pragma warning restore 612, 618
        }
    }
}
