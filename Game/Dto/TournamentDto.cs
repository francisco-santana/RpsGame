using System.Collections.Generic;

namespace Game.Dto
{
    public class TournamentDto
    {
        public IList<GameDto> Games { get; set; }

        public TournamentDto()
        {
            Games = new List<GameDto>();
        }
    }
}
