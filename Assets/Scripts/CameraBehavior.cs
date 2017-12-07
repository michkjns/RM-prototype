using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour 
{
	private Transform followTargetTransform = null;
	public enum CameraMode
	{
		Static,
		Direct,
		Horizontal
	};

	[SerializeField]
	private CameraMode mode;
	public CameraMode Mode { get { return mode; } }

	// Direct
	[SerializeField]
	private Vector3 offset;
	//

	// Horizontal
	[SerializeField]
	private float maxDistance;

	[SerializeField]
	private float lerpSpeed;
	//

	void Start()
	{
		followTargetTransform = GameManager.PlayerObject.transform;
		Debug.Assert(followTargetTransform != null, "Camera has no target!");

		if (mode == CameraMode.Direct)
		{
			offset = transform.position - followTargetTransform.position;
		}
	}
	
	void Update () 
	{
		if (mode == CameraMode.Horizontal)
		{
			UpdateHorizontal();
		}
	}

	void LateUpdate()
	{
		if (mode == CameraMode.Direct)
		{
			UpdateDirect();
		}
	}

	void UpdateDirect()
	{
		transform.position = followTargetTransform.position + offset;
	}

	void UpdateHorizontal()
	{
		float horizontalDistance = followTargetTransform.position.x - transform.position.x;
		float direction = horizontalDistance >= 0.0f ? 1.0f : -1.0f;
		if (Mathf.Abs(horizontalDistance) > maxDistance)
		{
			transform.position = Vector3.Lerp(transform.position, 
				new Vector3(transform.position.x + direction * (Mathf.Abs(horizontalDistance) - maxDistance), transform.position.y, transform.position.z), Time.deltaTime * lerpSpeed);
		}
	}
}
