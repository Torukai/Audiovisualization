using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPeer : MonoBehaviour
{
	AudioSource _audioSource;
	public float[] _samples = new float[512];
	public float[] _freqBand = new float[8];
	public float[] _bandBuffer = new float[8];
	float[] _bufferDecrease = new float[8];

	float[] _freqBandHighest = new float[8];
	public float[] _audioBand = new float[8];
	public float[] _audioBandBuffer = new float[8];

	public float _Amplitude, _AmplitudeBuffer;
	private float _AmplitudeHeighest;

	// Start is called before the first frame update
	void Start()
	{
		_audioSource = GetComponent<AudioSource>();
		//_audioSource.Play();
	}

	// Update is called once per frame
	void Update()
	{
		GetSpectrumAudioSource();
		MakeFrequencyBands();
		BandBuffer();
		CreateAudioBands();
		GetAmplitude();
	}

	void GetAmplitude()
	{
		float _CurrentAmplitude = 0;
		float _CurrentAmplitudeBuffer = 0;
		for (int i = 0; i < 8; i++)
		{
			_CurrentAmplitude += _audioBand[i];
			_CurrentAmplitudeBuffer += _audioBandBuffer[i];
		}
		if (_CurrentAmplitude > _AmplitudeHeighest)
		{
			_AmplitudeHeighest = _CurrentAmplitude;
		}
		_Amplitude = _CurrentAmplitude / _AmplitudeHeighest;
		_AmplitudeBuffer = _CurrentAmplitudeBuffer / _AmplitudeHeighest;
	}

	void CreateAudioBands()
	{
		for (int i = 0; i < 8; i++)
		{
			if (_freqBand[i] > _freqBandHighest[i])
			{
				_freqBandHighest[i] = _freqBand[i];
			}
			_audioBand[i] = (_freqBand[i] / _freqBandHighest[i]);
			_audioBandBuffer[i] = (_bandBuffer[i] / _freqBandHighest[i]);
		}
	}

	void GetSpectrumAudioSource() => _audioSource.GetSpectrumData(_samples, 0, FFTWindow.Blackman);

	void MakeFrequencyBands()
	{
		/*
		 * 22050 / 512 = 43hz per sample
		 * 
		 * 20 - 60 hz
		 * 60 - 250 hz
		 * 250 -500 hz
		 * 500 - 2000 hz
		 * 2000 - 4000 hz
		 * 4000 - 6000 hz
		 * 6000 - 20000 hz
		 * 
		 * 0 - 2 = 86 hz
		 * 1 - 4 = 172 hz - 87-258
		 * 2 - 8 = 344 hz - 259-602
		 * 3 - 16 = 688 hz - 603-1290
		 * 4 - 32 = 1376 hz - 1291-2666
		 * 5 - 64 = 2752 hz - 2667 -5418
		 * 6 - 128 = 5504 hz - 5419-10922
		 * 7 - 256 = 11008 hz - 10923-21930
		 * 510
		 * 
		 */

		int count = 0;

		for (int i = 0; i < 8; i++)
		{
			float average = 0;
			int sampleCount = (int)Mathf.Pow(2, i) * 2;

			if (i == 7)
			{
				sampleCount += 2;
			}

			for (int j = 0; j < sampleCount; j++)
			{
				average += _samples[count] * (count + 1);
				count++;
			}
			average /= count;
			_freqBand[i] = average * 10;
		}
	}
	void BandBuffer()
	{
		for (int g = 0; g < 8; ++g)
		{
			if (_freqBand[g] > _bandBuffer[g])
			{
				_bandBuffer[g] = _freqBand[g];
				_bufferDecrease[g] = 0.005f;
			}

			if (_freqBand[g] < _bandBuffer[g])
			{
				_bandBuffer[g] -= _bufferDecrease[g];
				_bufferDecrease[g] *= 1.2f;
			}
		}
	}
}