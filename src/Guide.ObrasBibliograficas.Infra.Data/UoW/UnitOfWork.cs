using Guide.ObrasBibliograficas.Domain.Interfaces.UoW;
using Guide.ObrasBibliograficas.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guide.ObrasBibliograficas.Infra.Data.UoW
{
    public class UnitOfWork: IUnitOfWork
    {
        ObrasBibliograficasContext _context;

        public UnitOfWork(ObrasBibliograficasContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
