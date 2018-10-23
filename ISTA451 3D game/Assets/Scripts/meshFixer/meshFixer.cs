using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meshFixer : MonoBehaviour {

	void Start() {
		GetComponent<MeshFilter>().mesh.UploadMeshData(true);
	}
}
