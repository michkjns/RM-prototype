using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour 
{
	Transform followTargetTransform = null;
	Vector3 offset;

	void Start () 
	{
		followTargetTransform = GameManager.PlayerObject.transform;
		Debug.Assert(followTargetTransform != null, "Camera has no target!");

		offset = transform.position - followTargetTransform.position;
	}
	
	void Update () 
	{
		//Vector3 position = transform.position;
		//Vector3 lerpPosition = Vector3.Lerp(position, followTargetTransform, Time.deltaTime);
	}

	void LateUpdate()
	{
		transform.position = followTargetTransform.position + offset;
	}
}
