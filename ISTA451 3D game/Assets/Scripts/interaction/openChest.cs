using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class openChest : MonoBehaviour {
	public playerInv playerInv;
 	public TextMeshProUGUI message;
	public Transform target;
	public GameObject cap;
	public string text;
	public string itemName;
	public GameObject item;
	private int interactable = 3;
	private int exitZone = 5;
	public bool notOpened = true;

	void Update() {
		if(notOpened) {
			float distance = Vector3.Distance(transform.position, target.position);
		
			if(distance < interactable) {
				message.text = text;
				if(Input.GetKeyDown(KeyCode.F)) {
					notOpened = false;
					cap.SetActive(false);
					message.text = "";
					if(item) {
						item.SetActive(true);
					}
					switch(itemName) {
						case "left":
							if(Input.GetKeyDown(KeyCode.F)) playerInv.leftArm = true;
							break;
						default:
							break;
					}
				}
			}
			else if (distance > interactable && distance < exitZone) {
				message.text = "";
			}
		}
	}
}
