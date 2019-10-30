using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WXAMPService.EF;
using WXAMPService.EF.Domain;

namespace WXAMPService.EF.Mapping
{
    public class RInformationMapping : IEntityTypeConfiguration<RInformation>
    {
        public void Configure(EntityTypeBuilder<RInformation> builder)
        {
            builder.ToTable("RInformation");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.username).IsRequired().HasMaxLength(20);
            builder.Property(x => x.wxname).IsRequired().HasMaxLength(20);
            builder.Property(x => x.wxid).IsRequired().HasMaxLength(20);
            builder.Property(x => x.rank).IsRequired();
            builder.Property(x => x.votes).IsRequired();
        }
    }
}
