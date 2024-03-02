﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace WebsiteBuilder.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240301131658_seodataupdate")]
    partial class seodataupdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("WebsiteBuilder.Models.AboutUs", b =>
                {
                    b.Property<int>("AboutUsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AboutDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AboutImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AboutName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AboutShortDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WebsiteId")
                        .HasColumnType("int");

                    b.HasKey("AboutUsId");

                    b.HasIndex("WebsiteId");

                    b.ToTable("AboutUs");
                });

            modelBuilder.Entity("WebsiteBuilder.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<int?>("WebsiteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("WebsiteBuilder.Models.Click", b =>
                {
                    b.Property<int>("ClickId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IpAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MainUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("WebsiteId")
                        .HasColumnType("int");

                    b.HasKey("ClickId");

                    b.HasIndex("WebsiteId");

                    b.ToTable("Clicks");
                });

            modelBuilder.Entity("WebsiteBuilder.Models.Couter", b =>
                {
                    b.Property<int>("CounterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EndNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WebsiteId")
                        .HasColumnType("int");

                    b.HasKey("CounterId");

                    b.HasIndex("WebsiteId");

                    b.ToTable("Couters");
                });

            modelBuilder.Entity("WebsiteBuilder.Models.GalleryImages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int>("WebsiteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WebsiteId");

                    b.ToTable("GalleryImages");
                });

            modelBuilder.Entity("WebsiteBuilder.Models.GetAppointment", b =>
                {
                    b.Property<int>("GetAppointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BtnNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ButtonText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subtitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WebsiteId")
                        .HasColumnType("int");

                    b.HasKey("GetAppointmentId");

                    b.HasIndex("WebsiteId");

                    b.ToTable("GetAppointments");
                });

            modelBuilder.Entity("WebsiteBuilder.Models.Seo", b =>
                {
                    b.Property<int>("SeoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomScript")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GoogleAnalytics")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetaDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetaTagsForFacebook")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetaTagsForInstagram")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OgDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OgImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OgTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SeoTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SiteMap")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SiteName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TwitterImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WebsiteId")
                        .HasColumnType("int");

                    b.Property<string>("authorname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("canonicalUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SeoId");

                    b.HasIndex("WebsiteId");

                    b.ToTable("Seos");
                });

            modelBuilder.Entity("WebsiteBuilder.Models.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ServiceDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceShortDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleSubText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WebsiteId")
                        .HasColumnType("int");

                    b.HasKey("ServiceId");

                    b.HasIndex("WebsiteId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("WebsiteBuilder.Models.Slider", b =>
                {
                    b.Property<int>("SliderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BtnLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BtnText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SliderImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SliderShortDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SliderTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WebsiteId")
                        .HasColumnType("int");

                    b.HasKey("SliderId");

                    b.HasIndex("WebsiteId");

                    b.ToTable("Sliders");
                });

            modelBuilder.Entity("WebsiteBuilder.Models.Testimonial", b =>
                {
                    b.Property<int>("TestimonialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Designation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fullname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WebsiteId")
                        .HasColumnType("int");

                    b.HasKey("TestimonialId");

                    b.HasIndex("WebsiteId");

                    b.ToTable("Testimonials");
                });

            modelBuilder.Entity("WebsiteBuilder.Models.Website", b =>
                {
                    b.Property<int>("WebsiteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CallingNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomCss")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Designation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instagram")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsBNI")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMBC")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMCC")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSCGT")
                        .HasColumnType("bit");

                    b.Property<string>("Linkdin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LogoImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NamewithDesignation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OtherCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalPhoto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimaryBg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductOrServiceName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublicUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QrPhoto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondryBg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slautation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SmsNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Twitter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("WebsiteUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WhatsappNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Youtube")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("facebook")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WebsiteId");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Websites");
                });

            modelBuilder.Entity("WebsiteBuilder.Models.WhyChooseUs", b =>
                {
                    b.Property<int>("WhyChooseUsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SectionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SectionTagLine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleSubText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WebsiteId")
                        .HasColumnType("int");

                    b.Property<string>("heading")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WhyChooseUsId");

                    b.HasIndex("WebsiteId");

                    b.ToTable("WhyChooseUs");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("WebsiteBuilder.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WebsiteBuilder.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebsiteBuilder.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("WebsiteBuilder.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebsiteBuilder.Models.AboutUs", b =>
                {
                    b.HasOne("WebsiteBuilder.Models.Website", "Website")
                        .WithMany("AboutUs")
                        .HasForeignKey("WebsiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebsiteBuilder.Models.Click", b =>
                {
                    b.HasOne("WebsiteBuilder.Models.Website", "Website")
                        .WithMany("Clicks")
                        .HasForeignKey("WebsiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebsiteBuilder.Models.Couter", b =>
                {
                    b.HasOne("WebsiteBuilder.Models.Website", "Website")
                        .WithMany("Couters")
                        .HasForeignKey("WebsiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebsiteBuilder.Models.GalleryImages", b =>
                {
                    b.HasOne("WebsiteBuilder.Models.Website", "Website")
                        .WithMany("Images")
                        .HasForeignKey("WebsiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebsiteBuilder.Models.GetAppointment", b =>
                {
                    b.HasOne("WebsiteBuilder.Models.Website", "Website")
                        .WithMany("GetAppointments")
                        .HasForeignKey("WebsiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebsiteBuilder.Models.Seo", b =>
                {
                    b.HasOne("WebsiteBuilder.Models.Website", "Website")
                        .WithMany("Seos")
                        .HasForeignKey("WebsiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebsiteBuilder.Models.Service", b =>
                {
                    b.HasOne("WebsiteBuilder.Models.Website", "Website")
                        .WithMany("Services")
                        .HasForeignKey("WebsiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebsiteBuilder.Models.Slider", b =>
                {
                    b.HasOne("WebsiteBuilder.Models.Website", "Website")
                        .WithMany("Sliders")
                        .HasForeignKey("WebsiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebsiteBuilder.Models.Testimonial", b =>
                {
                    b.HasOne("WebsiteBuilder.Models.Website", "Website")
                        .WithMany("Testimonials")
                        .HasForeignKey("WebsiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebsiteBuilder.Models.Website", b =>
                {
                    b.HasOne("WebsiteBuilder.Models.ApplicationUser", "User")
                        .WithOne("Website")
                        .HasForeignKey("WebsiteBuilder.Models.Website", "UserId");
                });

            modelBuilder.Entity("WebsiteBuilder.Models.WhyChooseUs", b =>
                {
                    b.HasOne("WebsiteBuilder.Models.Website", "Website")
                        .WithMany("WhyChooseUs")
                        .HasForeignKey("WebsiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
