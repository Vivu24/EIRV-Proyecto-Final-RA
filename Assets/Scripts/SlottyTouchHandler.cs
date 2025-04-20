using UnityEngine;

public class SlottyTouchHandler : MonoBehaviour
{
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Touch touch = Input.GetTouch(0);

            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Player"))
                {
                    OnSlottyTouched();
                }
            }
        }
    }

    void OnSlottyTouched()
    {
        Debug.Log("TOQUE A BICHO");
    }
}
