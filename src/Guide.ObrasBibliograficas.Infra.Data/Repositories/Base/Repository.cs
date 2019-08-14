using Guide.ObrasBibliograficas.Domain.Interfaces.Repositories.Base;
using Guide.ObrasBibliograficas.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guide.ObrasBibliograficas.Infra.Data.Repositories.Base
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        ObrasBibliograficasContext _context;
        DbSet<T> _entidade;

        public Repository(ObrasBibliograficasContext context)
        {
            _context = context;
            _entidade = _context.Set<T>();
        }

        public void Adicionar(T entidade)
        {
            _entidade.Add(entidade);
        }

        public void AdicionarLote(IEnumerable<T> entidades)
        {
            _entidade.AddRange(entidades);
        }

        public void Alterar(T entidade)
        {
            _entidade.Update(entidade);
        }

        public T Buscar(int id)
        {
            return _entidade.Find(id);
        }

        public IQueryable<T> Listar()
        {
            return _entidade;
        }

        public void Remover(T entidade)
        {
            _entidade.Remove(entidade);
        }

        public void Remover(int id)
        {
            Remover(Buscar(id));
        }
    }
}
