using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Update();
    }

    void Update()
    {
        for(int i = 1;i <= 5; i++)
        {
            GameObject.Find("id" + i).GetComponent<Text>().text = i.ToString();
            GameObject.Find("playername" + i).GetComponent<Text>().text = PlayerPrefs.GetString("Name" + i, "暂无");
            string text;
            if (PlayerPrefs.GetInt("time" + i, -1) != -1)
            {
                text = PlayerPrefs.GetInt("time" + i).ToString() + "秒";
            }
            else
            {
                text = "暂无";
            }
            GameObject.Find("time" + i).GetComponent<Text>().text = text;
        }
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        Update();
    }
}
