using EFCollections.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCollections.DAL.Configuration
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.Property(p => p.UserSecret);
            builder.Property(p => p.UserName);
            builder.Property(p => p.ExpirationDate);

            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.User)
                .WithOne(p => p.RefreshToken)
                .HasForeignKey<RefreshToken>(p => p.UserName)
                .HasPrincipalKey<User>(p => p.UserName);
        }
    }
}
