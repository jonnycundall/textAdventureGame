using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAdventureEngine.Objects
{
    public abstract class GameObject
    {
        protected GameObject(string name)
        {
            Name = name;
        }

        public virtual string Description { get { return string.Format("There is a {0} here. ", Name); } }

        public bool IsPortable { get; protected set; }

        public string Name { get; private set; }
    }
}
