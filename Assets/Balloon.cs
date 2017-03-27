using UnityEngine;
using System.Collections;

public class Balloon : MonoBehaviour {

	public Sprite one,two,three,four,five,six,seven,eight,nine;
	Sprite[] Balloons;

	// Use this for initialization
	void Start () {
		Balloons = new Sprite[] {one,two,three,four,five,six,seven,eight,nine};
		this.GetComponent<SpriteRenderer> ().sprite = Balloons[Random.Range(0,8)];
	}

	// Update is called once per frame
	void Update () {
	
	}
		
}
