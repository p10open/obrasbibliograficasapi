using System;
using System.Collections.Generic;
using System.Text;

namespace Guide.ObrasBibliograficas.Domain.Interfaces.UoW
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
