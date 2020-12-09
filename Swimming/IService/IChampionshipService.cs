using Swimming.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swimming.IService
{
    public interface IChampionshipService
    {
        #region Champions
        Task<List<Championship>> GetChampionship();
        IEnumerable<ChampionshipDetails> GetChampionshipDetails(int ChampionshipId);
        int AddChampionship(Championship newChampionship, List<Participants> newParticipants);
        Task UpdateChampionship(Championship Championships, List<Participants> newParticipants);
        Championship GetChampionshipbyId(int Id);
        List<Racing> GetSelectedRacing(IEnumerable<int> selectedRecing);
        Task<int> AddChampionshipDetails(int ChampionshipDetailsId, IEnumerable<int> SelectedRacing);
        Task<List<Participants>> GetParticipants(int ChampionId);
        IEnumerable<int> GetChampionRacingDetails(int ChampionId, int PartiId);
        Task<int> AddChampionshipRacingDetails(IEnumerable<int> SelectedchampiRacing, int ChampionId, int PartiID);
        Task DeleteChampionship(Championship Championships);
        Task<List<Racing>> GetRacingOfCS(int ChampionShipId);
        PartiWLastResult[] GetPartiOfRac(int RacingId, int ChampionId);
        Task DeleteChampionshipwithRa(int ChampionshipId, Participants Participants);
        int AddNewParti(int ChampionshipId, int newParticipantId);
        int GetChampionRacingDetailsUpdate(int ChampionId, int PartiId, int RacingId);
        Task<int> AddNewResults(ChampionShipwithRacing newChampionShipwithRacing);
        Task<AllRacingData[]> GetResultAsync(int ChampionId);
        Task<AllRacingDataFins[]> GetResultFinsAsync(int ChampionId);
        int Addfinal(int ChampionId);
        ResultOfRacingFree[] GetPointsFreeAsync(int ChampionId);
        ResultOfRacingFins[] GetPointsFinsAsync(int ChampionId);
        List<Championship> GetNewChampionship();
        #endregion
    }
}
