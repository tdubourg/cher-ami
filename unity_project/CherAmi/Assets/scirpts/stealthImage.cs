using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stealthImage : MonoBehaviour {

	// Use this for initialization
	void Start () {
        // at startup the green is not visible.
        Debug.Log("CrossFading OUT?");
        this.gameObject.GetComponent<RawImage>().CrossFadeAlpha(0.0f, 0.0f, true);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
