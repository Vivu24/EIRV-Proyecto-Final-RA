using UnityEngine;
using UnityEngine.EventSystems;

public class LaunchButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public BallLauncher launcher;

    public void OnPointerDown(PointerEventData eventData)
    {
        launcher.StartCharging();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        launcher.ReleaseBall();
    }
}
