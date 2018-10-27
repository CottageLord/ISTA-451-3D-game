using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class skullStick : MonoBehaviour {

	public TextMeshProUGUI message;
	public playerInv playerInv;
	public Transform positioning;
	public Transform target;
	private int interactable = 2;
	private int exitZone = 5;
	private bool said = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Vector3.Distance(positioning.transform.position, target.position);
		print(distance);
		if(distance < interactable && !said) {
			message.text = "Press F to investigate";
			if(Input.GetKeyDown(KeyCode.F)) {
				if(playerInv.skull) {
					StartCoroutine(showMsg("Keep...going"));
					said = true;
				} else {
					StartCoroutine(showMsg("fix my right eye...and unseal my skull..."));
					said = true;
				}
			}
		}
		else if(distance > interactable && distance < exitZone) {
			message.text = "";
			said = false;
		}
	}

	IEnumerator showMsg(string msg) {
		said = false;
		message.text = msg;
		yield return new WaitForSeconds(2);
		message.text = "";
	}
}
