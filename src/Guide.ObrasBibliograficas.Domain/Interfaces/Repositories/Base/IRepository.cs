using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guide.ObrasBibliograficas.Domain.Interfaces.Repositories.Base
{
    public interface IRepository<T> where T: class
    {
        void Adicionar(T entidade);
        void AdicionarLote(IEnumerable<T> entidades);
        void Alterar(T entidade);
        void Remover(T entidade);
        void Remover(int id);
        T Buscar(int id);
        IQueryable<T> Listar();
    }
}
