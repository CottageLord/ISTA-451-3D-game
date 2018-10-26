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
	public TextMeshProUGUI message;
	public Transform target;
	public playerInv playerInv;
	public passLevel passLevel1;
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
				if(playerInv.leftArm) {
					StartCoroutine(putBack("put left arm back"));
					leftArmObj.SetActive(true);
					passLevel1.pass();
					bgmPlayer.Play();
					levelPassing = true;
					playerInv.leftArm = false;
				} else {
					StartCoroutine(putBack("nothing happens"));
				}
			}
		}
		else if(distance > interactable && distance < exitZone) {
			levelPassing = false;
			message.text = "";
		}
	}

	IEnumerator putBack(string msg) {
		message.text = msg;
		yield return new WaitForSeconds(2);
		message.text = "";
		levelPassing = false;
	}
}
