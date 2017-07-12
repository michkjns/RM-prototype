using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]

public class MouseAim : MonoBehaviour
{
	public float maxLineLength;

	private Vector3 aimDirection;
	public Vector3 AimDirection { get { return aimDirection; } }

	private LineRenderer lineRenderer = null;	

	private float dotSize = 0.207f;

	void Start()
	{
		lineRenderer = GetComponent<LineRenderer>();
	}

	void Update()
	{
		lineRenderer.SetPosition(0, transform.position);

		Vector3 mouseScreenPoint = Input.mousePosition;
		mouseScreenPoint.z = -Camera.main.transform.position.z;
		Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(mouseScreenPoint);
		aimDirection = Vector3.Normalize(mouseWorldPoint - transform.position);
		float lineLength = Vector3.Distance(mouseWorldPoint, transform.position);
		lineLength = dotSize * Mathf.Round(Mathf.Min(lineLength, maxLineLength) / dotSize);
		lineRenderer.SetPosition(1, transform.position + aimDirection * lineLength);
	}
}
