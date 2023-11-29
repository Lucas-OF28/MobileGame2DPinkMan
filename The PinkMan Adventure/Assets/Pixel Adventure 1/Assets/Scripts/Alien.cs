using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Rigidbody2D rig;
    private Animator anim;

    public Transform rightCol;
    public Transform leftCol;
    public Transform headPoint;
    private bool colliding;

    [SerializeField]
    private LayerMask layer;

    private float jumpForce;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    bool playerDestroyed;
    void Update()
    {
        rig.velocity = new Vector2(speed, rig.velocity.y);

        colliding = Physics2D.Linecast(rightCol.position, leftCol.position, layer);

        if (colliding)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
            speed *= -1f;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            float height = col.contacts[0].point.y - headPoint.position.y;

            if (height > 0 && !playerDestroyed)
            {
                rig.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                anim.SetTrigger("die");
                Destroy(gameObject, 0.14f);
            }
            else
            {
                playerDestroyed = true;
                GameController.instance.ShowGameOver();
                Destroy(col.gameObject);
            }
        }
    }
}

