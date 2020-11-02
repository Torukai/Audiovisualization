using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class SongSwitcher : MonoBehaviour
{
    public PauseMenu _pauseMenu;
    public AudioSource _audioSource;
    public void Song1()
    {
        _audioSource.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Torcht - End To A Violent Heart");
        _audioSource.Play();
        _pauseMenu.Resume();
    }

    public void Song2()
    {
        _audioSource.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Yuni Wa - All About You");
        _audioSource.Play();
        _pauseMenu.Resume();
    }
    public void Song3()
    {
        _audioSource.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("📺Soda City Funk");
        _audioSource.Play();
        _pauseMenu.Resume();
    }

    public void Song4()
    {
        _audioSource.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("ODESZA - White Lies (Instrumental)");
        _audioSource.Play();
        _pauseMenu.Resume();
    }
    public void Song5()
    {
        _audioSource.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("ODESZA- How Did I Get Here (Extended Version)");
        _audioSource.Play();
        _pauseMenu.Resume();
    }
}