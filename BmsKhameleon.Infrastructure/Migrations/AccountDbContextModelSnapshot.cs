﻿// <auto-generated />
using System;
using BmsKhameleon.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BmsKhameleon.Infrastructure.Migrations
{
    [DbContext(typeof(AccountDbContext))]
    partial class AccountDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BmsKhameleon.Core.Domain.Entities.Account", b =>
                {
                    b.Property<Guid>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("AccountType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("BankBranch")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<DateTime?>("DateEnrolled")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<decimal>("InitialBalance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Visibility")
                        .HasColumnType("bit");

                    b.Property<decimal?>("WorkingBalance")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("AccountId");

                    b.ToTable("Accounts", (string)null);
                });

            modelBuilder.Entity("BmsKhameleon.Core.Domain.Entities.MonthlyWorkingBalance", b =>
                {
                    b.Property<Guid>("MonthlyWorkingBalanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("WorkingBalance")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("MonthlyWorkingBalanceId");

                    b.HasIndex("AccountId", "Date")
                        .IsUnique();

                    b.ToTable("MonthlyWorkingBalances", (string)null);
                });

            modelBuilder.Entity("BmsKhameleon.Core.Domain.Entities.Transaction", b =>
                {
                    b.Property<Guid>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CashTransactionType")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("ChequeBankName")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("ChequeNumber")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Note")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("Payee")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TransactionMedium")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("TransactionType")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("TransactionId");

                    b.HasIndex("AccountId");

                    b.ToTable("Transactions", (string)null);
                });

            modelBuilder.Entity("BmsKhameleon.Core.Domain.Entities.MonthlyWorkingBalance", b =>
                {
                    b.HasOne("BmsKhameleon.Core.Domain.Entities.Account", "Account")
                        .WithMany("MonthlyWorkingBalances")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("BmsKhameleon.Core.Domain.Entities.Transaction", b =>
                {
                    b.HasOne("BmsKhameleon.Core.Domain.Entities.Account", "Account")
                        .WithMany("Transactions")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("BmsKhameleon.Core.Domain.Entities.Account", b =>
                {
                    b.Navigation("MonthlyWorkingBalances");

                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
