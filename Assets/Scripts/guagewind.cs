using UnityEngine;
using System.Collections;

public class guagewind : MonoBehaviour {

	int percent;
	bool returnedToZero;

	void Start () {
	}

	float Adjust(float num){
		return (num+0.04f)*20;
	}

	// Update is called once per frame
	void Update () {

		if (Global_.windForce == 0) {
			returnedToZero = true;
			//percent = (int)Global_.windForce / 5;
		}

		if (returnedToZero && Global_.windForce > 0) {
			percent = (int) Adjust(Global_.windForce);
		}

		if (percent > 100) {
			percent = 100;
		}

		float ScaleSet = (float)0.0074 * percent+.01f,
		PosSet = (float)(0.0134 * percent) - 1.4f;//1.35


		transform.localScale = new Vector3 (.45f,ScaleSet,1);
		transform.localPosition = new Vector3 (0,PosSet,.1f);

		if (percent > 0) {
			percent -= 1;
		}

	}
}
