using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class fixEye : MonoBehaviour {

	public TextMeshProUGUI message;
	public playerInv playerInv;
	//public Transform positioning;
	public Transform target;
	public GameObject pillar;
	public GameObject altar;
	private int interactable = 2;
	private int exitZone = 5;
	private bool said = false;
	private bool eyeFixed = false;
	// Update is called once per frame
	void Update () {
		if(!eyeFixed) {
			float distance = Vector3.Distance(transform.position, target.position);
			if(distance < interactable && !said) {
				message.text = "Press F to fix";
				if(Input.GetKeyDown(KeyCode.F)) {
					if(pillar) {
						StartCoroutine(showMsg("fixing..."));
						said = true;
					} else {
						StartCoroutine(showMsg("nothing happens."));
						said = true;
					}
				}
			}
			else if(distance > interactable && distance < exitZone) {
				message.text = "";
				said = false;
			}
		}
	}

	IEnumerator showMsg(string msg) {
		said = false;
		message.text = msg;
		yield return new WaitForSeconds(2);
		message.text = "";
		if(msg == "fixing...") {
			pillar.SetActive(true);
			altar.SetActive(true);
			this.gameObject.SetActive(false);
		}
		
	}
}
