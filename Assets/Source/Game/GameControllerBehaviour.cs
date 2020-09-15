using UnityEngine;

public class GameControllerBehaviour : MonoBehaviour
{
    [SerializeField] private GameConfiguration _configuration;

    private GameController _gameController;

    private void Awake() => _gameController = new GameController(Contexts.sharedInstance, _configuration);
    private void Start() => _gameController.Initialize();
    private void Update() => _gameController.Execute();
    private void FixedUpdate() => _gameController.FixedExecute();
    private void LateUpdate() => _gameController.Cleanup();
}