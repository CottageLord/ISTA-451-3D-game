using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startGame : MonoBehaviour {

	public typingTextEffect storyTeller;

	// Use this for initialization
	void Awake () {
		storyTeller.setStory(new string[]{"Hello there",
			"Don't worry, you are dreaming",
			"However, in my dream",
			"...",
			""});
		storyTeller.tell();
	}
}
