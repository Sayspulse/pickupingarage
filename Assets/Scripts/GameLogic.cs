using System.Collections.Generic;
using UnityEngine;

public class CameraInteraction : MonoBehaviour
{
    public Camera playerCamera;
    public float interactionDistance = 1f;

    private GameObject[] inventory = new GameObject[1]; // Инвентарь (максимум 1 предмет)

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            InteractWithObject();
        }
    }

    void InteractWithObject()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            GameObject target = hit.collider.gameObject;

            if (target.CompareTag("PickupItem"))
            {
                if (inventory[0] == null) // Проверка на наличие свободного слота
                {
                    inventory[0] = target;
                    target.SetActive(false); // Предмет исчезает
                }
            }
            else if (target.CompareTag("Car"))
            {
                inventory[0] = null; // Очищаем инвентарь
            }
        }
    }
}
