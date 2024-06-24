using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountSwitch : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject oldCount;
    public GameObject newCount = null;
    public void SwitchCount()
    {
        gameManager.SwitchCount(oldCount, newCount);
    }
}
