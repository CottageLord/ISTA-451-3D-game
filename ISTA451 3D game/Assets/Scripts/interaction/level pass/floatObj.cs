using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatObj : MonoBehaviour {
	public Transform self;
	public float speed;
	private int finalHeight = 30;
	private bool floating = false;
	// Update is called once per frame
	void Update() {
		if(self && floating) {
			self.position += new Vector3(0f, speed, 0f);
		}
	}

	public void floatUp() {
		floating = true;
		StartCoroutine(floatUpStart());
	}
	

	IEnumerator floatUpStart() {
		yield return new WaitForSeconds(10);
		Destroy(self.gameObject);
	}
}
