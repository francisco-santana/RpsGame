using FluentAssertions;
using Game.Dto;
using GameTests.Fakes.Dto;
using NUnit.Framework;
using System;
using System.Collections;

namespace Game.Business.Tests
{
    [TestFixture]
    public class GameBusinessTests
    {
        public const string ERROR_MESSAGE_NUMBER_PLAYERS_INCORRECT = "WrongNumberOfPlayersError";
        public const string ERROR_MESSAGE_NUMBER_GAMES_INCORRECT = "WrongNumberOfGamesError";
        public const string ERROR_MESSAGE_STRATEGY_ERROR = "NoSuchStrategyError";

        private IGameBusiness _gameBusiness;

        private static IEnumerable TestCasesForExceptions
        {
            get
            {
                yield return new TestCaseData(
                   TournamentDtoFake.GetTournamentWithWrongMove(),
                   ERROR_MESSAGE_STRATEGY_ERROR
                ).SetName("[GameBusiness] Should be return exception message for wrong choice of move");

                yield return new TestCaseData(
                   TournamentDtoFake.GetTournamentWithWrongNumberOfPlayers(),
                   ERROR_MESSAGE_NUMBER_PLAYERS_INCORRECT
                ).SetName("[GameBusiness] Should be return exception message for wrong number of players");

                yield return new TestCaseData(
                   TournamentDtoFake.GetTournamentWithWrongNumberOfGames(),
                   ERROR_MESSAGE_NUMBER_GAMES_INCORRECT
                ).SetName("[GameBusiness] Should be return exception message for wrong number of games");
            }
        }
        
        [SetUp]
        public void SetUp()
        {
            _gameBusiness = new GameBusiness();
        }

        [TestCase(TestName = "[GameBusiness] Should be return the winner of the tournament")]
        public void Should_be_return_the_winner_tournament()
        {
            var tournament = TournamentDtoFake.GetValidTournament();
            var obtained = _gameBusiness.RpsGameWinner(tournament);
            obtained.Should().BeEquivalentTo(PlayerDtoFake.GetWinnerPlayer.OutPutNameMove);
        }

        [TestCaseSource(nameof(TestCasesForExceptions))]
        public void Should_be_return_exception(TournamentDto tournament, string expectedException)
        {
            var obtained = Assert.Throws<Exception>(() => _gameBusiness.RpsGameWinner(tournament));
            obtained.Message.Should().Be(expectedException);
        }
    }
}