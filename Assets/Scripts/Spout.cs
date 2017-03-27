using UnityEngine;
using System.Collections;

public class Spout : MonoBehaviour {

	public float Amplitude, Frequency, AmplitudeGrow, BaseGrowth,shiftX,shiftY;

	float count;
	Vector3 startPos;

	// Use this for initialization
	void Start () {
		count = 0;
		startPos = transform.position;
	}

	// Update is called once per frame
	void Update () {
		
		count+= (Mathf.PI/360);

		float sinFunc = Mathf.Sin (count * Frequency);

		//Debug.Log (sinFunc);

		Vector3 pos = transform.parent.transform.position;

		transform.localScale=new Vector3(((sinFunc*AmplitudeGrow)+BaseGrowth),
			Mathf.Abs((sinFunc*AmplitudeGrow)+BaseGrowth),
			0);
		
		transform.position = new Vector3 (pos.x+shiftX, pos.y+(Amplitude*sinFunc)+shiftY, startPos.z);

		if (count >= 2 * Mathf.PI) {
			count = 0;
		}
	}
}
