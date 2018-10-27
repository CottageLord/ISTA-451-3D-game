using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class typingTextEffect : MonoBehaviour {

	public TextMeshProUGUI textBox;
    //Store all your text in this string array
	string[] textArray = new string[]{
		"1. Laik's super awesome custom typewriter script", 
		"2. You can click to skip to the next text", 
		"3.All text is stored in a single string array", 
		"4. Ok, now we can continue",
		"5. End Kappa"};
	public GameObject player;
	public GameObject story;

	private bool told = false;

	int currentlyDisplayingText = 0;
	
	void Awake () {
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
			player.SetActive(true);
			story.SetActive(false);
			told = true;
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
