using Game.Constants;
using Game.Dto;
using Game.Extensions;
using Game.Repository;
using System;
using System.Collections.Generic;

namespace Game.Business
{
    public class GameBusiness : IGameBusiness
    {
        public const int NUMBER_PLAYERS = 2;
        public const string ERROR_MESSAGE_STRATEGY_ERROR = "NoSuchStrategyError";
        public const string ERROR_MESSAGE_NUMBER_PLAYERS_INCORRECT = "WrongNumberOfPlayersError";
        public const string ERROR_MESSAGE_NUMBER_GAMES_INCORRECT = "WrongNumberOfGamesError";

        private readonly IGameRepository GameRepository;

        public GameBusiness(IGameRepository GameRepository)
        {
            this.GameRepository = GameRepository;
        }

        public GameBusiness()
           : this(new GameRepository())
        { }

        public string RpsGameWinner(TournamentDto tournament)
        {
            if (tournament.Games.Count % 2 != 0)
                throw new Exception(ERROR_MESSAGE_NUMBER_GAMES_INCORRECT);

            while (tournament.Games.Count > 1)
            {
                var winnersList = new List<PlayerDto>();

                foreach (var game in tournament.Games)
                {
                    var winPlayer = RunGame(game);
                    winnersList.Add(winPlayer);
                }

                tournament = GenerateNewTurn(winnersList);
            }
            var winningPlayer = RunGame(tournament.Games[0]);
            return $"['{winningPlayer.Name}', '{winningPlayer.Move}']";
        }

        public TournamentDto GenerateNewTurn(IList<PlayerDto> winnersList)
        {
            var newRound = new TournamentDto();

            for (int i = 0; i < winnersList.Count; i++)
            {
                if (i % 2 == 0)
                {
                    var list = new List<PlayerDto>
                    {
                        winnersList[i],
                        winnersList[i + 1]
                    };
                    newRound.Games.Add(new GameDto { Players = list });
                }
            }
            return newRound;
        }

        public PlayerDto RunGame(GameDto game)
        {
            if (game.Players.Count != NUMBER_PLAYERS)
                throw new Exception(ERROR_MESSAGE_NUMBER_PLAYERS_INCORRECT);

            var player1 = game.Players[0];
            var player2 = game.Players[1];

            if (player1.Move.EqualsIgnoreCase(player2.Move))
                return player1;

            switch (char.ToUpperInvariant(player1.Move))
            {
                case GameConstants.Rock:
                    return player2.Move.EqualsIgnoreCase(GameConstants.Scissor) ? player1 : player2;
                case GameConstants.Paper:
                    return player2.Move.EqualsIgnoreCase(GameConstants.Rock) ? player1 : player2;
                case GameConstants.Scissor:
                    return player2.Move.EqualsIgnoreCase(GameConstants.Paper) ? player1 : player2;
                default:
                    throw new Exception(message: ERROR_MESSAGE_STRATEGY_ERROR);
            }
        }
    }
}
