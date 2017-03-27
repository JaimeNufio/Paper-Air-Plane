using UnityEngine;
using System.Collections;

public class ReadFingerPos : MonoBehaviour {

	public int Z = 0;
	Vector3 startPos, endPos;
	bool noCurrentValue = true, moving = false;

	void Start () {
	
	}

	Vector3 correctPos(Vector3 Pos){
	
		return new Vector3((float)((6.5*Pos.x/Screen.width)-3.25),
			(float)((10*Pos.y/Screen.height )-5),Z);

	}

	void Update () {
		
		Touch[] touches = Input.touches;

		for (int i = 0; i < touches.Length; i++) {
			//correctPos (touches [i].position);
			//Debug.Log(touches[i].position.x/Screen.width);
		}

	}


		//if (Input.touchCount > 0 && noCurrentValue) {
		//	Touch Finger = Input.touches [0];

		//	if (Finger.phase == TouchPhase.Began) {
		//		startPos = Finger.position;
		//	}
		//	if (Finger.phase == TouchPhase.Moved && Finger.position.y > startPos.y) {
		//		moving = true;
		//	}
		//	if (moving && (Finger.phase == TouchPhase.Canceled || Finger.phase == TouchPhase.Ended)) {
		//		endPos = Finger.position;
		//		Debug.Log(Vector3.Magnitude(endPos-startPos));
		//	}
		//}
	//}
}
