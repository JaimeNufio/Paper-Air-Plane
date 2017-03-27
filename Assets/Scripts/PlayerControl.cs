using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public int Z = 0;
	// Use this for initialization
	Vector3 correctPos(Vector3 Pos){

		return new Vector3((float)(-2),
			(float)((10*Pos.y/Screen.height )-5),Z);

	}

	void Update () {
		Touch[] touches = Input.touches;

		if (Input.touchCount > 0) {
			this.transform.position = correctPos (touches [0].position);

			if (Input.touchCount > 1) {
				Vector3 lookPos = correctPos(new Vector3(900000,touches[1].position.y,Z)) - transform.position;
				float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
				transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			}
		
		}
	}
}
