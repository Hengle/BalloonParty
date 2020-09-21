public class GameFixedUpdateSystems : Feature
{
    public GameFixedUpdateSystems(Contexts contexts)
    {
        // movement
        Add(new ProjectileBounceSystem(contexts));

        // clean up
        Add(new Cleanup2DTriggersSystem(contexts));
    }
}