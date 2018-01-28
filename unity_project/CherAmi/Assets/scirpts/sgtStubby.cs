using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sgtStubby : MonoBehaviour {
    const float SGT_STUBBY_SPEED = 70f;
    Vector3 SGT_STUBBY_RUNNING_DIRECTION = new Vector3(1, 0, 0);
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var dt = Time.deltaTime;
        this.transform.Translate(SGT_STUBBY_RUNNING_DIRECTION * SGT_STUBBY_SPEED * dt);
	}


    void OnTriggerEnter(Collider other)
    {
        

        Debug.Log("STUBBY   Collided with " + other.name);

        if (other.name.Contains("soldier"))
        {
            other.gameObject.GetComponent<soldier>().die();
        }

    }
}
