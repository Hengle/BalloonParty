using UnityEngine;

[RequireComponent(typeof(ILinkedView))]
public class TriggerReporterController : MonoBehaviour
{
    private ILinkedView _listener;

    private void Awake()
    {
        _listener = GetComponent<ILinkedView>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var e = _listener.LinkedEntity;

        if (!e.isEnabled) return;

        var g = e as GameEntity;
        g.ReplaceTriggerEnter2D(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var e = _listener.LinkedEntity;

        if (!e.isEnabled) return;

        var g = e as GameEntity;
        g.ReplaceTriggerExit2D(other);
    }
}