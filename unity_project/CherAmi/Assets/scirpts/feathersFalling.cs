using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feathersFalling : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var dt = Time.deltaTime;
        var speed = 0.5f;
        var direction = new Vector3(0, -1, 0);
        this.transform.Translate(direction * speed);
	}
}
