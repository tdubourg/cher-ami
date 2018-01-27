using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pigeon : MonoBehaviour {


    static pigeon singleTon = null;

    public static pigeon getInstance()
    {
        return pigeon.singleTon;
    }

	public float speed = 75.0f;

	private float x;
	private float y;

	private int health = 100;

	// Use this for initialization
	void Start () {
        pigeon.singleTon = this;
	}

	void OnCollisionEnter (Collision col) {
		Debug.Log ("3D COLLISION ENTER");
	}

	void ouch(Collider bulletThatHit) {		
		var b = bulletThatHit.gameObject.GetComponent<bullet>();
		if (b.damage > 1) {
			health = health - b.damage;
		} else {
			health = health - 1; //TODO fixed default
		}

		Debug.Log ("OUCH! Health is now " + health);
		if (health <= 0) {
			health = 0;
			this.die ();
		}
	}

	void die() {
		Debug.Log ("GOODBYE CRUEL WORLD! I'M DED LOLZ");
		//
	}

	void OnTriggerEnter (Collider other){
		//Debug.Log ("TRIGGER ENTER");

		Debug.Log ("Collided with " + other.name);

		if (other.name.Contains("bullet")) {
			this.ouch (other);
		}
		if (other.name.Contains ("ally")) {
			GetComponent<game>().AddScore(1);
		}
	}


	// Update is called once per frame
	void Update () {
		var dt = Time.deltaTime;

		this.x = transform.position.x;
		this.y = transform.position.y;

		if (this.x < game.maxX) {
			if (Input.GetKey(KeyCode.RightArrow)){
				transform.position += Vector3.right * speed * dt;
				Debug.Log (transform.position.x + "," + transform.position.y);
			}
		}

		if (this.x > game.minX) {
			if (Input.GetKey(KeyCode.LeftArrow)){
				transform.position += Vector3.left * speed * dt;
				Debug.Log (transform.position.x + "," + transform.position.y);
			}
		}

		if (this.y < game.maxY) {
			if (Input.GetKey(KeyCode.UpArrow)){
				transform.position += Vector3.up * speed * dt;
				Debug.Log (transform.position.x + "," + transform.position.y);
			}
		}

		if (this.y > game.minY) {
			if (Input.GetKey(KeyCode.DownArrow)){
				transform.position += Vector3.down * speed * dt;
				Debug.Log (transform.position.x + "," + transform.position.y);
			}
		}

	}
}
