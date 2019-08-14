using Guide.ObrasBibliograficas.Domain.DTO;
using Guide.ObrasBibliograficas.Domain.Entitdades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guide.ObrasBibliograficas.Domain.Interfaces.Services
{
    public interface IObraBibliograficaService
    {
        ProcessamentoNomesDTO Processar(List<ObraBibliografica> obraBibliograficas);
    }
}
