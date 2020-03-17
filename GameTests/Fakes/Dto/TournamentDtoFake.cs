using Game.Constants;
using Game.Dto;

namespace GameTests.Fakes.Dto
{
    public static class TournamentDtoFake
    {
        public static TournamentDto GetValidTournament()
        {
            var tournament = new TournamentDto();            
            tournament.Games.Add(GameDtoFake.GetGame1());
            tournament.Games.Add(GameDtoFake.GetGame2());

            return tournament;
        }

        public static TournamentDto GetTournamentWithWrongMove()
        {
            var tournament = new TournamentDto();
            tournament.Games.Add(GameDtoFake.GetGame1());
            tournament.Games.Add(GameDtoFake.GetGameWithWrongMove());

            return tournament;
        }

        public static TournamentDto GetTournamentWithWrongNumberOfPlayers()
        {
            var tournament = new TournamentDto();
            tournament.Games.Add(GameDtoFake.GetGameWithWrongNumberOfPlayers());

            return tournament;
        }

        public static TournamentDto GetTournamentWithWrongNumberOfGames()
        {
            var tournament = new TournamentDto();
            tournament.Games.Add(GameDtoFake.GetGame1());
            tournament.Games.Add(GameDtoFake.GetGame1());
            tournament.Games.Add(GameDtoFake.GetGame1());

            return tournament;
        }
    }
}
