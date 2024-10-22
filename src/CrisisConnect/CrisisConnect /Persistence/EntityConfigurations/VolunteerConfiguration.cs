using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class VolunteerConfiguration: IEntityTypeConfiguration<Volunteer>
{
    public void Configure(EntityTypeBuilder<Volunteer> builder)
    {
        builder.ToTable("Volunteers").HasKey(v => v.Id);
        
        builder.Property(v => v.Id).HasColumnName("Id").IsRequired();
        builder.Property(v => v.FirstName).HasColumnName("FirstName").IsRequired();
        builder.Property(v => v.LastName).HasColumnName("LastName").IsRequired();
        builder.Property(v => v.PhoneNumber).HasColumnName("PhoneNumber").IsRequired();
        builder.Property(v => v.Availability).HasColumnName("Availability").IsRequired();
        builder.Property(v => v.Location).HasColumnName("Location").IsRequired();
        builder.Property(v => v.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(v => v.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(v => v.DeletedDate).HasColumnName("DeletedDate");
        
        builder.HasQueryFilter(v => !v.DeletedDate.HasValue); // Soft delete
    }
}