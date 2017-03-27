using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	public Vector3 dir;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position += dir;

	}
}
