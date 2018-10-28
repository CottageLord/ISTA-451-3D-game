using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class typingTextEffect : MonoBehaviour {

	public TextMeshProUGUI textBox;
	public Animator playerAnim;
    //Store all your text in this string array
	public string[] textArray;
	public GameObject player;
	public GameObject story;
	public GameObject menuCanvas;
	private bool told = false;

	int currentlyDisplayingText = 0;
	
	public void tell () {
		Cursor.visible = true;
		told = false;
		currentlyDisplayingText = 0;
		player.SetActive(false);
		menuCanvas.SetActive(false);
		story.SetActive(true);
		StartCoroutine(AnimateText());
	}

	public void setStory(string[] givenText) {
		textArray = givenText;
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
			player.SetActive(true);
			playerAnim.SetBool("reset", true);
			story.SetActive(false);
			menuCanvas.SetActive(true);
			told = true;
			Cursor.visible = true;
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
}
