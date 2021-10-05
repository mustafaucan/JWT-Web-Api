using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proje.JWT.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.JWT.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.UserName).IsRequired().HasMaxLength(50).IsRequired();
            builder.HasIndex(I => I.UserName).IsUnique();

            builder.Property(I => I.Password).HasMaxLength(100).IsRequired();
            builder.Property(I => I.FullName).HasMaxLength(100);

            builder.HasMany(I => I.AppUserRoles).WithOne(I => I.AppUser).HasForeignKey(I => I.AppUserId).OnDelete(DeleteBehavior.Cascade);

            
        }
    }
}
