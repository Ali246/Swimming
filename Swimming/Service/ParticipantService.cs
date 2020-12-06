using Microsoft.EntityFrameworkCore;
using Swimming.Data;
using Swimming.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swimming.Service
{
    public class ParticipantService: IParticipantSevice
    {
        private readonly ApplicationDbContext _db;
        public ParticipantService(ApplicationDbContext db)
        {
            _db = db;
        }
        #region Participants
        public async Task<List<Participants>> GetParticipants()
        {
            if (_db != null)
            {
                return await _db.Participant.Where(Par => Par.DeleteDate == null).ToListAsync();
            }

            return null;
        }
        public async Task<int> AddParticipant(Participants Participant)
        {
            if (_db != null)
            {
                Participant.CaptainOrOrganization = Participant.CaptainOrOrganizationId !=0? _db.CaptainOrOrganizations.Where(CO => CO.Id == Participant.CaptainOrOrganizationId).FirstOrDefault().CaptainOrOrganizName:null;
                await _db.Participant.AddAsync(Participant);
                await _db.SaveChangesAsync();

                return Participant.Id;
            }
            return 0;
        }
        public async Task UpdateParticipant(Participants Participant)
        {
            if (_db != null)
            {
                //Delete that post
                Participant.CaptainOrOrganization = _db.CaptainOrOrganizations.Where(CO => CO.Id == Participant.CaptainOrOrganizationId).FirstOrDefault().CaptainOrOrganizName;
                _db.Participant.Update(Participant);

                //Commit the transaction
                await _db.SaveChangesAsync();
            }
        }
        public Participants GetParticipantbyId(int Id)
        {
            if (_db != null)
            {
                return _db.Participant.Find(Id); ;
            }

            return null;
        }
        #endregion
        #region CaptainOrOraga
        public async Task<List<CaptainOrOrganization>> GetCaptainOrOrg()
        {
            if (_db != null)
            {
                return await _db.CaptainOrOrganizations.Where(CapOrg => CapOrg.DeleteDate == null).ToListAsync();
            }

            return null;
        }
        public async Task<int> AddCaptainOrOrg(CaptainOrOrganization CaptainOrOrg)
        {
            if (_db != null)
            {
                CaptainOrOrg.CityName = _db.City.Where(Cit => Cit.CityCode == CaptainOrOrg.City).FirstOrDefault().City;
                await _db.CaptainOrOrganizations.AddAsync(CaptainOrOrg);
                await _db.SaveChangesAsync();

                return CaptainOrOrg.Id;
            }
            return 0;
        }
        public async Task UpdateCaptainOrOrg(CaptainOrOrganization CaptainOrOrg)
        {
            if (_db != null)
            {
                //Delete that post
                CaptainOrOrg.CityName = _db.City.Where(Cit => Cit.CityCode == CaptainOrOrg.City).FirstOrDefault().City;
                _db.CaptainOrOrganizations.Update(CaptainOrOrg);

                //Commit the transaction
                await _db.SaveChangesAsync();
            }
        }
        public CaptainOrOrganization GetCaptainOrOrgbyId(int Id)
        {
            if (_db != null)
            {
                return _db.CaptainOrOrganizations.Find(Id); ;
            }

            return null;
        }
        public async Task<List<Cities>> GetCities()
        {
            if (_db != null)
            {
                return await _db.City.ToListAsync();
            }

            return null;
        }
        public async Task<List<CaptainOrOrganization>> GetAllCaptain()
        {
            if (_db != null)
            {
                return await _db.CaptainOrOrganizations.Where(x=>x.DeleteDate == null).ToListAsync();
            }

            return null;
        }
        #endregion
    }
}
