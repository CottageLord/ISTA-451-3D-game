using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour {

	public typingTextEffect storyTeller;
	public Transform respawn;
	public Transform player;

	void OnCollisionEnter(Collision other) {
		player.position = respawn.position;
		storyTeller.setStory(new string[]{"dead", "restart"});
		storyTeller.tell();
	}
}
