﻿using UnityEngine;
using System.Collections;

public class RotateBob : MonoBehaviour {

	float count = 0f;
	Vector3 startPos;
	//Quaternion startRotate;

	public float 
	xAmplitude,xFrequency,
	yAmplitude,yFrequency,
	rAmplitude,rFrequency;

	public float SpeedMultiplyer, leave, enterPos;
	Vector3 start;


	// Use this for initialization
	void Start () {
		count = 0;
		startPos = transform.position;
		//startRotate = transform.rotation;

		//Reset ();
	}

	void Reset(){
		float scale = Random.Range(40,60);
		transform.localScale = new Vector3 (scale/100,scale/100,1);
		//transform.position = new Vector3 (enterPos, Random.Range (1f, 3.8f), startPos.z);

		rAmplitude = Random.Range (3,6);
		rFrequency = Random.Range (3, 6);

	}
	
	// Update is called once per frame
	void Update () {

		//////Pos

		float step = SpeedMultiplyer*Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position,new Vector3(-10,startPos.y,startPos.z),step);

		////////////////////////////////////////////////////////


		//////Rotation
	
		count+= (Mathf.PI/360);

		//this made it go round, its deprecated now.
		//transform.position += new Vector3 (xAmplitude*Mathf.Cos(xFrequency*count),yAmplitude*Mathf.Sin(yFrequency*count),0);
		//= startPos + new Vector

		//rotation around z
		//transform.localRotation.y += startRotate + new Vector3(0,0,rAmplitude*Mathf.Cos(rAmplitude*count));
		transform.rotation =Quaternion.AngleAxis(rAmplitude*Mathf.Cos(rFrequency*count),Vector3.forward);

		if (count >= 2*Mathf.PI) {
			count = 0;
		}


		if (transform.position.x < leave){
			Destroy (this.gameObject);
		}

	}
}
