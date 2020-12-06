using Swimming.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swimming.IService
{
   public interface IRacingService
    {
        #region Racing
        Task<List<Racing>> GetRacings();
        IEnumerable<int> GetRacingDetails(int RacingId);
        Task<int> AddRacing(Racing newRacing, IEnumerable<int> SelectedYears);
        Task UpdateRacing(Racing Racing, IEnumerable<int> SelectedYears);
        Racing GetRacingbyId(int Id);
        List<Racing> GetRacingOfParti(int Id);
        #endregion
        #region Points
        Task<List<Points>> GetPoints();
        Task<bool> AddPoint(Points newPoint);
        Task<bool> UpdatePoint(Points updatePoint);
        Points GePointbyId(int Id);
        #endregion
    }
}
