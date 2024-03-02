
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using WebsiteBuilder.Models;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }


    public DbSet<Website> Websites { get; set; }
    public DbSet<GalleryImages> GalleryImages { get; set; }
    public DbSet<Click> Clicks { get; set; }

    public DbSet<Service> Services { get; set; }
    public DbSet<Seo> Seos { get; set; }
    public DbSet<Slider> Sliders { get; set; }
    

    public DbSet<AboutUs> AboutUs { get; set; }

    public DbSet<WhyChooseUs> WhyChooseUs { get; set; }
    public DbSet<GetAppointment> GetAppointments { get; set; }
    public DbSet<Testimonial> Testimonials { get; set; }

    public DbSet<Couter> Couters { get; set; }

    public DbSet<Customization> Customizations { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ApplicationUser>()
            .HasOne(user => user.Website)
            .WithOne(website => website.User)
            .HasForeignKey<Website>(website => website.UserId);



        modelBuilder.Entity<Website>()
        .HasMany(w => w.Services)
        .WithOne(s => s.Website)
        .HasForeignKey(s => s.WebsiteId);

        modelBuilder.Entity<Website>()
        .HasMany(w => w.Seos)
        .WithOne(s => s.Website)
        .HasForeignKey(s => s.WebsiteId);

        modelBuilder.Entity<Website>()
       .HasMany(w => w.Sliders)
       .WithOne(s => s.Website)
       .HasForeignKey(s => s.WebsiteId);

        modelBuilder.Entity<Website>()
       .HasMany(w => w.AboutUs)
       .WithOne(s => s.Website)
       .HasForeignKey(s => s.WebsiteId);

        modelBuilder.Entity<Website>()
      .HasMany(w => w.WhyChooseUs)
      .WithOne(s => s.Website)
      .HasForeignKey(s => s.WebsiteId);

        modelBuilder.Entity<Website>()
     .HasMany(w => w.GetAppointments)
     .WithOne(s => s.Website)
     .HasForeignKey(s => s.WebsiteId);

        modelBuilder.Entity<Website>()
     .HasMany(w => w.Couters)
     .WithOne(s => s.Website)
     .HasForeignKey(s => s.WebsiteId);

        modelBuilder.Entity<Website>()
     .HasMany(w => w.Testimonials)
     .WithOne(s => s.Website)
     .HasForeignKey(s => s.WebsiteId);

        modelBuilder.Entity<Website>()
    .HasMany(w => w.Customizations)
    .WithOne(s => s.Website)
    .HasForeignKey(s => s.WebsiteId);

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
        // oHomeController1.csther configurations...
    }



}
