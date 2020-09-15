using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class GameStartButton : MonoBehaviour
{
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();

        if (_button != null)
        {
            _button.onClick.AddListener(OnGameStartClick);
        }
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveAllListeners();
    }

    private void OnGameStartClick()
    {
        var contexts = Contexts.sharedInstance;

        // create game start event
        var e = contexts.game.CreateEntity();
        e.isGameEvent = true;
        e.isGameStarted = true;
    }
}