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
    public class ChampionshipService : IChampionshipService
    {
        private readonly ApplicationDbContext _db;
        public ChampionshipService(ApplicationDbContext db)
        {
            _db = db;
        }
        #region Racing
        public async Task<List<Championship>> GetChampionship()
        {
            if (_db != null)
            {
                return await _db.CSChampionships.Where(Par => Par.DeletedDate == null).ToListAsync();
            }

            return null;
        }
        public IEnumerable<ChampionshipDetails> GetChampionshipDetails(int ChampionshipId)
        {
            if (_db != null)
            {
                return _db.CSDChampionshipDetails.Where(CSD => CSD.ChampionshipId == ChampionshipId).ToList();
            }

            return null;
        }
        public int AddChampionship(Championship newChampionship, List<Participants> newParticipants)
        {
            if (_db != null)
            {
               
                _db.CSChampionships.Add(newChampionship);
                _db.SaveChanges();
                foreach (var item in newParticipants)
                {
                    ChampionshipDetails newChampionshipDetails = new ChampionshipDetails();
                    newChampionshipDetails.ParticipantId = item.Id;
                    newChampionshipDetails.ChampionshipId = newChampionship.Id;
                    _db.CSDChampionshipDetails.Add(newChampionshipDetails);
                    _db.SaveChanges();
                }
                return newChampionship.Id;
            }
            return 0;
        }
        public async Task<int> AddChampionshipDetails(int ChampionshipDetailsId, IEnumerable<int> SelectedRacing)
        {
            if (_db != null)
            {
                foreach (var item in SelectedRacing)
                {
                    ChampionShipwithRacing newChampionShipwithRacing = new ChampionShipwithRacing();
                    newChampionShipwithRacing.RacingId = item;
                    newChampionShipwithRacing.ChampionshipDetailsId = ChampionshipDetailsId;
                    _db.CWRChampionShipwithRacing.Add(newChampionShipwithRacing);
                    _db.SaveChanges();
                }              
                return 1;
            }
            return 0;
        }
        public async Task DeleteChampionship(Championship Championships)
        {
            if (_db != null)
            {
                //Delete that post

                _db.CSChampionships.Update(Championships);
                //Commit the transaction
                _db.SaveChanges();              
            }
        }
        public async Task UpdateChampionship(Championship Championships,List<Participants> newParticipants)
        {
            if (_db != null)
            {
                //Delete that post

                _db.CSChampionships.Update(Championships);
                //Commit the transaction
                 _db.SaveChanges();           
            }
        }
        public Championship GetChampionshipbyId(int Id)
        {
            if (_db != null)
            {
                return _db.CSChampionships.Find(Id); ;
            }

            return null;
        }
        public List<Racing> GetSelectedRacing(IEnumerable<int> selectedRecing)
        {
            if (_db != null)
            {

                List<Racing> retSR = new List<Racing>();
                var Rac = new Racing();
                foreach (var item in selectedRecing)
                {
                    Rac= _db.Racings.Find(item);
                    retSR.Add(Rac);
                }

                return retSR;
            }
            return null;
        }
        public async Task<List<Participants>> GetParticipants(int ChampionId)
        {
            if (_db != null)
            {
                List<Participants> newParticipants = new List<Participants>();
              var ListOfParticipatesId =  _db.CSDChampionshipDetails.Where(chd => chd.ChampionshipId == ChampionId).ToList().Select(a=>a.ParticipantId);                                                 
                return await _db.Participant.Where(r => ListOfParticipatesId.Contains(r.Id)).ToListAsync();
            }

            return null;
        }
        public IEnumerable<int> GetChampionRacingDetails(int ChampionId,int PartiId)
        {
            if (_db != null)
            {
                if (ChampionId !=0 && PartiId !=0)
                {
                    var IDOfCSD = _db.CSDChampionshipDetails.Where(CSD => CSD.ChampionshipId == ChampionId && CSD.ParticipantId == PartiId).FirstOrDefault().Id;
                    return _db.CWRChampionShipwithRacing.Where(CWR => CWR.ChampionshipDetailsId == IDOfCSD).Select(x => x.RacingId);
                }
             
            }

            return null;
        }
        public async Task<int> AddChampionshipRacingDetails( IEnumerable<int> SelectedchampiRacing,int ChampionId,int PartiID)
        {
            if (_db != null)
            {
                var IDOfCSD = _db.CSDChampionshipDetails.Where(CSD => CSD.ChampionshipId == ChampionId && CSD.ParticipantId == PartiID).FirstOrDefault().Id;
                var GetOldDetails= _db.CWRChampionShipwithRacing.Where(CWR => CWR.ChampionshipDetailsId == IDOfCSD);
                if (GetOldDetails !=null)
                {
                    _db.RemoveRange(GetOldDetails);
                    _db.SaveChanges();
                }
                foreach (var item in SelectedchampiRacing)
                {
                    ChampionShipwithRacing newChampionShipwithRacing = new ChampionShipwithRacing();
                    newChampionShipwithRacing.RacingId = item;
                    newChampionShipwithRacing.ChampionshipDetailsId = IDOfCSD;
                    _db.Add(newChampionShipwithRacing);
                    _db.SaveChanges();
                }
                return 1;
            }
            return 0;
        }
        public async Task<List<Racing>> GetRacingOfCS(int ChampionShipId)
        {
            if (_db != null)
            {
              var GetCSDId=  _db.CSDChampionshipDetails.Where(CS => CS.ChampionshipId == ChampionShipId).Select(x=>x.Id).ToList();
              var GETRCIDs=  _db.CWRChampionShipwithRacing.Where(r => GetCSDId.Contains(r.ChampionshipDetailsId)).Select(z=>z.RacingId).ToList();
                var GETAllRacingInCS =await _db.Racings.Where(r => GETRCIDs.Contains(r.Id)).ToListAsync();
                return  GETAllRacingInCS;
            }

            return null;
        }
        public  List<Participants> GetPartiOfRac(int RacingId, int ChampionId)
        {
            if (_db != null)
            {
                var GetCSDId = _db.CSDChampionshipDetails.Where(CS => CS.ChampionshipId == ChampionId).ToList();
                var GETRCIDs = _db.CWRChampionShipwithRacing.Where(r =>r.RacingId== RacingId).ToList();
                var GetPartiId = (from x in GetCSDId join t in GETRCIDs on x.Id equals t.ChampionshipDetailsId select x).Select(z=>z.ParticipantId).ToList();
                var GetParti=  _db.Participant.Where(r => GetPartiId.Contains(r.Id)).ToList();
                return GetParti;
            }

            return null;
        }
        public async Task DeleteChampionshipwithRa(int ChampionshipId, Participants Participants)
        {
            if (_db != null)
            {
                //Delete that post


                var IDOfCSD = _db.CSDChampionshipDetails.Where(CSD => CSD.ChampionshipId == ChampionshipId && CSD.ParticipantId == Participants.Id).FirstOrDefault();
                var GetOldDetails = _db.CWRChampionShipwithRacing.Where(CWR => CWR.ChampionshipDetailsId == IDOfCSD.Id);
                _db.RemoveRange(GetOldDetails);
                _db.SaveChanges();
                _db.CSDChampionshipDetails.Remove(IDOfCSD);
                _db.SaveChanges();
            }
        }
        public int AddNewParti(int ChampionshipId,int newParticipantId)
        {
            if (_db != null)
            {              
                    ChampionshipDetails newChampionshipDetails = new ChampionshipDetails();
                    newChampionshipDetails.ParticipantId = newParticipantId;
                    newChampionshipDetails.ChampionshipId = ChampionshipId;
                    _db.CSDChampionshipDetails.Add(newChampionshipDetails);
                    _db.SaveChanges();
                return 1;
            }
            return 0;
        }
        public int GetChampionRacingDetailsUpdate(int ChampionId, int PartiId,int RacingId)
        {
            if (_db != null)
            {
                if (ChampionId != 0 && PartiId != 0)
                {
                    var IDOfCSD = _db.CSDChampionshipDetails.Where(CSD => CSD.ChampionshipId == ChampionId && CSD.ParticipantId == PartiId).FirstOrDefault().Id;
                    return _db.CWRChampionShipwithRacing.Where(CWR => CWR.ChampionshipDetailsId == IDOfCSD && CWR.RacingId== RacingId).Select(x => x.Id).FirstOrDefault();
                }
            }
            return 0;
        }
        public async Task<int> AddNewResults(ChampionShipwithRacing newChampionShipwithRacing)
        {
            if (_db != null)
            {
               var GetCWR= _db.CWRChampionShipwithRacing.Find(newChampionShipwithRacing.Id);
                GetCWR.Result = newChampionShipwithRacing.Result;
                _db.CWRChampionShipwithRacing.Update(GetCWR);
                //Commit the transaction
                _db.SaveChanges();
                return 1;
            }
            return 0;
        }
        #endregion    
    }
}
