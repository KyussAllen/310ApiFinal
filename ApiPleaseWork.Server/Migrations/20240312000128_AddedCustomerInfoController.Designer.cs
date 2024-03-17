﻿// <auto-generated />
using System;
using ApiPleaseWork.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiPleaseWork.Server.Migrations
{
    [DbContext(typeof(ApiPleaseWorkServerContext))]
    [Migration("20240312000128_AddedCustomerInfoController")]
    partial class AddedCustomerInfoController
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApiPleaseWork.Models.CustCallAttempts", b =>
                {
                    b.Property<int>("CallAttemptId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CallAttemptId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int?>("CustomerInformationCustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeOfAttempt")
                        .HasColumnType("datetime2");

                    b.Property<string>("notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CallAttemptId");

                    b.HasIndex("CustomerInformationCustomerId");

                    b.ToTable("CustCallAttempts");
                });

            modelBuilder.Entity("ApiPleaseWork.Models.CustomerContact", b =>
                {
                    b.Property<int>("CustomerContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerContactId"));

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<int?>("CustomerInformationCustomerId")
                        .HasColumnType("int");

                    b.Property<string>("CustomerPhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerPhoneType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerContactId");

                    b.HasIndex("CustomerInformationCustomerId");

                    b.ToTable("CustomerContact");
                });

            modelBuilder.Entity("ApiPleaseWork.Models.CustomerInformation", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("CustomerCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerState")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("CustomerInformation");
                });

            modelBuilder.Entity("ApiPleaseWork.Models.CustCallAttempts", b =>
                {
                    b.HasOne("ApiPleaseWork.Models.CustomerInformation", null)
                        .WithMany("CustomerCallAttempts")
                        .HasForeignKey("CustomerInformationCustomerId");
                });

            modelBuilder.Entity("ApiPleaseWork.Models.CustomerContact", b =>
                {
                    b.HasOne("ApiPleaseWork.Models.CustomerInformation", null)
                        .WithMany("CustPhoneNumber")
                        .HasForeignKey("CustomerInformationCustomerId");
                });

            modelBuilder.Entity("ApiPleaseWork.Models.CustomerInformation", b =>
                {
                    b.Navigation("CustPhoneNumber");

                    b.Navigation("CustomerCallAttempts");
                });
#pragma warning restore 612, 618
        }
    }
}