using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pigeon : MonoBehaviour {
    public const bool INVICIBLE_MODE = false;
    public const int PIGEON_STARTING_HEALTH = 100;
    public const int PIGEON_ALLY_HEALTH_BOOST = 10;
    public const int PIGEON_HIT_BLINK_NUMBER = 3;
    public const float PIGEON_HIT_BLINK_INTERVAL = 0.1f;

    public GameObject feathers;

    static pigeon singleTon = null;

    public int Health
    {
        get { return health; }
        set { this.health = value; }
    }

    public static pigeon getInstance()
    {
        return pigeon.singleTon;
    }

	public float speed;

	private float x;
	private float y;
    
    private int health = PIGEON_STARTING_HEALTH;

    //void Blink(float waitTime)
    //{
    //    var endTime = Time.time + waitTime;
    //    while (Time.time < waitTime)
    //    {
    //        renderer.enabled = false;
    //        yield WaitForSeconds(0.2);
    //        renderer.enabled = true;
    //        yield WaitForSeconds(0.2);
    //    }
    //}

    void DisableAllRenderers()
    {
        var allRenderers = gameObject.GetComponentsInChildren< Renderer > ();
   
        foreach (var childRenderer in allRenderers)
        {
            childRenderer.enabled = false;
        }
    }

    void EnableAllRenderers()
    {
        var allRenderers = gameObject.GetComponentsInChildren<Renderer>();

        foreach (var childRenderer in allRenderers)
        {
            childRenderer.enabled = true;
        }
    }


    IEnumerator blink()
    {
        //Debug.Log("Entering blink()");
        for (int i = 0; i < PIGEON_HIT_BLINK_NUMBER; i++)
        {
            //Debug.Log("Turning renderer OFF");

            DisableAllRenderers();
            yield return new WaitForSeconds(PIGEON_HIT_BLINK_INTERVAL);
            //Debug.Log("Turning renderer ON");

            //GetComponent<Renderer>().enabled = true;
            EnableAllRenderers();
            yield return new WaitForSeconds(PIGEON_HIT_BLINK_INTERVAL);

        }
    }

    // Use this for initialization
    void Start () {
        pigeon.singleTon = this;
	}

	void ouch(Collider bulletThatHit) {				

		health = health - bullet.DAMAGE;
		Destroy (bulletThatHit.gameObject);
        var f = (GameObject)Instantiate(feathers, game.getInstance().groundGameObject.transform.position, game.getInstance().groundGameObject.transform.rotation);
        f.transform.SetPositionAndRotation(new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), game.getInstance().groundGameObject.transform.rotation);
        //Debug.Log ("OUCH! Health is now " + health);
		if (health <= 0) {
			health = 0;
			this.die ();
		} else
        {
            StartCoroutine(blink());
            //for (int i = 0; i < PIGEON_HIT_BLINK_NUMBER; i += 1)
            //{
            //    var a = blinkOnce();
            //}
        }
	}

	void die() {
        if (INVICIBLE_MODE) { return;  }
		Debug.Log ("GOODBYE CRUEL WORLD! I'M DED LOLZ");

        this.health = 0;

		gameObject.SetActive(false);

		game.getInstance().GameOver();
	}

	void OnTriggerEnter (Collider other){
		//Debug.Log ("TRIGGER ENTER");

		//Debug.Log ("Collided with " + other.name);

		if (other.name.Contains("bullet")) {
			this.ouch (other);
			Destroy (other);
		}
		if (other.name.Contains ("ally")) {
			
            // Trigger ally actions on touchong the pigeon
            other.gameObject.GetComponent<ally>().touchPigeon(this);
			//Destroy (other.gameObject);
		}
        else if (other.name.Contains("soldier"))
        {
            // die if you touch a soldier!
            this.die();
        }

    }


    // Update is called once per frame
    void Update () {
		var dt = Time.deltaTime;

		this.x = transform.position.x;
		this.y = transform.position.y;

		if (this.x < game.maxX) {
			if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
				transform.position += Vector3.right * speed * dt;
				//Debug.Log (transform.position.x + "," + transform.position.y);
			}
		}

		if (this.x > game.minX) {
			if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
				transform.position += Vector3.left * speed * dt;
			}
		}

		if (this.y < game.maxY) {
			if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)){
				transform.position += Vector3.up * speed * dt;
			}
		}

		if (this.y > game.minY) {
			if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)){
				transform.position += Vector3.down * speed * dt;
			}
		}

	}
}
