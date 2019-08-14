using Guide.ObrasBibliograficas.Domain.Entitdades;
using Guide.ObrasBibliograficas.Domain.Interfaces.Repositories;
using Guide.ObrasBibliograficas.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guide.ObrasBibliograficas.Infra.Data.Repositories
{
    public sealed class ObraBibliograficaRepository : Base.Repository<ObraBibliografica>, IObraBibliograficaRepository
    {
        public ObraBibliograficaRepository(ObrasBibliograficasContext context) : base(context)
        {
        }
    }
}
