using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pigeon : MonoBehaviour {


	public float speed = 75.0f;

	public float maxX = 50.0f;
	public float minX = -50.0f;
	public float maxY = 65.0f;
	public float minY = 0.0f;

	private float x;
	private float y;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var dt = Time.deltaTime;

		this.x = transform.position.x;
		this.y = transform.position.y;

		if (this.x < this.maxX) {
			if (Input.GetKey(KeyCode.RightArrow)){
				transform.position += Vector3.right * speed * dt;
				//Debug.Log (transform.position.x + "," + transform.position.y);
			}
		}

		if (this.x > this.minX) {
			if (Input.GetKey(KeyCode.LeftArrow)){
				transform.position += Vector3.left * speed * dt;
			}
		}

		if (this.y < this.maxY) {
			if (Input.GetKey(KeyCode.UpArrow)){
				transform.position += Vector3.up * speed * dt;
			}
		}

		if (this.y > this.minY) {
			if (Input.GetKey(KeyCode.DownArrow)){
				transform.position += Vector3.down * speed * dt;
			}
		}

	}
}
