using System;
namespace TextAdventureEngine.State
{
    public interface IGameStateFactory
    {
        GameState Create();
    }
}
