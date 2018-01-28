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
    static int BULLETS_COUNT = 0;
    private Vector2 pigeonPosition;
    private Vector2 direction;
    private int speed = 50;
    public int damage = 5;

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
		var heading = new Vector3(pigeonPosition.x, pigeonPosition.y, 0) - this.transform.position;
		heading.y = 0;
		var distance = heading.magnitude;
		this.direction = heading / distance;

        //this rotates the bullet to face the pigeon
        Vector2 dir = this.transform.position - pigeon.transform.position;
        this.transform.right = dir;


    }

	// Update is called once per frame
	void Update () {
		
		if (direction.x > 0) {
			direction = -direction;
		}
		transform.Translate(this.direction * speed * Time.deltaTime);

    }
}
