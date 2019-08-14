using Guide.ObrasBibliograficas.Domain.Entitdades;
using Guide.ObrasBibliograficas.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guide.ObrasBibliograficas.Infra.Data.Mapping
{
    public sealed class ObraBibliograficaMap : EntityTypeConfiguration<ObraBibliografica>
    {
        public void Map(EntityTypeBuilder<ObraBibliografica> builder)
        {
            builder.ToTable("ObraBibliografica").HasKey(x=>x.Id);

            builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("int");
            builder.Property(x => x.Nome).HasColumnName("Nome").HasColumnType("varchar(max)");
        }
    }
}
