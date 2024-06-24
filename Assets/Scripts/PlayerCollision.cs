using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerCollision : MonoBehaviour
{
    public GameManager gameManager;

    public Text remainDot;

    public AudioManager audioManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Dot")
        {
            Destroy(other.gameObject);
            audioManager.eatDot();
            int t = Convert.ToInt32(remainDot.text);
            t--;
            
            if(t < 0)
            {
                t = 0;
            }
            remainDot.text = t.ToString();
        }
        else if (other.tag == "Ghost")
        {
            gameManager.Die();
        }
    }

    void Update()
    {
        if (transform.position.y < -1 || transform.position.x>10.8 || transform.position.x<-10.8)
        {
            gameManager.Die();
        }
    }
}
