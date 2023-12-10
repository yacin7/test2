using ApplicationCore.Domain;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class FestivalService : Service<Festival>, IFestivalService
    {
        public FestivalService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public double GetHighestCachetForCurrentYear(int festivalId)
        {
            Festival festival = GetById(festivalId);

            if (festival == null)
            {
                throw new ArgumentException("Invalid festival ID.");
            }

            DateTime currentDate = DateTime.Now;
            int currentYear = currentDate.Year;

            double highestCachet = festival.Concerts
                .Where(c => c.DateConcert.Year == currentYear)
                .Max(c => c.Cachet);

            return highestCachet;
        }
    }
}
