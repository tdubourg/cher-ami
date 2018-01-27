using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
    private Vector2 pigeonPosition;
    private Vector2 direction;
    public int speed;
    public int damage = 10;

    // Use this for initialization
    void Start () {
        pigeon pigeon = pigeon.getInstance();
        pigeonPosition = pigeon.transform.position;
        // Add velocity to the bullet
        direction = (pigeon.transform.position - this.transform.position).normalized;

        //this rotates the bullet to face the pigeon
        Vector2 dir = this.transform.position - pigeon.transform.position;
        this.transform.right = dir;
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.position = Vector2.MoveTowards(pigeonPosition, new Vector2(this.transform.position.x, this.transform.position.y), speed * Time.deltaTime);

    }
}
