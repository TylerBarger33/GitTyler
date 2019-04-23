using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource background;
    public AudioSource winMusic;
    public AudioSource loseMusic;


    public bool bgm;
    public bool winner;
    public bool loser;


    void Start(){
        }

    void Update(){
        }

    public void BGM()
    {
        winner = false;
        loser = false;
        bgm = true;
        background.Play();
    }
    public void Loser()
    {
        if(background.isPlaying)
        bgm = false;
        {
            background.Stop();
        }
        if (!loseMusic.isPlaying && loser == false)
        {
            winMusic.Stop();
            loseMusic.Play();
            loser = true;
        }
    }
    public void Winner()
    {
        if (background.isPlaying)
         bgm = false;
        {
            background.Stop();
        }
        if (!winMusic.isPlaying && winner == false)
        {
            winMusic.Play();
            loseMusic.Stop();
            winner = true;
        }
    }
}
