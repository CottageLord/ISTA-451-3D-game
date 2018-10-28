using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class grave : MonoBehaviour {
	public Transform positioning;

	public GameObject leftArmObj;
	public GameObject rightArmObj;
	public GameObject skullObj;
	public GameObject legsObj;

	public AudioSource bgmPlayer;
	public AudioClip bgm2;
	public AudioClip bgm3;

	public TextMeshProUGUI message;

	public Transform target;
	public playerInv playerInv;
	public passLevel passLevel1;
	public passLevel passLevel2;
	public passLevel passLevel3;

	private int interactable = 2;
	private bool levelPassing = false;
	private int exitZone = 5;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Vector3.Distance(positioning.transform.position, target.position);
		if(distance < interactable && !levelPassing) {
			message.text = "Press F to investigate";
			if(Input.GetKeyDown(KeyCode.F)) {
				levelPassing = true;
				if (playerInv.leftArm) {
					StartCoroutine(putBack("put left arm back", 2));
					leftArmObj.SetActive(true);
					passLevel1.pass();
					bgmPlayer.Play();
					levelPassing = true;
					playerInv.leftArm = false;

					StartCoroutine(putBack("good, now find the rest\nthat will be much APPRECIATED", 5));

				} else if (playerInv.skull) {
					StartCoroutine(putBack("put skull back", 2));
					skullObj.SetActive(true);
					passLevel2.pass();
					bgmPlayer.clip = bgm2;
					bgmPlayer.Play();
					levelPassing = true;
					playerInv.skull = false;

					StartCoroutine(putBack("nicely done\ngo on, young one", 5));
				} else if (playerInv.rightArm) {
					StartCoroutine(putBack("put right arm back", 2));
					rightArmObj.SetActive(true);
					passLevel3.pass();
					bgmPlayer.clip = bgm3;
					bgmPlayer.Play();
					levelPassing = true;
					playerInv.rightArm = false;

					StartCoroutine(putBack("you're ... almost there, \nkeep going", 5));

				} else if (playerInv.legs == 4) {
					StartCoroutine(putBack("put legs back", 2));
					legsObj.SetActive(true);
					//bgmPlayer.clip = bgm3;
					//bgmPlayer.Play();
					levelPassing = true;
					playerInv.legs = 0;
				} else {
					StartCoroutine(putBack("nothing happens", 2));
				}
			}
		}
		else if(distance > interactable && distance < exitZone) {
			levelPassing = false;
			message.text = "";
		}
	}

	IEnumerator putBack(string msg, int time) {
		message.text = msg;
		yield return new WaitForSeconds(time);
		message.text = "";
		levelPassing = false;
	}
}
