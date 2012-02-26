using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextAdventureEngine.State;
using TextAdventureEngine.Locations;

namespace TextAdventureEngine.Objects.Directions
{
    public abstract class Direction : GameObject
    {
        public Direction(string name) : base(name)
        {
        }

        public abstract Func<Location,Location> Way{get;}

        public abstract Func<Location,Location> OppositeWay{get;}
    }

    public class North : Direction
    {
        public North() : base("north") { }

        public override Func<Location,Location> Way
        {
            get { return location => location.North; }
        }

        public override Func<Location, Location> OppositeWay
        {
            get { return location => location.South; }
        }
    }

    public class South : Direction
    {
        public South() : base("south") { }

        public override Func<Location, Location> Way
        {
            get { return location => location.South; }
        }

        public override Func<Location, Location> OppositeWay
        {
            get { return location => location.North; }
        }
    }

    public class East : Direction
    {
        public East() : base("east") { }

        public override Func<Location, Location> Way
        {
            get { return location => location.East; }
        }

        public override Func<Location, Location> OppositeWay
        {
            get { return location => location.West; }
        }
    }

    public class West : Direction
    {
        public West() : base("west") { }

        public override Func<Location, Location> Way
        {
            get { return location => location.West; }
        }

        public override Func<Location, Location> OppositeWay
        {
            get { return location => location.East; }
        }
    }

    public class Up : Direction
    {
        public Up() : base("up") { }

        public override Func<Location, Location> Way
        {
            get { return location => location.Up; }
        }

        public override Func<Location, Location> OppositeWay
        {
            get { return location => location.Down; }
        }
    }

    public class Down : Direction
    {
        public Down() : base("down") { }

        public override Func<Location, Location> Way
        {
            get { return location => location.Down; }
        }

        public override Func<Location, Location> OppositeWay
        {
            get { return location => location.Up; }
        }
    }
}
