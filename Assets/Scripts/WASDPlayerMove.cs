using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class WASDPlayerMove : MonoBehaviour
{
    private Vector2 movement; // направление
    private Rigidbody2D rb; // физ тело 
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private AudioSource footsteps;
    private bool rotateChecker = false;

    public float speed; // скорость настраеваемая в юнити 
    public Animator animator;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // получаем Rigidbody2D на котором весит этот скрипт
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();//получаем значение при нажатии на кнопку 
    }
    private void FixedUpdate() // отличие Fixed от обычного Update что в Fixed можно выбрать определенную частоту кадров
    {
        if (movement.x > 0.7f && rotateChecker == false) {//проверяем в какую сторону идет герой 
            playerSprite.flipX = false;//отразить персонажа по вертикале 
            rotateChecker = true;
        }
        if (movement.x < -0.7f && rotateChecker == true)//проверяем в какую сторону идет герой 
        {
            playerSprite.flipX = true;//отразить персонажа по вертикале 
            rotateChecker = false;
        }
        
        rb.AddForce(movement*speed); // передвижение персонажа 
        animator.SetFloat("Horezpntal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed",movement.sqrMagnitude);
        if (rb.velocity.magnitude != 0)
        {
            footsteps.enabled = true;
        }
        else footsteps.enabled = false;
    }
    
}
