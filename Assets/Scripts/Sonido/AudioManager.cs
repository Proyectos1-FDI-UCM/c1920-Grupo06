using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource music = null;
    static public AudioManager instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);

        music.playOnAwake = true;
        music.loop = true;
        music.Play();
    }

    public void Pause()
    {
        music.Pause();
    }

    public void UnPause()
    {
        music.UnPause();
    }
}
