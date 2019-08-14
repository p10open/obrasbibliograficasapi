using Guide.ObrasBibliograficas.Domain.Entitdades;
using System;
using Xunit;

namespace Guide.ObrasBibliograficas.Test
{
    public class ObraBibliograficaTest
    {
        [Fact]
        public void Deve_Formatar_Nome_Junior_SemSobrenome()
        {
            var resultadoEsperado = "JUNIOR, Paulo";

            var obra = new ObraBibliografica { Nome = "Paulo Junior"};

            obra.Formatar();

            Assert.Equal(obra.Nome, resultadoEsperado);
        }

        [Fact]
        public void Deve_Formatar_Nome_Neto_ComSobrenome()
        {
            var resultadoEsperado = "SILVA NETO, Paulo";

            var obra = new ObraBibliografica { Nome = "Paulo Silva Neto" };

            obra.Formatar();

            Assert.Equal(obra.Nome, resultadoEsperado);
        }

        [Fact]
        public void Nao_Deve_Formatar_O_Artigo()
        {
            var resultadoEsperado = "FERREIRA, Paulo da Silva";

            var obra = new ObraBibliografica { Nome = "Paulo da Silva Ferreira" };

            obra.Formatar();

            Assert.Equal(obra.Nome, resultadoEsperado);
        }
    }
}
