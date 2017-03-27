using UnityEngine;
using System.Collections;

public class MoveLeft : MonoBehaviour {

	public float SpeedMultiplyer, leave, enterPos;
	Vector3 start;

	// Use this for initialization
	void Start () {
		start = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//float step = SpeedMultiplyer*Time.deltaTime;
		transform.position += new Vector3 (SpeedMultiplyer,0,0); //Vector3.MoveTowards(transform.position,new Vector3(-10,start.y,start.z),step);

		if (transform.position.x < leave) {
			Debug.Log ("Reset");
			transform.position = new Vector3 (enterPos, start.y, start.z);
		}
	}	
}
