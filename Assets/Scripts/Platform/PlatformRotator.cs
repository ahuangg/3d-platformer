using UnityEngine;

public class PlatformRotator : MonoBehaviour
{
	public float rotationSpeed = 30f;

	void Update()
	{
		transform.Rotate(new Vector3(0, 0, rotationSpeed) * Time.deltaTime);
	}
}