using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    //enums for the state of the slingshot, the 
    //state of the game and the state of the bird

    public enum GameState
    {
        ReadyToLaunch,
        Dragging,
        BirdFlying,
        Win,
        Lose
    }

    public enum Tags
    {
        Floor,
        Bird,
    }


    public enum BirdState
    {
        BeforeThrown,
        Thrown
    }
    
}
