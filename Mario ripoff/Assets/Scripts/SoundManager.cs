using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioClip coinSound;
    public AudioSource source1;

    void start()
    {
        source1.playOnAwake = false;
        source1.clip = coinSound;
    }

    public void PlayAudio(AudioClip toPlay)
    {
        source1.clip = toPlay;
        source1.Play ();
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
