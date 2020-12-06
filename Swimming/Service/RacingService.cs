using Microsoft.EntityFrameworkCore;
using Swimming.Data;
using Swimming.IService;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swimming.Service
{
    public class RacingService : IRacingService
    {
        private readonly ApplicationDbContext _db;
        public RacingService(ApplicationDbContext db)
        {
            _db = db;
        }
        #region Racing
        public async Task<List<Racing>> GetRacings()
        {
            if (_db != null)
            {
                return await _db.Racings.Where(Par => Par.DeleteDate == null).ToListAsync();
            }

            return null;
        }
        public IEnumerable<int> GetRacingDetails(int RacingId)
        {
            if (_db != null)
            {
                return _db.RacingDetail.Where(RD => RD.RacingId == RacingId).ToList().Select(d => d.Year - 1990);
            }

            return null;
        }
        public async Task<int> AddRacing(Racing newRacing, IEnumerable<int> SelectedYears)
        {
            if (_db != null)
            {

                _db.Racings.Add(newRacing);
                _db.SaveChanges();
                foreach (var item in SelectedYears)
                {
                    var NewRacingDetails = new RacingDetails();
                    NewRacingDetails.Year = item + 1990;
                    NewRacingDetails.RacingId = newRacing.Id;
                    _db.RacingDetail.Add(NewRacingDetails);
                    _db.SaveChanges();
                }

                return newRacing.Id;
            }
            return 0;
        }
        public async Task UpdateRacing(Racing Racing, IEnumerable<int> SelectedYears)
        {
            if (_db != null)
            {
                //Delete that post

                _db.Racings.Update(Racing);

                //Commit the transaction
                await _db.SaveChangesAsync();
                var GetDetails = _db.RacingDetail.Where(RD => RD.RacingId == Racing.Id).ToList();
                foreach (var item in GetDetails)
                {
                    _db.Remove(item);
                    _db.SaveChanges();
                }
                foreach (var item in SelectedYears)
                {
                    var NewRacingDetails = new RacingDetails();
                    NewRacingDetails.Year = item + 1990;
                    NewRacingDetails.RacingId = Racing.Id;
                    _db.RacingDetail.Add(NewRacingDetails);
                    _db.SaveChanges();
                }


            }
        }
        public Racing GetRacingbyId(int Id)
        {
            if (_db != null)
            {
                return _db.Racings.Find(Id); ;
            }

            return null;
        }
        public  List<Racing> GetRacingOfParti(int Id)
        {
            if (_db != null && Id !=0)
            {
                var gParticipate = _db.Participant.Find(Id);
                var gRacingDetails = _db.RacingDetail.Where(a => a.Year == gParticipate.Birthday.Value.Year).ToList();
                var gRacing = _db.Racings.ToList();
                var retureRacing = (from gR in gRacing join grD in gRacingDetails
                                    on gR.Id equals grD.RacingId select gR).ToList();
                return retureRacing;
            }

            return null;
        }
        #endregion
        #region Points
        public async Task<List<Points>> GetPoints()
        {
            if (_db != null)
            {
                return await _db.Point.Where(Par => Par.DeleteDate == null).ToListAsync();
            }

            return null;
        }       
        public async Task<bool> AddPoint(Points newPoint)
        {
            if (_db != null)
            {

                _db.Point.Add(newPoint);
                _db.SaveChanges();            
                return true;
            }
            return false;
        }
        public  async Task<bool> UpdatePoint(Points updatePoint)
        {
            if (_db != null)
            {
                //Delete that post
                _db.Point.Update(updatePoint);
                //Commit the transaction
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public Points GePointbyId(int Id)
        {
            if (_db != null)
            {
                return _db.Point.Find(Id); ;
            }

            return null;
        }
        #endregion
    }
}
