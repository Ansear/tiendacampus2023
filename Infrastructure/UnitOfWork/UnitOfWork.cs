using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Infrastructure.UnitOfWork;
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly TiendaCampusContext _context;
        private ICiudad _ciudades; 
        private IDepartamento _departamentos;
        private IPais _paises;
        private ITipoDocumento _tipoDocumento;
        public UnitOfWork(TiendaCampusContext context) 
        {
            _context = context;
        }

        public ICiudad Ciudades 
        { 
            get
            {
                _ciudades ??= new CiudadRepository(_context);
                return _ciudades;
            }  
        }
        public IDepartamento Departamentos 
        { 
            get
            {
                _departamentos ??= new DepartamentoRepository(_context);
                return _departamentos;
            } 
        }
        public IPais Paises
        { 
            get
            {
                _paises ??= new PaisRepository(_context);
                return _paises;
            } 
        }
        public ITipoDocumento TipoDocumento
        {
            get
            {
                _tipoDocumento ??= new TipoDocumentoRepository(_context);
                return _tipoDocumento;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Task<int> SaveAsync()
        {
            return _context.SaveChangesAsync();
        }
}