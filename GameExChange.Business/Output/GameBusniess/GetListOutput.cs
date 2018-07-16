using System;
using System.Collections.Generic;
using System.Text;
using GameEntity = GameExChange.Entity.Game;

namespace GameExChange.Business.Output.GameBusniess
{
    public class GetListOutput:BaseOutput
    {
        public List<GameEntity> Games { get; set; }
    }
}
