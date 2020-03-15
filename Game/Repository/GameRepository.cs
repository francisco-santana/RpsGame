using Game.Constants;
using Game.Dto;

namespace Game.Repository
{
    public class GameRepository : IGameRepository
    {
        public TournamentDto GetTournament()
        {
            var tournament = new TournamentDto();

            var game1 = new GameDto();
            game1.Players.Add(GetPlayer("Armando", GameConstants.Paper));
            game1.Players.Add(GetPlayer("Dave", GameConstants.Scissor));
            tournament.Games.Add(game1);

            var game2 = new GameDto();
            game2.Players.Add(GetPlayer("Richard", GameConstants.Rock));
            game2.Players.Add(GetPlayer("Michael", GameConstants.Scissor));
            tournament.Games.Add(game2);

            var game3 = new GameDto();
            game3.Players.Add(GetPlayer("Allen", GameConstants.Scissor));
            game3.Players.Add(GetPlayer("Omer", GameConstants.Paper));
            tournament.Games.Add(game3);

            var game4 = new GameDto();
            game4.Players.Add(GetPlayer("David E.", GameConstants.Rock));
            game4.Players.Add(GetPlayer("Richard X.", GameConstants.Paper));
            tournament.Games.Add(game4);
        
            return tournament;
        }

        private PlayerDto GetPlayer(string name, char move)
        {
            return new PlayerDto
            {
                Name = name,
                Move = move
            };
        }
    }
}
