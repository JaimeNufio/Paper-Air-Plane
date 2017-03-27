using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Flight : MonoBehaviour {

	public int cap, maxCount;
	public float gravity,speed,upperLimit,waterLine,wetnessMajor,wetnessMinor,waterWeight,distanceRate;
	public GameObject wind;
	public Vector3 wayPoint,lowWayPoint;

	int count;
	float value,newX,totalDistance,functionalGravity;
	bool moving, noCurrentValue, startCounting;
	Vector3 startPos,endPos,CurrentWayPoint;


	// Use this for initialization
	void Start () {
		value = 0;
		count = 0;
		noCurrentValue = true;
		Global_.WaterLevel = 0;
		Global_.board = "Swipe up to start!";
		functionalGravity = gravity;
		gravity = 0;
	}

	Vector3 correctPos(Vector3 Pos){

		return new Vector3((float)(-2),
			(float)((10*Pos.y/Screen.height )-5),transform.position.z);

	}

	// Update is called once per frame
	void Update () {
		
		Vector3 pos = transform.position;
		float artificalGravity = Global_.WaterLevel/waterWeight;

		if (Input.touchCount > 0 && noCurrentValue) {
			Touch Finger = Input.touches [0];

			if (Finger.phase == TouchPhase.Began) {
				startPos = Finger.position;
			}
			if (Finger.phase == TouchPhase.Moved && Finger.position.y > startPos.y) {
				moving = true;
			}
			if (moving && (Finger.phase == TouchPhase.Canceled || Finger.phase == TouchPhase.Ended)) {

				if (Global_.gameOver) {
					Global_.tryToRest = true;
				}

				if (startCounting == false) {
					startCounting = true;
					gravity = functionalGravity;
				}

				endPos = Finger.position;
				newX = (4*(endPos.x/Screen.width) )- 2;

				float dst = Vector3.Magnitude (endPos - startPos);
				if ( dst < 100 || endPos.y < startPos.y) { 
					value = 0;
					Global_.windForce = 0;
				} else {
					value =  cap * dst / Screen.height;
					Global_.windForce = value;
					//Debug.Log (value);
				}

				//value = (endPos.y - startPos.y) / cap;//Vector3.Magnitude (endPos - startPos) / cap;

				//lets just keep value as a persistent value
				//value = 2;

				//A lower cap makes a higher value
				if (value < 0 || pos.y > 4) {
					value = 0;
				}

				if (pos.y >= upperLimit) {
					value = 0;
				}
				noCurrentValue = false;
				count = 0;
			}
		} 

		float step;

		wayPoint = new Vector3 (newX, wayPoint.y, wayPoint.z);

		if (!noCurrentValue) {
			if (value > 0) {
				step = (value - artificalGravity) * Time.deltaTime;
				CurrentWayPoint = wayPoint;
			} else {
				step = (artificalGravity)*Time.deltaTime;
				CurrentWayPoint = lowWayPoint;
			}
		} else {
			step = (gravity+artificalGravity) * Time.deltaTime;
			CurrentWayPoint = lowWayPoint;
		}
		//Debug.Log (step);
		count++;

		if (count > maxCount) {
			noCurrentValue = true;
			count = 0;
			Global_.windForce = 0;
		}

		transform.position = Vector3.Lerp (transform.position,CurrentWayPoint,step);

		//lets make it wet if its bellow the water threshold

		if (pos.y < waterLine) {
			Global_.WaterLevel+=wetnessMajor;
		}

		//Debug.Log(Global_.windForce);

		if (pos.y < -5.6 ) {
			Global_.gameOver = true;
			Global_.board = "You flew " + fixNum (totalDistance)+" ft!";
			//SceneManager.LoadScene ("mainGame");	
		} else if (startCounting) {
			Global_.distance = fixNum(totalDistance);
			totalDistance += distanceRate;
			Global_.board = "Distance: "+fixNum(totalDistance)+" ft";
		}
	}

	float fixNum(float num){
		int newNum = (int) num*100;
		num = (float) newNum / 1000;
		return num;

	}

	void OnTriggerStay2D(Collider2D obj){
		//Debug.Log ("trigger");
		if (startCounting) {
			if (obj.gameObject.tag == "water") {
				//Debug.Log ("WaterSource!");
				Global_.WaterLevel += (wetnessMinor);
			} else if (obj.gameObject.tag == "waterMajor") {
				Global_.WaterLevel += (wetnessMajor);
			} else if (obj.gameObject.tag == "waterMassive") {
				Debug.Log ("Massive Water");
				Global_.WaterLevel += (15);
				Destroy (obj.gameObject);
			}
		}
	}
}

