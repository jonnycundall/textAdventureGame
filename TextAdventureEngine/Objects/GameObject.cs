using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextAdventureEngine.Parsing;

namespace TextAdventureEngine.Objects
{
    public abstract class GameObject : IWord
    {
        protected GameObject(string name)
        {
            Name = name;
        }

        public string Word{get{ return Name;}}

        public virtual string Description { get { return string.Format("There is a {0} here. ", Name); } }

        public bool IsPortable { get; protected set; }

        public string Name { get; private set; }
    }
}
