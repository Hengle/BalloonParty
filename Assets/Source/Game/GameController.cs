using Entitas;

/// <summary>
/// Base class serves as interaction point between ECS and Unity
/// </summary>
public class GameController
{
    private readonly Systems _updateSystems;
    private readonly Systems _fixedUpdateSystems;

    public GameController(Contexts contexts, IGameConfiguration configuration)
    {
        contexts.configuration.SetGameConfiguration(configuration);

        _updateSystems = new GameUpdateSystems(contexts);
        _fixedUpdateSystems = new GameFixedUpdateSystems(contexts);
    }

    public void Initialize()
    {
        _updateSystems.Initialize();
        _fixedUpdateSystems.Initialize();
    }

    public void Execute()
    {
        _updateSystems.Execute();
    }

    public void FixedExecute()
    {
        _fixedUpdateSystems.Execute();
    }

    public void Cleanup()
    {
        _updateSystems.Cleanup();
        _fixedUpdateSystems.Cleanup();
    }
}