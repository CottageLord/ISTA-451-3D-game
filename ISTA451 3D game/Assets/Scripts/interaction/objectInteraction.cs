using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectInteraction : MonoBehaviour {

 	public GameObject message;
	public Transform target;
	private int interactable = 3;
	private bool displayMessage = false;

	void Start() {
		GetComponent<MeshFilter>().mesh.UploadMeshData(true);
	}

	void Update() {
		float distance = Vector3.Distance(transform.position, target.position);
		
		if(distance < interactable) {
			message.SetActive(true);
		}
		else {
			displayMessage = false;
			message.SetActive(false);
		}
	}
}
