using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startGame : MonoBehaviour {

	public typingTextEffect storyTeller;
	
	// Use this for initialization
	void Awake () {
		storyTeller.setStory(new string[]{"Hello there",
			"Don't worry, you are just dreaming",
			"However, not in your dream",
			"...",
			"I have been drifting in this world for a long while",
			"and I need some help to get out",
			"...",
			"You will help me, will ya?"});
		storyTeller.tell();
	}
}
