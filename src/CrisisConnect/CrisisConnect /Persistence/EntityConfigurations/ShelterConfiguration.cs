using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.EntityConfigurations;


public class ShelterConfiguration : IEntityTypeConfiguration<Shelter>
{
   public void Configure(EntityTypeBuilder<Shelter> builder)
   {
       builder.ToTable("Shelters").HasKey(s => s.Id);


       // Primary Key
       builder.Property(s => s.Id)
           .ValueGeneratedOnAdd()
           .HasConversion(shelterId => shelterId.Value, value => new ShelterId(value));


       // Foreign Keys
       builder.Property(s => s.VolunteerId).IsRequired(false);
       builder.Property(s => s.DisasterId).IsRequired(false);
       builder.Property(s => s.RequestId).IsRequired(false);


       // Basic Information
       builder.Property(s => s.Name)
           .IsRequired()
           .HasMaxLength(200)
           .HasColumnName("Name");
          
       builder.Property(s => s.PhoneNumber)
           .IsRequired()
           .HasMaxLength(20)
           .HasColumnName("PhoneNumber");


       builder.Property(s => s.Status)
           .IsRequired()
           .HasConversion<int>()
           .HasColumnName("Status");


       // Address
       builder.OwnsOne(s => s.Address, addressBuilder =>
       {
           addressBuilder.Property(a => a.Street).IsRequired().HasMaxLength(100).HasColumnName("street");
           addressBuilder.Property(a => a.City).IsRequired().HasMaxLength(100).HasColumnName("city");
           addressBuilder.Property(a => a.Country).IsRequired().HasMaxLength(100).HasColumnName("country");
           addressBuilder.Property(a => a.ZipCode).IsRequired().HasMaxLength(10).HasColumnName("zip_code");
           addressBuilder.Property(a => a.State).IsRequired().HasMaxLength(100).HasColumnName("state");
           addressBuilder.Property(a => a.Apartment).HasMaxLength(100).HasColumnName("apartment");
       });


       // Capacity Management
       builder.Property(s => s.TotalCapacity)
           .IsRequired()
           .HasColumnName("TotalCapacity");


       builder.Property(s => s.HasAccessibility)
           .IsRequired()
           .HasColumnName("HasAccessibility");


       builder.Property(s => s.HasMedicalSupport)
           .IsRequired()
           .HasColumnName("HasMedicalSupport");


       builder.Property(s => s.HasKitchen)
           .IsRequired()
           .HasColumnName("HasKitchen");


       // Tracking
       builder.Property(s => s.OpenedAt)
           .IsRequired()
           .HasColumnName("OpenedAt");


       builder.Property(s => s.ClosedAt)
           .IsRequired()
           .HasColumnName("ClosedAt");


       // Relationships
       // Shelter ile Volunteer arasında 1-1 ilişki
       builder.HasOne(s => s.Volunteer)
           .WithOne(v => v.Shelter)
           .HasForeignKey<Shelter>(s => s.Id); 
       
       // Shelter ile Disaster arasında Bire Çok ilişki
       builder.HasOne(s => s.Disaster)
           .WithMany(d => d.Shelters);
       

       // Indexes
       builder.HasIndex(s => s.Id);
       builder.HasIndex(s => s.VolunteerId);
       builder.HasIndex(s => s.DisasterId);
       builder.HasIndex(s => s.RequestId);
       builder.HasIndex(s => s.Name);
       builder.HasIndex(s => s.PhoneNumber);
       builder.HasIndex(s => s.Status);
       builder.HasIndex(s => s.TotalCapacity);
       builder.HasIndex(s => s.HasAccessibility);
       builder.HasIndex(s => s.HasMedicalSupport);
       builder.HasIndex(s => s.HasKitchen);
       builder.HasIndex(s => s.OpenedAt); 
       builder.HasIndex(s => s.ClosedAt);
            


       // Soft Delete Filter
       builder.HasQueryFilter(s => !s.DeletedDate.HasValue);
   }
}
