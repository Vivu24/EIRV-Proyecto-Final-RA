using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonMovement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public enum Direccion { Izquierda, Derecha }
    public Direccion direccion;

    private PlayerMobileController player;

    void Start()
    {
        player = FindObjectOfType<PlayerMobileController>(); // Asume que hay uno en la escena
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (direccion == Direccion.Izquierda)
            player.OnLeftButtonDown();
        else
            player.OnRightButtonDown();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (direccion == Direccion.Izquierda)
            player.OnLeftButtonUp();
        else
            player.OnRightButtonUp();
    }
}
