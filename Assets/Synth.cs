using UnityEngine;

public class Synth : MonoBehaviour
{
    public float frequency;
    public AudioSource source;

    void Start()
    {
        var clip = AudioClip.Create("Sin", 44100 * 3, 1, 44100, false);

        var data = new float[44100 * 3];
        for(int i = 0;i < data.Length;i++)
        {
            data[i] = Mathf.Sin(i / 44100f * Mathf.PI * 2f * 853); // 0 - 44000
            data[i] += Mathf.Sin(i / 44100f * Mathf.PI * 2f * 960);
            data[i] /= 2f;
        }

        clip.SetData(data, 0);
        source.clip = clip;
        source.Play();
    }
}