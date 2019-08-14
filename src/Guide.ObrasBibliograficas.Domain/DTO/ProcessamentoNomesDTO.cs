using Guide.ObrasBibliograficas.Domain.Entitdades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guide.ObrasBibliograficas.Domain.DTO
{
    public sealed class ProcessamentoNomesDTO
    {
        public List<ObraBibliografica> ObrasBibliograficas { get; set; }
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }

        public sealed class ProcessamentoNomesDTOFactory
        {
            public static ProcessamentoNomesDTO Sucesso(List<ObraBibliografica> obraBibliograficas, string mensagem)
            {
                return new  ProcessamentoNomesDTO{ Sucesso = true, ObrasBibliograficas = obraBibliograficas, Mensagem = mensagem};
            }

            public static ProcessamentoNomesDTO Erro(string erro)
            {
                return new ProcessamentoNomesDTO { Sucesso = false, Mensagem = erro};
            }
        }
    }
}
