using UnityEngine;
using System.Collections;

public class Bob : MonoBehaviour {
	
	public float count = 0f;
	Vector3 startPos;

	public float Amplitude,Frequency;

	// Use this for initialization
	void Start () {
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		count+= (Mathf.PI/360);
		transform.position = startPos + new Vector3 (Amplitude*Mathf.Cos(Frequency*count),
			Amplitude*Mathf.Sin(Frequency*count),
			0);
		
		if (count >= 2*Mathf.PI) {
			count = 0;
		}

	}
}
