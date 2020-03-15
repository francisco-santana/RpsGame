using Game.Dto;

namespace Game.Repository
{
    public interface IGameRepository
    {
        TournamentDto GetTournament();
    }
}