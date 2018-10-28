using UnityEngine;
using System.Collections;

public class spin : MonoBehaviour
{
    public float speed = 2f;
    
    void Update ()
    {
        this.transform.eulerAngles += new Vector3(0f,speed,0f);
    }
}