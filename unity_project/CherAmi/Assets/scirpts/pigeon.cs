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
	private int stamina = 100;

	// Use this for initialization
	void Start () {
        pigeon.singleTon = this;
	}

	void OnCollisionEnter (Collision col) {
		Debug.Log ("3D COLLISION ENTER");
	}

	void ouch(Collider bullet) {
		health = health - 10; //TODO: bullet.damage
		//

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

	void OnCollisionEnter2D (Collision2D col)
	{

		Debug.Log ("2d Collision ENTER");
//		if(col.gameObject.name == "bullet")
//		{
//			//Destroy(col.gameObject);
//		}
	}

	void OnTriggerEnter (Collider other){
		//Debug.Log ("TRIGGER ENTER");
		Debug.Log ("Collided with " + other.name);

		if (other.name.Contains("bullet")) {
			this.ouch (other);
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
				//Debug.Log (transform.position.x + "," + transform.position.y);
			}
		}

		if (this.x > game.minX) {
			if (Input.GetKey(KeyCode.LeftArrow)){
				transform.position += Vector3.left * speed * dt;
			}
		}

		if (this.y < game.maxY) {
			if (Input.GetKey(KeyCode.UpArrow)){
				transform.position += Vector3.up * speed * dt;
			}
		}

		if (this.y > game.minY) {
			if (Input.GetKey(KeyCode.DownArrow)){
				transform.position += Vector3.down * speed * dt;
			}
		}

	}
}
