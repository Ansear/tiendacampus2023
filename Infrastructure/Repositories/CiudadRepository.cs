using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.repositorios;

namespace Infrastructure.Repositories;
public class CiudadRepository : GenericRepository<Ciudad>,ICiudad
{
    private readonly TiendaCampusContext _context;

    public CiudadRepository(TiendaCampusContext context) : base(context)
    {
        _context = context;
    }
}
