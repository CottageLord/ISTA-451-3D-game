using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passLevel : MonoBehaviour {
	public Rigidbody[] rocks;
	public GameObject invisWalls;
	public GameObject allRocks;

	public void pass() {
		invisWalls.SetActive(false);
		StartCoroutine(floatRocks());
	}

	IEnumerator floatRocks() {
		foreach(Rigidbody rock in rocks) {
			rock.AddForce(0,10,0);
		}

		yield return new WaitForSeconds(3);

		Destroy(allRocks);
	}
}
