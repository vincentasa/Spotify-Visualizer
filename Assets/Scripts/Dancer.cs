using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dancer : MonoBehaviour
{
    [Range(0, 5)] public float rotateSpeed;
    public ParticleSystem boom;



    private void Start()
    {
        
    }
    public void Dance(float volume)
    {
        transform.localScale = new Vector3(volume * 3f, volume * 3f, volume * 3f);
        if (volume >= 0.1f)
        {
            boom.Play();
        }
    }
}