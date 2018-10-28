using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objFloat : MonoBehaviour {
	public float speed;
	public float surface;
	public Transform self;
	private int finalHeight = 30;
	private bool floating = false;
	// Update is called once per frame
	void Update() {
		print("y pos: " + self.position.y);
		if(floating && self.position.y < surface) {
			self.position += new Vector3(0f, speed, 0f);
			print(self.position);
		}
	}

	public void floatUp() {
		floating = true;
	}
}
