using Game.Constants;
using Game.Dto;

namespace GameTests.Fakes.Dto
{
    public static class GameDtoFake
    {
        public const char WRONG_MOVE = 'X';
        public const int WRONG_NUMBER_PLAYERS = 3;

        public static GameDto GetGame1()
        {
            var game1 = new GameDto();
            game1.Players.Add(PlayerDtoFake.GetPlayer(char.ToLower(GameConstants.Paper)));
            game1.Players.Add(PlayerDtoFake.GetPlayer(char.ToLower(GameConstants.Scissor)));
            return game1;
        }

        public static GameDto GetGame2(bool upperAndLowerCases = false)
        {
            var game2 = new GameDto();
            game2.Players.Add(PlayerDtoFake.GetPlayer(PlayerDtoFake.WINNER_PLAYER_NAME, PlayerDtoFake.WINNER_PLAYER_MOVE));
            game2.Players.Add(PlayerDtoFake.GetPlayer(GameConstants.Scissor));
            return game2;
        }

        public static GameDto GetGameWithWrongMove()
        {
            var game3 = new GameDto();
            game3.Players.Add(PlayerDtoFake.GetPlayer(WRONG_MOVE));
            game3.Players.Add(PlayerDtoFake.GetPlayer(GameConstants.Scissor));
            return game3;
        }

        public static GameDto GetGameWithWrongNumberOfPlayers()
        {
            var game3 = new GameDto();
            for (var i = 0; i < WRONG_NUMBER_PLAYERS; i++)
                game3.Players.Add(PlayerDtoFake.GetPlayer(GameConstants.Scissor));
            return game3;
        }
    }
}
