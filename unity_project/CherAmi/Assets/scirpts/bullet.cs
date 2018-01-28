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
    private int speed = 90;
    public const int DAMAGE = 5;
    public const float PIGEON_SHOOT_DIRECTION_Y_OFFSET = 7.0f;

    override public void nameIt()
    {
        bullet.BULLETS_COUNT += 1;
        ownName = "Bullet N" + bullet.BULLETS_COUNT;
    }

    // Use this for initialization
    void Start () {

        nameIt();
        pigeon pigeon = pigeon.getInstance();
        var pCollider = pigeon.getInstance().GetComponent<Collider>();
        var pigeonPosition = pCollider.transform.position;
        // Add velocity to the bullet
		var heading = pigeonPosition + new Vector3(0, PIGEON_SHOOT_DIRECTION_Y_OFFSET, 0) - this.transform.position;
		//heading.y = 0;
		//var distance = heading.magnitude;
		//this.direction = heading / distance;

        //this rotates the bullet to face the pigeon
        //Vector2 dir = this.transform.position - pigeon.transform.position;
        this.transform.right = heading.normalized;


    }

	// Update is called once per frame
	void Update () {
		
		if (direction.x > 0) {
			direction = -direction;
		}
		transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);

    }
}
