using WebApplication5.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication5.Data.Configurations;

internal class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.Property(g => g.Name).HasMaxLength(10).IsRequired();
        builder.HasMany(g => g.Students).WithOne(s => s.Group).OnDelete(DeleteBehavior.Cascade);
    }
}
