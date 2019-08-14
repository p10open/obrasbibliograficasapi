using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guide.ObrasBibliograficas.Infra.Data.Extensions
{
    public interface EntityTypeConfiguration<TEntity> where TEntity : class
    {
        void Map(EntityTypeBuilder<TEntity> builder);
    }
}
