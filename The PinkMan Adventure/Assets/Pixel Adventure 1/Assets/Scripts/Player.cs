using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    public float Speed;
    public float JumpForce;

    public bool isJumping;
    public bool dubleJump;

    private Rigidbody2D rig;
    private Animator anim;
    
    void Start()
    {
        rig =  GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal") + CrossPlatformInputManager.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;

        if (horizontalInput > 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (horizontalInput < 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        else
        {
            anim.SetBool("walk", false);
        }
    }

    void Jump()
    {
        // Verificar o pulo pelo teclado
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                dubleJump = true;
                anim.SetBool("jump", true);
            }
            else
            {
                if (dubleJump)
                {
                    rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                    dubleJump = false;
                }
            }
        }

        // Verificar o pulo pelo botão na tela
        bool isMobileButtonDown = CrossPlatformInputManager.GetButtonDown("Jump");
        if (isMobileButtonDown)
        {
            if (!isJumping)
            {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                dubleJump = true;
                anim.SetBool("jump", true);
            }
            else
            {
                if (dubleJump)
                {
                    rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                    dubleJump = false;
                }
            }
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = false;
            anim.SetBool("jump", false);
        }
        if (collision.gameObject.tag == "Spike")
        {
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Saw")
        {
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = true;
        }
    }
}
