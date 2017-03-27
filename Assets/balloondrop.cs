using UnityEngine;
using System.Collections;

public class balloondrop : MonoBehaviour {

	public int countMaxSpeed,countMinSpeed;
	public GameObject obj;

	int count = 0,countMax;

	// Use this for initialization
	void Start () {
		countMax = Random.Range(countMaxSpeed, countMinSpeed);
	}
	
	// Update is called once per frame
	void Update () {
		count++;
		if (count > countMax) {
			Vector3 pos = transform.position;
			GameObject clone = (GameObject) Instantiate (obj,new Vector3(pos.x,pos.y,1.34f), Quaternion.identity);
			//clone.transform.parent = this.transform;
			count = 0;
		}
	}
}
