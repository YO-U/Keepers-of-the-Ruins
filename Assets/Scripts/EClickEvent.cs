using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EClickEvent : MonoBehaviour
{
    public Canvas targetCanvas; // Ссылка на Canvas, на котором висит TextAnimation
    private bool canInteract = false;
    private TextAnimation anim;

    private void Start()
    {
        anim = targetCanvas.GetComponent<TextAnimation>();
    }

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            anim.Starting();
            Destroy(gameObject); // Destroy(this.gameObject) - если EClickEvent весит на объекте
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