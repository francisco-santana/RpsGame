using Game.Dto;

namespace Game.Business
{
    public interface IGameBusiness
    {
        string RpsGameWinner(TournamentDto tournament);
    }
}