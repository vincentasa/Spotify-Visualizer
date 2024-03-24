using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Mathematics;
using UnityEngine;

public class CircleDancer : MonoBehaviour
{
    public GameObject prefab;
    public int count = 5;
    public float radius = 5;
    public int rotateSpeed = 1;

    void Start()
    {
        for (float i = 0; i < count; i++)
        {
            var angle = i / count * Mathf.PI * 2f;
            var pos = new Vector3();
            pos.x = Mathf.Cos(angle);
            pos.y = Mathf.Sin(angle);
            pos *= radius;

            var obj = Instantiate(prefab, pos, Quaternion.identity, transform);
            obj.transform.LookAt(transform);
        }
        
        Analyzer.onVolumeChanged.AddListener(Dance);
    }

    public void Dance(float volume)
    {
        transform.Rotate(0,0, volume * rotateSpeed * Time.deltaTime);
        transform.localScale = Vector3.one * (volume * 3f);
    }
   

}
