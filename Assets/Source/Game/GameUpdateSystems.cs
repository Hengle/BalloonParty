public class GameUpdateSystems : Feature
{
    public GameUpdateSystems(Contexts contexts)
    {
        // initialization
        Add(new ThrowerSpawnSystem(contexts));
        Add(new AssetInstancingSystem(contexts));

        // events
        Add(new GameEventSystems(contexts));
    }
}