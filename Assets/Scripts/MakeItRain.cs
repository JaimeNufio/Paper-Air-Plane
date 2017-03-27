using UnityEngine;
using System.Collections;

public class MakeItRain : MonoBehaviour {

	public GameObject rain;
	public int countMax;
	int count;

	// Use this for initialization
	void Start () {
		count = (int) countMax/2;
	}
	
	// Update is called once per frame
	void Update () {
		count++;
		if (count >= countMax) {
			Vector3 pos = transform.position;
			GameObject clone = (GameObject)Instantiate (rain,new Vector3(pos.x,pos.y-.1f,5),Quaternion.identity);
			clone.transform.parent = this.transform;
			count = 0;
		}
	}
}
