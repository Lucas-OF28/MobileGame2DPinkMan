using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

    public class NextLevelPoint : MonoBehaviour
{
    public GameObject endGame;

    public string lvlName;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(lvlName == "end")
            {
                endGame.SetActive(true);
            }
            else
            {
                SceneManager.LoadScene(lvlName);
            }
        }
    }
}

