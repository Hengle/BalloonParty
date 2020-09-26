public class GameFixedUpdateSystems : Feature
{
    public GameFixedUpdateSystems(Contexts contexts)
    {
        // clean up
        Add(new Cleanup2DTriggersSystem(contexts));
    }
}