using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class environmentObject : MonoBehaviour {
	// Use this for initialization
	void Start () {
        //pigeon.getInstance().GetComponent<environment>().registerEnvironmentObject;
	}
	
	// Update is called once per frame
	void Update () {
        var dt = Time.deltaTime;
        this.transform.Translate(environment.ENVIRONMENT_SCROLL_SPEED * environment.ENVIRONMENT_SCROLL_VECTOR);
	}
}
