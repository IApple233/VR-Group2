using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameManager gameManager;
    
    public void CameraStart()
    {
        gameManager.CameraStart();
    }
}
