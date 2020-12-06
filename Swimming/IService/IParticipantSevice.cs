using Swimming.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swimming.IService
{
   public interface IParticipantSevice
    {
        #region Participants
        Task<List<Participants>> GetParticipants();
        Task<int> AddParticipant(Participants Participant);
        Task UpdateParticipant(Participants Participant);
        Participants GetParticipantbyId(int Id);
        #endregion
        #region CaptainOrOrg
        Task<List<CaptainOrOrganization>> GetCaptainOrOrg();
        Task<int> AddCaptainOrOrg(CaptainOrOrganization CaptainOrOrg);
        Task UpdateCaptainOrOrg(CaptainOrOrganization CaptainOrOrg);
        CaptainOrOrganization GetCaptainOrOrgbyId(int Id);
        Task<List<Cities>> GetCities();
        Task<List<CaptainOrOrganization>> GetAllCaptain();
        #endregion
    }
}
