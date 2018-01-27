using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
    public Transform pigeonPosition;

    // Use this for initialization
    void Start () {
        // Add velocity to the bullet
        this.GetComponent<Rigidbody>().velocity = this.transform.forward * 6;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
