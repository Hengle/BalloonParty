public class GameUpdateSystems : Feature
{
    public GameUpdateSystems(Contexts contexts)
    {
        // initialization
        Add(new GameStartedThrowerSpawnSystem(contexts));
        Add(new GameStartedBalloonsSpawnSystem(contexts));
        Add(new AssetInstancingSystem(contexts));
        Add(new ProjectileReloadSystem(contexts));
        Add(new BalloonLineSpawnerSystem(contexts));

        // movement
        Add(new ThrowerDirectionSystem(contexts));
        Add(new ThrowerRotationSystem(contexts));
        Add(new ProjectileTransformSystem(contexts));
        Add(new ThrowLoadedProjectileSystem(contexts));
        Add(new FreeProjectileMovementSystem(contexts));
        Add(new ProjectileBounceSystem(contexts));

        // events
        Add(new GameEventSystems(contexts));
    }
}