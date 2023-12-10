using ApplicationCore.Domain;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ArtisteService : Service<Artiste>, IArtisteService
    {
        public ArtisteService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
