using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.repositorios;

namespace Infrastructure.Repositories;

    public class PaisRepository : GenericRepository<Pais>,IPais
    {
        private readonly TiendaCampusContext _context;
        public PaisRepository(TiendaCampusContext context) : base(context)
        {
            _context = context;
        }
    }
