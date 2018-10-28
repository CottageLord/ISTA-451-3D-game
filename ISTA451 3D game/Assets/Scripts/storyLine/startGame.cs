using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startGame : MonoBehaviour {

	public typingTextEffect storyTeller;

	// Use this for initialization
	void Awake () {
		storyTeller.tell();
	}
}
