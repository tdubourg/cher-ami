using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feathersFalling : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    int rotationSign = 1;
    float rotationSignChangeInterval = 0.8f;
    float timesincerotationchange = 0.0f;
	// Update is called once per frame
	void Update () {
        var dt = Time.deltaTime;
        timesincerotationchange += dt;
        var speed = 0.5f;
            float smooth = 2.0F;
        var direction = new Vector3(0, -1, 0);
        this.transform.Translate(direction * speed, Space.World);
        //this.transform.SetPositionAndRotation(this.))
        //var tiltAngle = 75;
        //float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
        //Quaternion target = Quaternion.Euler(0, 0, tiltAroundZ);
        ////transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
        this.transform.Rotate(new Vector3(0, 0, 10 * rotationSign));
        if (timesincerotationchange > rotationSignChangeInterval)
        {
            timesincerotationchange = 0;
        rotationSign = -1 * rotationSign;
        }
    }
}
