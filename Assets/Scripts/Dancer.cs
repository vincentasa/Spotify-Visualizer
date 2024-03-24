using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dancer : MonoBehaviour
{
    public float rotateSpeed;
    public ParticleSystem boom;
    private void Start()
    {
        Analyzer.onVolumeChanged.AddListener(Dance);
    }
    public void Dance(float volume)
    {
        transform.localScale = new Vector3(volume * 8f, volume * 8f, volume * 8f);
        if (volume >= 0.4f)
        {
            boom.Play();
        }
        transform.Rotate(0, 0, volume * rotateSpeed);
    }
}
