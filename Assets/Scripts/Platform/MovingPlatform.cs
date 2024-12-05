using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
	public Transform[] waypoints;
	public float speed = 2.5f;
	public float waitTime = 3f;

	private int currentIndex = 0;

	private void Start()
	{
		StartCoroutine(MovePlatform());
	}

	private System.Collections.IEnumerator MovePlatform()
	{
		while (true)
		{
			Transform target = waypoints[currentIndex];
			while (Vector3.Distance(transform.position, target.position) > 0.1f)
			{
				transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
				yield return null;
			}

			currentIndex = (currentIndex + 1) % waypoints.Length;
			yield return new WaitForSeconds(waitTime);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Player"))
			collision.transform.SetParent(transform);
	}

	private void OnCollisionExit(Collision collision)
	{
		if (collision.gameObject.CompareTag("Player"))
			collision.transform.SetParent(null);
	}
}