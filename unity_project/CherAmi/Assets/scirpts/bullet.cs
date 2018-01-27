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
    public Transform pigeonPosition;
    private Vector3 direction;
    public int speed;

    override public void nameIt()
    {
        bullet.BULLETS_COUNT += 1;
        ownName = "Bullet N" + bullet.BULLETS_COUNT;
    }

    // Use this for initialization
    void Start () {

        nameIt();
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
