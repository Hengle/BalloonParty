public class GameUpdateSystems : Feature
{
    public GameUpdateSystems(Contexts contexts)
    {
        // initialization
        Add(new ThrowerSpawnSystem(contexts));
        Add(new AssetInstancingSystem(contexts));
        Add(new ProjectileReloadSystem(contexts));

        // movement
        Add(new ThrowerDirectionSystem(contexts));
        Add(new ThrowerRotationSystem(contexts));

        // events
        Add(new GameEventSystems(contexts));
    }
}