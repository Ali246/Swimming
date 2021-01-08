using Microsoft.EntityFrameworkCore;
using Swimming.Data;
using Swimming.IService;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Radzen;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Internal;

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
                Addsal(5);
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
                   // _db.CSDChampionshipDetails.Add(newChampionshipDetails);
                    _db.Add(newChampionshipDetails);
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
        public PartiWLastResult[] GetPartiOfRac(int RacingId, int ChampionId)
        {
            if (_db != null)
            {
                SqlParameter param1 = new SqlParameter("@RacingId", RacingId);
                SqlParameter param2 = new SqlParameter("@ChampionshipId", ChampionId);
                PartiWLastResult[] ResultsFreePoints;
                ResultsFreePoints = _db.PartiWLastResults.FromSqlRaw
                           ("EXECUTE dbo.GetPartiWithlastResults @RacingId,@ChampionshipId", param1, param2)
                    .ToArray();
                return ResultsFreePoints;
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
                    //var IDOfCSD = _db.CSDChampionshipDetails.Where(CSD => CSD.ChampionshipId == ChampionId && CSD.ParticipantId == PartiId).FirstOrDefault().Id;
                    return _db.CWRChampionShipwithRacing.Find(PartiId).Id;
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
        public async Task<AllRacingData[]> GetResultAsync(int ChampionId)
        {
            AllRacingData[] ResultsObjs;
            SqlParameter param1 = new SqlParameter("@ChampionId", ChampionId);
            ResultsObjs = _db.AllRacingDataTBL.FromSqlRaw
                        ("EXECUTE dbo.GetAllRacingData @ChampionId", param1)
                .ToArray();
            return ResultsObjs;
        }
        public async Task<AllRacingDataFins[]> GetResultFinsAsync(int ChampionId)
        {
            AllRacingDataFins[] ResultsFinsObjs;
            SqlParameter param1 = new SqlParameter("@ChampionId", ChampionId);
            ResultsFinsObjs = _db.AllRacingFindDataTBL.FromSqlRaw
                        ("EXECUTE dbo.GetAllRacingDataFins @ChampionId", param1)
                .ToArray();
            return ResultsFinsObjs;
        }

        public  int Addfinal(int ChampionId)
        {
            if (_db != null)
            {
                List<int> Gender=new List<int>();
                Gender.Add(0);
                Gender.Add(1);
                var RacingId = _db.Racings.ToList().Select(r=>r.Id).ToList();
                List<int> YEARS = new List<int>();              
                foreach (var RacingIds in RacingId)
                {
                    YEARS = _db.RacingDetail.Where(s => s.RacingId == RacingIds).Select(rd => rd.Year).ToList();
                    foreach (var Genders in Gender)
                    {
                       
                        foreach (var YEAR in YEARS)
                        {
                            SqlParameter param1 = new SqlParameter("@Year", YEAR);
                            SqlParameter param2 = new SqlParameter("@Gender", Genders);
                            SqlParameter param3 = new SqlParameter("@RacingId", RacingIds);
                            SqlParameter param4 = new SqlParameter("@ChampionshipId", ChampionId);
                            RACWITHCH[] RACWITHCHObjs;

                            RACWITHCHObjs = _db.RACWITHCHTBL.FromSqlRaw
                                        ("EXECUTE dbo.Getchampionwithracing @Year,@Gender,@RacingId,@ChampionshipId", param1, param2, param3, param4)
                                .ToArray();
                            if (RACWITHCHObjs.Length !=0)
                            {
                                ChampionShipwithRacing newChampionShipwithRacing = new ChampionShipwithRacing();
                                int count = 0;
                                double last = 0;
                                foreach (var item in RACWITHCHObjs)
                                {                                   
                                    if (item.Result !=0) 
                                    {
                                        count = count + 1;                                      
                                        if (last == item.Result)
                                        {
                                            count = count - 1;
                                        }                                                                            
                                        var x = _db.CWRChampionShipwithRacing.Find(item.Id);
                                        x.placeNo = count;
                                        x.Points = count == 1 ? 40 : count == 2 ? 30 : count == 3 ? 20 : 0;
                                        _db.Update(x);
                                        _db.SaveChanges();
                                        last = item.Result;
                                    }                                   
                                }
                            }
                          
                        }
                       
                    }

                  
                }
                return 1;
            }
            return 0;
        }
        public ResultOfRacingFree[] GetPointsFreeAsync(int ChampionId)
        {

            SqlParameter param1 = new SqlParameter("@RacingType", 1);
            SqlParameter param2 = new SqlParameter("@ChampionId", ChampionId);
            ResultOfRacingFree[] ResultsFreePoints;
            ResultsFreePoints = _db.ResultOfRacingFrees.FromSqlRaw
                       ("EXECUTE dbo.GetTheResultOfFree @RacingType,@ChampionId", param1, param2)
                .ToArray();
            return ResultsFreePoints;
        }
        public ResultOfRacingFins[] GetPointsFinsAsync(int ChampionId)
        {
            SqlParameter param1 = new SqlParameter("@RacingType", 2);
            SqlParameter param2 = new SqlParameter("@ChampionId", ChampionId);
            ResultOfRacingFins[] ResultsFinsPoints;
            ResultsFinsPoints = _db.ResultOfRacingFin.FromSqlRaw
                        ("EXECUTE dbo.GetTheResultOfFree @RacingType,@ChampionId", param1, param2)
                .ToArray();
            return ResultsFinsPoints;
        }
        public List<Championship> GetNewChampionship()
        {
            if (_db != null)
            {
                return  _db.CSChampionships.Where(Par => Par.DeletedDate == null).ToList();
            }

            return null;
        }

        public int Addsal(int ChampionId)
         {
            if (_db != null)
            {
                List<int> Gender = new List<int>();
                Gender.Add(0);
                Gender.Add(1);
                var RacingId = _db.Racings.ToList().Select(r => r.Id).ToList();               
                int count = 1;
                List<int> YEARS = new List<int>();
                foreach (var RacingIds in RacingId)
                {

                    YEARS = _db.RacingDetail.Where(s => s.RacingId == RacingIds).Select(rd => rd.Year).ToList();
                    foreach (var itemYEARS in YEARS)
                    {
                        foreach (var itemGender in Gender)
                        {
                            SqlParameter param1 = new SqlParameter("@Year", itemYEARS);
                            SqlParameter param2 = new SqlParameter("@Gender", itemGender);
                            SqlParameter param3 = new SqlParameter("@RacingId", RacingIds);
                            SqlParameter param4 = new SqlParameter("@ChampionshipId", ChampionId);
                            PartiWRacing[] RACWITHPartiObjs;

                            RACWITHPartiObjs = _db.PartiWRacingTBL.FromSqlRaw
                                        ("EXECUTE dbo.GetPartiwithracing  @Year,@Gender,@RacingId,@ChampionshipId", param1, param2, param3, param4)
                                .ToArray();                                                       
                            if (RACWITHPartiObjs.Length != 0)
                            {
                                //لو العدد الي جي ==6
                                if (RACWITHPartiObjs.Length == 6)
                                {
                                    ChampionShipwithRacing newChampionShipwithRacing = new ChampionShipwithRacing();                                   
                                    var NewQualifier = new Qualifier();
                                    NewQualifier.Name = "H" + count;
                                    NewQualifier.ChampionId = ChampionId;
                                    NewQualifier.RacingId = RacingIds;
                                    _db.Qualifiers.Add(NewQualifier);
                                    _db.SaveChanges();
                                    foreach (var item in RACWITHPartiObjs)
                                    {
                                        var NewQualifierDetail = new QualifierDetail();
                                        NewQualifierDetail.PartiId = item.ParticipantId;
                                        NewQualifierDetail.QualifierId = NewQualifier.Id;
                                        var getAddedQualifier = _db.Qualifiers.Where(Q => Q.RacingId == RacingIds && Q.ChampionId == ChampionId).Select(Qs => Qs.Id).ToList();
                                        var GETQualifierDetails = _db.QualifierDetails.Where(r => getAddedQualifier.Contains(r.QualifierId) && r.PartiId == item.ParticipantId).ToList().Count;
                                        if (GETQualifierDetails == 0)
                                        {
                                            _db.QualifierDetails.Add(NewQualifierDetail);
                                            _db.SaveChanges();                                          
                                        }
                                    }
                                    count++;
                                }
                                //لو اكبر من ال 6
                                else if (RACWITHPartiObjs.Length > 6)
                                {
                                    //ChampionShipwithRacing newChampionShipwithRacing = new ChampionShipwithRacing();
                                  //بقسم علي ال 6
                                    var Divisions =
                                           RACWITHPartiObjs.Select((x, i) => new { Index = i, Value = x })
                                          .GroupBy(x => x.Index / 6)
                                          .Select(x => x.Select(v => v.Value).ToList())
                                          .ToList();
                                    int ru = 0;
                                    foreach (var itemDivisions in Divisions)
                                    {
                                        int itemAdded = 0;
                                        //لو التقسيمة طلعيت مجموعة من 6
                                        if (itemDivisions.Count==6)
                                        {
                                            var NewQualifier = new Qualifier();
                                            NewQualifier.Name = "H" + count;
                                            NewQualifier.ChampionId = ChampionId;
                                            NewQualifier.RacingId = RacingIds;
                                            _db.Qualifiers.Add(NewQualifier);
                                            _db.SaveChanges();
                                            foreach (var item in itemDivisions)
                                            {                                               
                                                var NewQualifierDetail = new QualifierDetail();
                                                NewQualifierDetail.PartiId = item.ParticipantId;
                                                NewQualifierDetail.QualifierId = NewQualifier.Id;
                                                var getAddedQualifier = _db.Qualifiers.Where(Q => Q.RacingId == RacingIds && Q.ChampionId == ChampionId).Select(Qs => Qs.Id).ToList();
                                                var GETQualifierDetails = _db.QualifierDetails.Where(r => getAddedQualifier.Contains(r.QualifierId) && r.PartiId == item.ParticipantId).ToList().Count;
                                                if (GETQualifierDetails == 0)
                                                {
                                                    _db.QualifierDetails.Add(NewQualifierDetail);
                                                    _db.SaveChanges();
                                                }
                                            }
                                            itemAdded = 6;
                                            count++;
                                            ru = 6;
                                        }
                                        //لو التقسيمة طلعيت مجموعة اصغر 6
                                        else if (itemDivisions.Count < 6)
                                        {
                                            var NewQualifiers1 = new Qualifier();
                                            NewQualifiers1.Name = "H" + count;
                                            NewQualifiers1.ChampionId = ChampionId;
                                            NewQualifiers1.RacingId = RacingIds;
                                            _db.Qualifiers.Add(NewQualifiers1);
                                            _db.SaveChanges();

                                            foreach (var itemitemDivisions in itemDivisions)
                                            {
                                                var NewQualifierDetail = new QualifierDetail();
                                                NewQualifierDetail.PartiId = itemitemDivisions.ParticipantId;
                                                NewQualifierDetail.QualifierId = NewQualifiers1.Id;
                                                var getAddedQualifier = _db.Qualifiers.Where(Q => Q.RacingId == RacingIds && Q.ChampionId == ChampionId).Select(Qs => Qs.Id).ToList();
                                                var GETQualifierDetails = _db.QualifierDetails.Where(r => getAddedQualifier.Contains(r.QualifierId) && r.PartiId == itemitemDivisions.ParticipantId).ToList().Count;
                                                if (GETQualifierDetails == 0 && itemAdded<6)
                                                {
                                                    _db.QualifierDetails.Add(NewQualifierDetail);
                                                    _db.SaveChanges();
                                                    itemAdded++;
                                                    ru++;
                                                }                                                
                                            }
                                            if (itemAdded < 6)
                                            {
                                                SqlParameter param11 = new SqlParameter("@Year", itemYEARS);
                                                SqlParameter param12 = new SqlParameter("@Gender", itemGender == 1 ? 0 : 1);
                                                SqlParameter param13 = new SqlParameter("@RacingId", RacingIds);
                                                SqlParameter param14 = new SqlParameter("@ChampionshipId", ChampionId);
                                                SqlParameter param15 = new SqlParameter("@top", (6 - itemAdded));
                                                PartiWRacing[] RACWITHPartiObjss;

                                                RACWITHPartiObjss = _db.PartiWRacingTBL.FromSqlRaw
                                                            ("EXECUTE dbo.GettopPartiwithracing  @Year,@Gender,@RacingId,@ChampionshipId,@top", param11, param12, param13, param14, param15)
                                                    .ToArray();
                                                foreach (var itemRACWITHPartiObjss in RACWITHPartiObjss)
                                                {
                                                    var NewQualifierDetails = new QualifierDetail();
                                                    NewQualifierDetails.PartiId = itemRACWITHPartiObjss.ParticipantId;
                                                    NewQualifierDetails.QualifierId = NewQualifiers1.Id;
                                                    var getAddedQualifiers = _db.Qualifiers.Where(Q => Q.RacingId == RacingIds && Q.ChampionId == ChampionId).Select(Qs => Qs.Id).ToList();
                                                    var GETQualifierDetailss = _db.QualifierDetails.Where(r => getAddedQualifiers.Contains(r.QualifierId) && r.PartiId == itemRACWITHPartiObjss.ParticipantId).ToList().Count;
                                                    if (GETQualifierDetailss == 0 && itemAdded < 6)
                                                    {
                                                        _db.QualifierDetails.Add(NewQualifierDetails);
                                                        _db.SaveChanges();
                                                        itemAdded++;
                                                        ru++;
                                                    }
                                                }
                                            }
                                            if (itemAdded < 6)
                                            {
                                               
                                                foreach (var iteYEARS in YEARS)
                                                {
                                                    PartiWRacing[] RACWITHPartiObjs21sd;
                                                    foreach (var iteGender in Gender)
                                                    {
                                                        SqlParameter param21 = new SqlParameter("@Year", itemYEARS);
                                                        SqlParameter param22 = new SqlParameter("@Gender", itemGender);
                                                        SqlParameter param23 = new SqlParameter("@RacingId", RacingIds);
                                                        SqlParameter param24 = new SqlParameter("@ChampionshipId", ChampionId);
                                                        SqlParameter param25 = new SqlParameter("@top", (6 - itemAdded));

                                                        RACWITHPartiObjs21sd = _db.PartiWRacingTBL.FromSqlRaw
                                                                    ("EXECUTE dbo.GettopPartiwithracing  @Year,@Gender,@RacingId,@ChampionshipId,@top", param21, param22, param23, param24, param25)
                                                            .ToArray();
                                                        foreach (var RACWITHPartiObjs21s in RACWITHPartiObjs21sd)
                                                        {
                                                            var NewQualifierDetails = new QualifierDetail();
                                                            NewQualifierDetails.PartiId = RACWITHPartiObjs21s.ParticipantId;
                                                            NewQualifierDetails.QualifierId = NewQualifiers1.Id;
                                                            var getAddedQualifiers = _db.Qualifiers.Where(Q => Q.RacingId == RacingIds && Q.ChampionId == ChampionId).Select(Qs => Qs.Id).ToList();
                                                            var GETQualifierDetailss = _db.QualifierDetails.Where(r => getAddedQualifiers.Contains(r.QualifierId) && r.PartiId == RACWITHPartiObjs21s.ParticipantId).ToList().Count;
                                                            if (GETQualifierDetailss == 0 && itemAdded < 6)
                                                            {
                                                                _db.QualifierDetails.Add(NewQualifierDetails);
                                                                _db.SaveChanges();
                                                                itemAdded++;
                                                                ru++;
                                                            }
                                                        }                                                       
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    if (ru > 0)
                                    {
                                        count++;
                                    }
                                   
                                }
                                else if (RACWITHPartiObjs.Length < 6)
                                {
                                   
                                    int itemAdded = 0;                                                                               
                                            var NewQualifiersr = new Qualifier();
                                    NewQualifiersr.Name = "H" + count;
                                    NewQualifiersr.ChampionId = ChampionId;
                                    NewQualifiersr.RacingId = RacingIds;
                                            _db.Qualifiers.Add(NewQualifiersr);
                                            _db.SaveChanges();
                                    
                                    foreach (var itemitemDivisions in RACWITHPartiObjs)
                                            {
                                                var NewQualifierDetail = new QualifierDetail();
                                                NewQualifierDetail.PartiId = itemitemDivisions.ParticipantId;
                                                NewQualifierDetail.QualifierId = NewQualifiersr.Id;
                                                var getAddedQualifier = _db.Qualifiers.Where(Q => Q.RacingId == RacingIds && Q.ChampionId == ChampionId).Select(Qs => Qs.Id).ToList();
                                                var GETQualifierDetails = _db.QualifierDetails.Where(r => getAddedQualifier.Contains(r.QualifierId) && r.PartiId == itemitemDivisions.ParticipantId).ToList().Count;
                                                if (GETQualifierDetails == 0 && itemAdded < 6)
                                                {
                                                    _db.QualifierDetails.Add(NewQualifierDetail);
                                                    _db.SaveChanges();
                                                    itemAdded++;
                                                }
                                            }
                                            if (itemAdded < 6)
                                            {
                                                SqlParameter param11 = new SqlParameter("@Year", itemYEARS);
                                                SqlParameter param12 = new SqlParameter("@Gender", itemGender == 1 ? 0 : 1);
                                                SqlParameter param13 = new SqlParameter("@RacingId", RacingIds);
                                                SqlParameter param14 = new SqlParameter("@ChampionshipId", ChampionId);
                                                SqlParameter param15 = new SqlParameter("@top", (6 - itemAdded));
                                                PartiWRacing[] RACWITHPartiObjss21;

                                        RACWITHPartiObjss21 = _db.PartiWRacingTBL.FromSqlRaw
                                                            ("EXECUTE dbo.GettopPartiwithracing  @Year,@Gender,@RacingId,@ChampionshipId,@top", param11, param12, param13, param14, param15)
                                                    .ToArray();
                                                foreach (var itemRACWITHPartiObjss in RACWITHPartiObjss21)
                                                {
                                                    var NewQualifierDetails = new QualifierDetail();
                                                    NewQualifierDetails.PartiId = itemRACWITHPartiObjss.ParticipantId;
                                                    NewQualifierDetails.QualifierId = NewQualifiersr.Id;
                                                    var getAddedQualifiers = _db.Qualifiers.Where(Q => Q.RacingId == RacingIds && Q.ChampionId == ChampionId).Select(Qs => Qs.Id).ToList();
                                                    var GETQualifierDetailss = _db.QualifierDetails.Where(r => getAddedQualifiers.Contains(r.QualifierId) && r.PartiId == itemRACWITHPartiObjss.ParticipantId).ToList().Count;
                                                    if (GETQualifierDetailss == 0 && itemAdded < 6)
                                                    {
                                                        _db.QualifierDetails.Add(NewQualifierDetails);
                                                        _db.SaveChanges();
                                                        itemAdded++;
                                                    }
                                                }
                                            }
                                            if (itemAdded < 6)
                                            {
                                                foreach (var iteYEARS in YEARS)
                                                {
                                                    foreach (var iteGender in Gender)
                                                    {
                                                        SqlParameter param21 = new SqlParameter("@Year", itemYEARS);
                                                        SqlParameter param22 = new SqlParameter("@Gender", itemGender);
                                                        SqlParameter param23 = new SqlParameter("@RacingId", RacingIds);
                                                        SqlParameter param24 = new SqlParameter("@ChampionshipId", ChampionId);
                                                        SqlParameter param25 = new SqlParameter("@top", (6 - itemAdded));
                                                PartiWRacing[] RACWITHPartiObjs21;

                                                        RACWITHPartiObjs21 = _db.PartiWRacingTBL.FromSqlRaw
                                                                     ("EXECUTE dbo.GettopPartiwithracing  @Year,@Gender,@RacingId,@ChampionshipId,@top", param21, param22, param23, param24, param25)
                                                            .ToArray();
                                                        foreach (var RACWITHPartiObjs21s in RACWITHPartiObjs21)
                                                        {
                                                            var NewQualifierDetails = new QualifierDetail();
                                                            NewQualifierDetails.PartiId = RACWITHPartiObjs21s.ParticipantId;
                                                            NewQualifierDetails.QualifierId = NewQualifiersr.Id;
                                                            var getAddedQualifiers = _db.Qualifiers.Where(Q => Q.RacingId == RacingIds && Q.ChampionId == ChampionId).Select(Qs => Qs.Id).ToList();
                                                            var GETQualifierDetailss = _db.QualifierDetails.Where(r => getAddedQualifiers.Contains(r.QualifierId) && r.PartiId == RACWITHPartiObjs21s.ParticipantId).ToList().Count;
                                                            if (GETQualifierDetailss == 0 && itemAdded < 6)
                                                            {
                                                                _db.QualifierDetails.Add(NewQualifierDetails);
                                                                _db.SaveChanges();
                                                                itemAdded++;
                                                            }
                                                        }                                               
                                                    }
                                                }
                                            }
                                    if (itemAdded > 0)
                                    {
                                        count++;
                                    }
                                }
                            }                           
                        }
                    }
                }
                return 1;
            }
            return 0;
        }
        #endregion    
    }
}
