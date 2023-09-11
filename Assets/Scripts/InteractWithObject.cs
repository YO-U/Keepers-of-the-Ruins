using System;
using Unity.VisualScripting;
using UnityEngine;

public class InteractWithObject : MonoBehaviour
{
    public GameObject targetObject;
    public Light mainLight;
    public AudioSource audioMatch;

    private bool canInteract = false;

    

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.F))
        {
          
            LightController dimLightScript = mainLight.GetComponent<LightController>();
            dimLightScript.ResetIntensity(); // Вызываем метод ResetIntensity из скрипта DimLight
            audioMatch.Play();
            Destroy(targetObject); // Уничтожаем объект при нажатии кнопки "F"
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            canInteract = true; // При подходе игрока к объекту, разрешаем взаимодействие
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            canInteract = false; // Когда игрок уходит от объекта, запрещаем взаимодействие
        }
    }
}

