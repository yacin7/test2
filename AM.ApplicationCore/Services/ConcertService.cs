using ApplicationCore.Domain;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ConcertService : Service<Concert>, IConcertService
    {
        public ConcertService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
