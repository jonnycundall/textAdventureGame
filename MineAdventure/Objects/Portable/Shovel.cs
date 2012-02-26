using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextAdventureEngine.Objects;

namespace MineAdventure.Objects.Portable
{
    public class Shovel : GameObject
    {
        public Shovel() : base("shovel")
        {
            IsPortable = true;
        }
    }
}
