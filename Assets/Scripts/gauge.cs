using UnityEngine;
using System.Collections;

public class gauge : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		float percent = Global_.WaterLevel;

		if (percent > 100) {
			percent = 100;
		}

		float ScaleSet = (float)0.0074 * percent+.01f,
		PosSet = (float)(0.0134 * percent) - 1.4f;//1.35


		transform.localScale = new Vector3 (.45f,ScaleSet,1);
		transform.localPosition = new Vector3 (0,PosSet,.1f);
	}
}
