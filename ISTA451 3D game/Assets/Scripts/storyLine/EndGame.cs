using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class EndGame : MonoBehaviour {


    //Store all your text in this string array
	public string[] textArray;
	public GameObject story;
	private bool told = true;
	private bool endStart = false;
	private bool cameraFloat = false;
	private int titleScene = 1;
	int currentlyDisplayingText = 0;
	
	public TextMeshProUGUI textBox;
	public GameObject player;
	public GameObject camera;

	public GameObject EndCamera;
	public GameObject EndCanvas;
	public GameObject skeleton;
	public GameObject playerBody;
	public GameObject menuCanvas;
	public TextMeshProUGUI endText;
	public GameObject endSpace;

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
		if(endStart && Input.GetKeyDown(KeyCode.Space)) {
			showNextEnd();
		}
		if(cameraFloat && EndCamera.GetComponent<Transform>().position.y < 60) {
			EndCamera.transform.position += new Vector3(0f, 0.01f, 0f);
		}

		if(cameraFloat && EndCamera.GetComponent<Transform>().position.y >= 20) {
			skeleton.SetActive(true);
			playerBody.SetActive(false);
		}

		if(EndCamera.GetComponent<Transform>().position.y >= 60)
		{
			SceneManager.LoadScene(titleScene);
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
			EndCameraMove();
			return;
		}
		StartCoroutine(AnimateText());
	}
	//Note that the speed you want the typewriter effect to be going at is the yield waitforseconds (in my case it's 1 letter for every      0.03 seconds, replace this with a public float if you want to experiment with speed in from the editor)
	IEnumerator AnimateText(){
		print(textArray[currentlyDisplayingText]);
		for (int i = 0; i < (textArray[currentlyDisplayingText].Length+1); i++)
		{
			textBox.text = textArray[currentlyDisplayingText].Substring(0, i);
			yield return new WaitForSeconds(.03f);
		}
	}

	void EndCameraMove() {
		menuCanvas.SetActive(false);
		EndCanvas.SetActive(true);
		currentlyDisplayingText = 0;

		textArray = new string[]{"",
			"Made by \nYang Hu",
			"Special thank to \nDrew Castalia",
			"Thanks for playing"};
		cameraFloat = true;
		endStart = true;
		StartCoroutine(AnimateText2());

	}

	void showNextEnd() {
		StopAllCoroutines();
		currentlyDisplayingText++;
		//If we've reached the end of the array, do anything you want. I just restart the example text
		if (currentlyDisplayingText>=textArray.Length) {
			endStart = false;
			endSpace.SetActive(false);
			endText.gameObject.SetActive(false);
			return;
		}
		StartCoroutine(AnimateText2());
	}

	//Note that the speed you want the typewriter effect to be going at is the yield waitforseconds (in my case it's 1 letter for every      0.03 seconds, replace this with a public float if you want to experiment with speed in from the editor)
	IEnumerator AnimateText2(){
		print(textArray[currentlyDisplayingText]);
		for (int i = 0; i < (textArray[currentlyDisplayingText].Length+1); i++)
		{
			endText.text = textArray[currentlyDisplayingText].Substring(0, i);
			yield return new WaitForSeconds(.03f);
		}
	}

}
