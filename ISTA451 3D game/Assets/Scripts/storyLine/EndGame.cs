using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGame : MonoBehaviour {


    //Store all your text in this string array
	public string[] textArray;
	public GameObject story;
	private bool told = true;

	int currentlyDisplayingText = 0;
	
	public TextMeshProUGUI textBox;
	public GameObject player;
	public GameObject camera;

	public GameObject EndCamera;

	public GameObject skeleton;
	public GameObject playerBody;

	public void end() {
		player.SetActive(false);
		textArray = new string[]{"I should have told you...",
			"But...I am so sorry",
			"I have no choice",
			"sorry...I'll pray for you",
			"the next one will come...soon",
			"Then...you know what to do"};
		tell();
		
	}
	
	public void tell () {
		Cursor.visible = false;
		told = false;
		currentlyDisplayingText = 0;
		player.SetActive(false);
		story.SetActive(true);
		StartCoroutine(AnimateText());
	}


	void Update() {
		if(!told && Input.GetKeyDown(KeyCode.Space)) {
			SkipToNextText();
		}
	}
	//This is a function for a button you press to skip to the next text
	public void SkipToNextText(){
		StopAllCoroutines();
		currentlyDisplayingText++;
		//If we've reached the end of the array, do anything you want. I just restart the example text
		if (currentlyDisplayingText>=textArray.Length) {
			told = true;
			camera.SetActive(false);
			skeleton.SetActive(false);
			playerBody.SetActive(true);
			EndCamera.SetActive(true);
			return;
		}
		StartCoroutine(AnimateText());
	}
	//Note that the speed you want the typewriter effect to be going at is the yield waitforseconds (in my case it's 1 letter for every      0.03 seconds, replace this with a public float if you want to experiment with speed in from the editor)
	IEnumerator AnimateText(){

		for (int i = 0; i < (textArray[currentlyDisplayingText].Length+1); i++)
		{
			textBox.text = textArray[currentlyDisplayingText].Substring(0, i);
			yield return new WaitForSeconds(.03f);
		}
	}

	void EndCameraMove() {
		
	}

}
