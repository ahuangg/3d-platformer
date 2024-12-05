using UnityEngine;

public class FlyingCharacterController : MonoBehaviour
{
	public float moveDistance = 5f;
	private Rigidbody rb;
	private GodModeManager godModeManager;
	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		godModeManager = FindObjectOfType<GodModeManager>();
	}

	private void Update()
	{
		bool isGodModeActive = godModeManager.IsGodModeActive();

		rb.useGravity = !isGodModeActive;

		if (isGodModeActive)
		{
			float verticalInput = 0f;

			if (Input.GetKey(KeyCode.Alpha1))
			{
				verticalInput = 1f;
			}
			else if (Input.GetKey(KeyCode.Alpha2))
			{
				verticalInput = -1f;
			}

			Vector3 movement = new Vector3(0f, verticalInput * moveDistance, 0f);

			rb.MovePosition(rb.position + movement * Time.deltaTime);
			rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
		}
	}

}
