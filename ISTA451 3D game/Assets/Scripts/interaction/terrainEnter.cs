using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainEnter : MonoBehaviour {
	public typingTextEffect storyTeller;
	public GameObject cave;
	public Transform player;
	public bool said = false;

	void Update()
    {
    	if(!said && player.transform.position.y < 5) {
    		said = true;
    		cave.SetActive(false);
	        storyTeller.setStory(new string[]{"what a charming world\n...right?",
	        	"But you won't say that\nif you stay long enough...",
	        	"So let's get to the point",
	        	"...",
	        	"My soul is splited and sealed \nin several skeletons",
	        	"so...please",
	        	"collect and return them\nback to the grave",
	        	"You are my savier..."});
			storyTeller.tell();
    	}
    	
    }
}
