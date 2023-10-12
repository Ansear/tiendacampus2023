
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.repositorios;

namespace Infrastructure.Repositories;

public class TipoDocumentoRepository : GenericRepository<TipoDocumento>, ITipoDocumento
{
    private readonly TiendaCampusContext _context;

    public TipoDocumentoRepository(TiendaCampusContext context) : base(context)
    {
        _context = context;
    }
}
