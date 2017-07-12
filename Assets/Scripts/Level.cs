using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Level : MonoBehaviour 
{
	public GameObject playerStart;
	
	public Transform PlayerStartTransform { get { return playerStart.transform; } }
}
