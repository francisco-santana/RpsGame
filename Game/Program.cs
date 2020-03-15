using Game.Business;
using Game.Repository;
using System;

namespace Game
{
    public class Program
    {
        private static IGameBusiness _gameBusiness;
        private static IGameRepository _gameRepository;
        

        static void Main(string[] args)
        {
            _gameBusiness = new GameBusiness();
            _gameRepository = new GameRepository();

            try
            {
                Console.WriteLine(_gameBusiness.RpsGameWinner(_gameRepository.GetTournament()));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();

        }
    }
}
