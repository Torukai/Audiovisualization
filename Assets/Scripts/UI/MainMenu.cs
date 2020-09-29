using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	string path;
	public AudioSource _audioSource;

	public void PlayDemo()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void Browse()
	{
		path = EditorUtility.OpenFilePanel("Overwrite mp3", "", "mp3");
		SetAudioData();
	}

	void SetAudioData()
	{
		if (path != null)
		{
			UpdateAudio();
		}
		
	}

	void UpdateAudio()
	{
		WWW www = new WWW("file:///"+path);
		_audioSource.clip = www.GetAudioClip(false, false);
	}

	public void Quit()
	{
		Debug.Log("Quit!");
		Application.Quit();
	}
}
