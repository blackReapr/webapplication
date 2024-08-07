using WebApplication5.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication5.Data.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.Property(s => s.Name).IsRequired().HasMaxLength(10);
        builder.Property(s => s.Point).IsRequired();
        builder.HasOne(s => s.Group).WithMany(s => s.Students).HasForeignKey(s => s.GroupId);
    }
}
