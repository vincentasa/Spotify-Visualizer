using UnityEngine;

public class CircleDancer : MonoBehaviour
{
	public float radius = 5;
	public int count = 10;
	public float rotateSpeed = 100;
	public float minScale = 0.2f;
	public float sensitivity = 1f;
	public float boost = 1;
	public GameObject prefab;

	void Start()
	{
		for (float i = 0; i < count; i++)
		{
			var angle = i / count * Mathf.PI * 2f;
			var pos = new Vector3();
			pos.x = Mathf.Cos(angle);
			pos.y = Mathf.Sin(angle);
			pos *= radius;
			var obj = Instantiate(prefab, pos, Quaternion.identity,transform);
			obj.transform.LookAt(transform);
		}

		Analyzer.onVolumeChanged.AddListener(Dance);
	}


	public void Dance(float volume)
	{
		volume *= boost;
		transform.Rotate(0,0,Mathf.Pow(volume,sensitivity) * rotateSpeed * Time.deltaTime);
		transform.localScale = Vector3.one * (minScale + volume);
	}
}