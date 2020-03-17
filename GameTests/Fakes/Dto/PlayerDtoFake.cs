using Game.Constants;
using Game.Dto;

namespace GameTests.Fakes.Dto
{
    public static class PlayerDtoFake
    {
        public const string PLAYER_NAME = "John Doe";
        public const string WINNER_PLAYER_NAME = "Richard";
        public const char WINNER_PLAYER_MOVE = GameConstants.Rock;

        public static PlayerDto GetWinnerPlayer => GetPlayer(WINNER_PLAYER_NAME, WINNER_PLAYER_MOVE);

        public static PlayerDto GetPlayer(char move)
        {
            return GetPlayer(PLAYER_NAME, move);
        }

        public static PlayerDto GetPlayer(string name, char move)
        {
            return new PlayerDto
            {
                Name = name,
                Move = move
            };
        }
    }
}
