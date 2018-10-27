using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passLevel : MonoBehaviour {
	public floatObj[] rocks;
	public GameObject invisWalls;

	public void pass() {
		invisWalls.SetActive(false);
		foreach(floatObj rock in rocks) {
			rock.floatUp();
		}
	}
}
