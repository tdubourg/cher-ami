using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
    public GameObject pigeon;
    public Transform pigeonPosition;
    private Vector3 direction;
    public int speed;

    // Use this for initialization
    void Start () {
        pigeon pigeon = pigeon.getInstance();
        // Add velocity to the bullet
        direction = (pigeon.transform.position - this.transform.position).normalized;

        //this rotates the bullet to face the pigeon
        Vector2 dir = this.transform.position - pigeon.transform.position;
        this.transform.right = dir;
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(direction * speed * Time.deltaTime);
    }
}
