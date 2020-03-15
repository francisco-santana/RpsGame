using System.Collections.Generic;

namespace Game.Dto
{
    public class GameDto
    {
        public IList<PlayerDto> Players { get; set; }

        public GameDto()
        {
            Players = new List<PlayerDto>();
        }
    }
}
