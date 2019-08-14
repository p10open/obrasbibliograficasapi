using System.Collections.Generic;

namespace Guide.ObrasBibliograficas.Domain.Entitdades
{
    public sealed class ObraBibliografica
    {
        readonly List<string> Descendentes = new List<string> { "filho", "filha", "neto", "neta", "sobrinha", "junior" };
        readonly List<string> NaoProcessa = new List<string> { "da", "de", "do", "das", "dos", "e" };
        public int Id { get; set; }
        public string Nome { get; set; }

        public void Formatar()
        {
            var nomes = Nome.ToLower().Trim().Split(' ');

            var quantidadeNomes = nomes.Length;

            if (quantidadeNomes == 1)
                Nome = nomes[0].ToUpper();
            else
            {
                if (Descendentes.Contains(nomes[quantidadeNomes - 1]) && quantidadeNomes > 2)
                {
                    Nome = $"{nomes[quantidadeNomes - 2].ToUpper()} {nomes[quantidadeNomes - 1].ToUpper()},";
                    ProcessarNomes(quantidadeNomes - 2, nomes);
                }
                else
                {
                    Nome = $"{nomes[quantidadeNomes - 1].Trim().ToUpper()},";
                    ProcessarNomes(quantidadeNomes - 1, nomes);
                }
            }
        }

        void ProcessarNomes(int quantidade, string[] nomes)
        {
            for (int i = 0; i < quantidade; i++)
                Nome += $" {ProcessarNomeComum(nomes[i])}";
        }

        string ProcessarNomeComum(string nome)
        {
            if (string.IsNullOrEmpty(nome) || nome.Length < 2 || NaoProcessa.Contains(nome))
                return nome;

            var primeiraLetra = nome.Substring(0, 1);
            var restoNome = nome.Substring(1, (nome.Length - 1));

            return $"{primeiraLetra.ToUpper()}{restoNome}";
        }
    }
}
