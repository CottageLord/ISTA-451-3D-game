using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startGame : MonoBehaviour {

	public typingTextEffect storyTeller;
	
	// Use this for initialization
	void Awake () {
		storyTeller.setStory(new string[]{"Hello there",
			"Don't worry, you are just\ndreaming",
			"However, not in your dream",
			"...",
			"I have been drifting in this\ndream for a long while",
			"and I need some help\nto get out",
			"...",
			"You will help me\nwill ya?"});
		storyTeller.tell();
	}
}
