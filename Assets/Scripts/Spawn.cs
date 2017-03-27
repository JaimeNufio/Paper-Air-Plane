using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	public int countMax;
	public GameObject spawn1,spawn2;

	int count;
	GameObject[] spawns;

	// Use this for initialization
	void Start () {
		count = 0;
		spawns = new GameObject[]{spawn1,spawn2};
	}
	
	// Update is called once per frame
	void Update () {
		count++;
		if (count >= countMax) {
			Vector3 pos;
			int img;
			if (Random.Range (0, 10) > 5) {
				//whale
				pos = new Vector3(Random.Range(10,12), Random.Range(-4,-3),3.89f);
				img = 0;
			}else{
				pos = new Vector3(Random.Range(10,12), Random.Range(4.1f,3.2f), 0);
				img = 1;
			}

			Instantiate (spawns[img],pos,Quaternion.identity);
			count = 0;
		}
	}
}
