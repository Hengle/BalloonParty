public class GameUpdateSystems : Feature
{
    public GameUpdateSystems(Contexts contexts)
    {
        // initialization
        Add(new ThrowerSpawnSystem(contexts));
        Add(new AssetInstancingSystem(contexts));

        // movement
        Add(new ThrowerDirectionSystem(contexts));
        Add(new ThrowerDirectionSystem(contexts));

        // events
        Add(new GameEventSystems(contexts));
    }
}