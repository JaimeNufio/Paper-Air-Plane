using UnityEngine;
using System.Collections;

public class KillSwitch : MonoBehaviour {

	public int time, count;
	// Use this for initialization
	void Start () {
		count = 0;
	}
	
	// Update is called once per frame
	void Update () {
		count++;
		if (count >= time) {
			Destroy (this.transform.gameObject);
		}
	}
}
