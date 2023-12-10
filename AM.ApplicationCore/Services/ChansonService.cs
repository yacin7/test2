using ApplicationCore.Domain;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ChansonService : Service<Chanson>, IChansonService
    {
        public ChansonService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public double GetHighestViewsForArtist(string artistName)
        {
            Chanson[] chansons = GetMany(chanson => chanson.Artiste.Nom == artistName).ToArray();

            if (chansons.Length == 0)
            {
                throw new ArgumentException("Invalid artist name.");
            }

            double highestViews = chansons.Max(chanson => chanson.VuesYoutube);

            return highestViews;
        }
        
    }
}
