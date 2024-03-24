using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dancer : MonoBehaviour
{
    public float sensitivity = 1;
    public float maxSize = 10;

    void Start()
    {
	    Analyzer.onVolumeChanged.AddListener(Dance);
    }

    public void Dance(float volume)
    {
	    volume -= 0.15f;
	    if (volume < 0f) volume = 0f;

	    transform.localScale = Vector3.one * (0.5f + Mathf.Pow(volume,sensitivity) * maxSize);

    }
}