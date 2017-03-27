using UnityEngine;
using System.Collections;

public class CloudSpawner : MonoBehaviour {

	public int countMax;
	public GameObject cloud,rainCloud;
	public Sprite one,two,three,oneRain,twoRain,threeRain;
	
	Sprite[] list,listRain;
	int count;

	// Use this for initialization
	void Start () {
		list = new Sprite[] {one,two,three};
		listRain = new Sprite[] {oneRain,twoRain,threeRain};
		count = countMax;
	}
	
	// Update is called once per frame
	void Update () {
		count++;

		if (count >= countMax) {
			count = 0;
			GameObject clone;
			if (Random.Range (0, 10) > 5) {
				clone = (GameObject)Instantiate (cloud, new Vector3 (Random.Range (5, 6), Random.Range (4, 1f), -5), new Quaternion (0, 0, 0, 0));
				clone.GetComponent<SpriteRenderer> ().sprite = list [Random.Range (0, 2)];
				clone.transform.parent = this.transform;
			} else {
				clone = (GameObject)Instantiate (rainCloud, new Vector3 (Random.Range (5, 6), Random.Range (4, 1f), -5), new Quaternion (0, 0, 0, 0));
				clone.GetComponent<SpriteRenderer> ().sprite = listRain [Random.Range (0, 2)];
				clone.transform.parent = this.transform;
			}

			GameObject clone1 = (GameObject)Instantiate (cloud, new Vector3 (Random.Range (7, 9), clone.transform.position.y-2, -5), new Quaternion (0, 0, 0, 0));
			clone1.GetComponent<SpriteRenderer> ().sprite = list [Random.Range (0, 2)];
			clone1.transform.parent = this.transform;

			//Vector3 pos = clone.transform.position;
			//clone.transform.position = new Vector3(pos.x,pos.y,5);
			//Instantiate (cloud, new Vector3 (Random.Range (5, 6)+8, Random.Range (4, 1f), 10), new Quaternion(0,0,0,0));
		}
	}
}
