using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GameExChange.Business.Input.GameBusniess
{
    public class GameAddInput
    {
        public GameExChange.Entity.Game Entity { set; get; }

        public GameExChange.Entity.User User { set; get; }
    }
}