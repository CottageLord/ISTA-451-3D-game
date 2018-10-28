using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class collectBone : MonoBehaviour {

	public playerInv playerInv;
	public TextMeshProUGUI message;
	
	public void collect() {
		playerInv.legs++;
		string msg = playerInv.legs + " / 4";
		StartCoroutine(showMsg(msg, 2));
	}

	IEnumerator showMsg(string msg, int time) {
		message.text = msg;
		yield return new WaitForSeconds(time);
		message.text = "";
	}
}
