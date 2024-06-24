using System;
using UnityEngine;
using UnityEngine.UI;

public class targetPlacement : MonoBehaviour
{
    public GameManager gameManager;
    public Text remainTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Base"))
        {
            Destroy(gameObject);
            int count = Convert.ToInt32(remainTarget.text);
            count--;
            remainTarget.text = count.ToString();
            if (count == 0)
            {
                gameManager.Win();
            }
        }
    }
}
