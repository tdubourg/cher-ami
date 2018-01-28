using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class environment : MonoBehaviour {
    public GameObject soldierPrefab;
    public GameObject landingPlatformPrefab;
    public Transform spawnPoint;

    public const float ENVIRONMENT_SCROLL_SPEED = 0.5f;
    public static Vector3 ENVIRONMENT_SCROLL_VECTOR = new Vector3(-1, 0, 0);

    public const int SOLDIERS_SPAWN_INTERVAL_SEC = 3;
    static List<soldier> soldiers = new List<soldier>();
    float timeSinceLastSoldierSpawn = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var dt = Time.deltaTime;
        this.timeSinceLastSoldierSpawn += dt;
        if (this.timeSinceLastSoldierSpawn > SOLDIERS_SPAWN_INTERVAL_SEC)
        {
            this.timeSinceLastSoldierSpawn = 0;
            // spawn the soldier
            Debug.Log("Spawning a new soldier");

            // Create the Bullet from the Bullet Prefab
            var soldier = (GameObject)Instantiate(
                soldierPrefab,
                this.transform, this.transform);
        }
    }
}
