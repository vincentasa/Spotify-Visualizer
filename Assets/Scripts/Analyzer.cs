using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Analyzer : MonoBehaviour
{
	AudioSource source;
	public static UnityEvent<float> onVolumeChanged = new();

	void Start()
	{
		source = GetComponent<AudioSource>();
	}

	void Update()
	{
		var samples = new float[735];
		source.clip.GetData(samples, source.timeSamples);

		var sum = 0f;
		foreach (var sample in samples)
		{
			sum += Mathf.Abs(sample);
		}
		var average = sum / samples.Length;

		onVolumeChanged.Invoke(average);
	}
}