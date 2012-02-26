using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MineAdventure.Objects.Portable;

namespace TextAdventureEngine.Locations
{
    public class MainShaft0 : Location
    {
        public MainShaft0()
            : base("The tunnel continues. ",
            "the tunnel end abruptly in a rock face to the South. ")
        { }
    }

    public class MainShaft1 : Location
    {
        public MainShaft1()
            : base("There is a flash, an ear splitting noise and confusion. you regain consciousness with little memeory of how you got here. ",
@"You are in a dark tunnel, with uneven timber columns supporting rickety timber beams overhead. 
Above the beams there is roughly cut rock, and it is almost as if you can feel the earth slowly strengthening its grip and preparing to crush the last tenuous resistance of the timbers. 
The passage continues to the north and the south.")
        {}
    }

    public class MainShaft2 : Location
    {
        public MainShaft2()
            : base("The tunnel continues. ", 
            "The timbers on both sides are heaving with weight, and to the east some have collapsed leaving a pile of rubble which you have to step around. There is water gushing down the west wall of the shaft.")
        {}
    }

    public class MainShaft3 : Location
    {
        public MainShaft3()
            : base("The air is damp, hot and smoky. It is hard to breathe. ", "The tunnel continues to the North and South, and there is a smaller shaft open to the East.")
        { }
    }

    public class MainShaft4 : Location
    {
        public MainShaft4()
            : base("You trip over something hard and heavy. ", "The way to the North is blocked by a mass of collapsed stone and timber. ")
        { 
            NearObjects.Add(new Shovel());
        }
    }

    public class EastShaft0 : Location
    {
        public EastShaft0()
            :base("You have to bend down to pass under a half collapsed beam. ",
            "You are in a narrower shaft, which continues to the East. You can hear heavy breathing further down the passage.")
        {}
    }

    public class EastShaft1 : Location
    {
        public EastShaft1()
            : base("The sound of breathing grows louder, and somethings moves as you approach. ",
            "The small shaft ends here in a stable. There is a miner lying on the floor, his leg trapped by a huge fallen beam.")
        { }
    }
}
