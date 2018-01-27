using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soldier : MonoBehaviour {
    const int INTERVAL_BETWEEN_SHOTS_IN_SEC = 1;
    static int SOLDIERS_COUNT = 0;
    float timeSinceLastShot = 0;
    // THis is mostly useful for debugging, so that every soldier has its own name
    string ownName = "unnamed yet";

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    // Use this for initialization
    void Start () {
        soldier.SOLDIERS_COUNT += 1;
        ownName = "Soldier N" + soldier.SOLDIERS_COUNT;
	}
	
	// Update is called once per frame
	void Update () {
        var dt = Time.deltaTime;
        this.timeSinceLastShot += dt;
        if (this.timeSinceLastShot > INTERVAL_BETWEEN_SHOTS_IN_SEC)
        {
            this.timeSinceLastShot = 0;
            Fire();
            Debug.Log("Spawning a new bullet for soldier " + ownName);
        }
	}

    void Fire()
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        // Destroy the bullet after 2 seconds
        //Destroy(bullet, 2.0f);
    }
}
