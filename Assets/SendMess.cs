using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendMess : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool isCond=false;
    void Start()
    {
        isCond = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject);
        Debug.Log(isCond);
        if (collision.gameObject.name == "Poke Interactions Table")
            isCond = true;
            Debug.Log(isCond);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
