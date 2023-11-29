using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public float Speed;
    public float moveTime;

    public bool DirRight;
    public bool DirLeft;
    public bool DirBottom;
    public bool DirUp;
    private float timer;

    // Update is called once per frame
    void Update()
    {
        if (DirRight)
        {
            transform.Translate(Vector2.right * Speed * Time.deltaTime);
        }
        if (DirLeft)
        {
            transform.Translate(Vector2.left * Speed * Time.deltaTime);
        }

        if (DirBottom)
        {
            transform.Translate(Vector2.down * Speed * Time.deltaTime);
        }
        if (DirUp)
        {
            transform.Translate(Vector2.up * Speed * Time.deltaTime);
        }

        timer += Time.deltaTime;
        if (timer >= moveTime)
        {
            DirLeft = !DirLeft;
            DirRight = !DirRight;
            DirBottom = !DirBottom;
            DirUp = !DirUp;
            timer = 0f;
        }
    }
}
