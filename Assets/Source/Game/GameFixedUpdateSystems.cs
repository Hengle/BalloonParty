public class GameFixedUpdateSystems : Feature
{
    public GameFixedUpdateSystems(Contexts contexts)
    {
        // collisions
        Add(new BalloonCollisionSystem(contexts));

        // clean up
        Add(new Cleanup2DTriggersSystem(contexts));
    }
}