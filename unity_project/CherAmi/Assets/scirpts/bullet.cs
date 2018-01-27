using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OwnNamedObject: MonoBehaviour
{
    // THis is mostly useful for debugging, so that every soldier has its own name
    public string ownName = "unnamed yet";

    public string getOwnName()
    {
        return ownName;
    }

    public abstract void nameIt();
}

public class bullet : OwnNamedObject {
    public GameObject pigeon;
    static int BULLETS_COUNT = 0;
    private Vector2 pigeonPosition;
    private Vector2 direction;
    public int speed = 20;
    public int damage = 10;

    override public void nameIt()
    {
        bullet.BULLETS_COUNT += 1;
        ownName = "Bullet N" + bullet.BULLETS_COUNT;
    }

    // Use this for initialization
    void Start () {

        nameIt();
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
		this.transform.position = Vector2.MoveTowards(new Vector2(this.transform.position.x, this.transform.position.y), pigeonPosition, speed * Time.deltaTime);

		//this.transform.position = pigeon.getInstance ().transform.position;

    }
}
