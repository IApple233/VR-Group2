using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    public GameObject Camera_Main;
    public GameObject Camera_Anim;
    public GameObject Count;
    public GameObject Num;
    public GameObject DieUI;
    public GameObject WinUI;
    public GameObject PauseMenu;
    public PlayerMovement Move;
    public AudioManager AudioManager;
    public Text TimeText;
    public Text WinTimeText;
    public Text LoseTimeText;

    float timer = 0;
    bool isStartTimer = false;
    bool isShow = false;

    bool isEnd = false;
    string[] names = new string[5];
    int[] times = new int[5];

    // 获胜
    public void Win()
    {
        if (isEnd == false)
        {
            isStartTimer = false;
            WinTimeText.text = TimeText.text + "秒";
            AudioManager.win();
            isEnd = true;
            Move.isEnd = true;
            WinUI.SetActive(true);
            Num.SetActive(false);
        }
    }

    // 死亡
    public void Die()
    {
        if (isEnd == false)
        {
            isStartTimer = false;
            LoseTimeText.text = TimeText.text + "秒";
            AudioManager.death();
            isEnd = true;
            Move.isEnd = true;
            DieUI.SetActive(true);
            Num.SetActive(false);
        }
    }

    // 开始倒计时
    public void StartGame()
    {
        AudioManager.CountPlay();
        Count.SetActive(true);
    }

    public void SwitchCount(GameObject oldCount, GameObject newCount)
    {
        // 切换倒计时数字
        oldCount.SetActive(false);
        if (newCount != null)
        {
            AudioManager.CountPlay();
            newCount.SetActive(true);
        }
        // 游戏开始
        else
        {
            AudioManager.GamePlay();
            Move.enabled = true;
            Num.SetActive(true);
            isStartTimer = true;
        }
    }

    // 动画摄像机切换到游戏摄像机
    public void CameraStart()
    {
        Camera_Main.SetActive(true);
        Camera_Anim.SetActive(false);
        Invoke("StartGame", 2.5f);
    }

    void Update()
    {
        if (isStartTimer)
        {
            timer += Time.deltaTime;
            TimeText.text = ((int)timer).ToString();
           //判断是否按下Esc键 (改为P)
          if (Input.GetKeyDown(KeyCode.P))
            {
                //如果面板正在显示，关掉面板并让游戏继续运行
                if (isShow)
                {
                    //PauseMenu.SetActive(false);
                    isShow = false;
                    Time.timeScale = (1);
                    AudioManager.GamePlay();
                }
                //否则开启面板并暂停游戏
                else
                {
                    //PauseMenu.SetActive(true);
                    isShow = true;
                    Time.timeScale = (0);
                    AudioManager.PlayBreath();
                }
            }
        }
    }

    public void BackToGame()
    {
       // PauseMenu.SetActive(false);
        isShow = false;
        Time.timeScale = (1);
        AudioManager.GamePlay();
    }

    public void Record(string userName, string score)
    {
        bool flag = false;
        int loc = 0;
        GetRanks();
        for (int i = 0; i < 5; i++)
        {
            if (times[i] > Int32.Parse(score) || times[i] == -1)
            {
                flag = true;
                loc = i;
                break;
            }
        }
        if (flag)
        {
            for (int i = 4; i > loc; i--)
            {
                names[i] = names[i - 1];
                times[i] = times[i - 1];
            }
            names[loc] = userName;
            times[loc] = Int32.Parse(score);
        }
        StoreRanks();
    }

    public void GetRanks()
    {
        for(int i = 1; i < 6; i++)
        {
            names[i - 1] = PlayerPrefs.GetString("Name" + i, "暂无");
            times[i - 1] = PlayerPrefs.GetInt("time" + i, -1);
        }
    }

    public void StoreRanks()
    {
        for (int i = 1; i < 6; i++)
        {
            PlayerPrefs.SetString("Name" + i, names[i - 1]);
            PlayerPrefs.SetInt("time" + i, times[i - 1]);
        }
    }
}
