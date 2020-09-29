using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
	public AudioMixer audioMixer;

	void Start()
	{
		audioMixer.SetFloat("volume", -80f);
		//audioMixer.SetFloat("volume", 0f);
	}

	public void SetVolume(float volume)
	{
		audioMixer.SetFloat("volume", volume);

	}
}
