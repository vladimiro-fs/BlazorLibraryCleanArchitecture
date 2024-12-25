namespace Library.Infrastructure.EntitiesConfiguration
{
    using Library.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class LibraryConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder) 
        {
            builder.HasKey(t => t.BookId);
            builder.Property(p => p.Title).HasMaxLength(150).IsRequired();
            builder.Property(p => p.Author).HasMaxLength(200).IsRequired();
            builder.Property(p => p.ReleaseDate).IsRequired();
            builder.Property(p => p.Cover).HasMaxLength(200);
        }
    }
}
