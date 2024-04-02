using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CircleDancer :MonoBehaviour
{
    public GameObject prefab;
    public int count = 10;
    public float radius = 5;
    public float rotateSpeed = 100;
    public float sensitivity = 1;
    public float boost = 1;
    public float minScale = 0.2f;

    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            var angle = (float)i / count * Mathf.PI * 2f;
            var pos = new Vector3();
            pos.x = Mathf.Cos(angle);
            pos.y = Mathf.Sin(angle);
            pos *= radius;
            Instantiate(prefab, pos, Quaternion.identity, transform);
        }

        Analyzer.onVolumeChanged.AddListener(Dance);
    }
    void Dance(float volume)
    {
        transform.Rotate(0, 0, Mathf.Pow(volume * boost, sensitivity) * rotateSpeed);
        transform.localScale = Vector3.one * (volume + minScale);
    }
}
