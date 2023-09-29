
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.repositorios;

namespace Infrastructure.Repositories
{
    public class DepartamentoRepository : GenericRepository<Departamento>,IDepartamento
    {
        private readonly TiendaCampusContext _context;

        public DepartamentoRepository(TiendaCampusContext context) : base(context)
        {
            _context = context;
        }
    }
}