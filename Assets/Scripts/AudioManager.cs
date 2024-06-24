using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource StartGameMusic;
    public AudioSource GameMusic;
    public AudioSource EatDot;
    public AudioSource Count;
    public AudioSource Death;
    public AudioSource breathMusic;
    public AudioSource winMusic;

    void Start()
    {
        StartGameMusic.Play();
    }
    public void GamePlay()
    {
        breathMusic.Stop();
        GameMusic.Play();
    }
    public void eatDot()
    {
        EatDot.Play();
    }

    public void CountPlay()
    {
        Count.Play();
    }

    public void death()
    {
        GameMusic.Stop();
        Death.Play();
        //Invoke("PlayBreath", 5f);
    }
    public void win()
    {
        GameMusic.Stop();
        winMusic.Play();
        //Invoke("PlayBreath", 8f);
    }

    public void PlayBreath()
    {
        GameMusic.Stop();
        breathMusic.Play();
    }
}
