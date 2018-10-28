using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bones : MonoBehaviour {
	public collectBone collector;
	void OnCollisionEnter(Collision collision)
    {
        collector.collect();
        this.gameObject.SetActive(false);
    }
}
