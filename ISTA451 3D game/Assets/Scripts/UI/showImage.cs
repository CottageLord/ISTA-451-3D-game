using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class showImage : MonoBehaviour {

	public GameObject level2key;
	public GameObject menu;
	public TextMeshProUGUI message;
	public playerInv playerInv;
	private bool menuShowing = false;
	private bool keyShowing = false;

	void Awake() {
		level2key.SetActive(false);
		menu.SetActive(false);
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.I) && !menuShowing) {
			if(playerInv.level2key){
				if(keyShowing) {
					level2key.SetActive(false);
					keyShowing = false;
				}
				else {
					level2key.SetActive(true);
					keyShowing = true;
				}
			} else {
				message.text = "You haven't get the item yet";
			}
		}

		if(Input.GetKeyDown(KeyCode.Escape)) {
			if(keyShowing) {
				level2key.SetActive(false);
				keyShowing = false;
			} else {
				if(menuShowing) {
					exitMenu();
				}
				else {
					activeMenu();
				}
			}
			
		}
	}

	private void activeMenu() {
		menu.SetActive(true);
		menuShowing = true;
		Time.timeScale = 0;

	}

	private void exitMenu() {
		menu.SetActive(false);
		menuShowing = false;
		Time.timeScale = 1;
	}
}
