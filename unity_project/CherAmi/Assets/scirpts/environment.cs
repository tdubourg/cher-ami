using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class environment : MonoBehaviour {
    public GameObject soldierPrefab;
    public GameObject landingPlatformPrefab;
    public GameObject spawnPoint;

    public const float ENVIRONMENT_SCROLL_SPEED = 0.5f;
    public static Vector3 ENVIRONMENT_SCROLL_VECTOR = new Vector3(-1, 0, 0);

    public const int SOLDIERS_SPAWN_INTERVAL_SEC = 3;
    public const int PLATFORMS_SPAWN_INTERVAL_SEC = 4;
    static List<soldier> soldiers = new List<soldier>();
    float timeSinceLastSoldierSpawn = 0; float timeSinceLastEmptyPlatformSpawn = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var dt = Time.deltaTime;
        this.timeSinceLastSoldierSpawn += dt;
        this.timeSinceLastEmptyPlatformSpawn += dt;

        if (this.timeSinceLastSoldierSpawn > SOLDIERS_SPAWN_INTERVAL_SEC)
        {
            this.timeSinceLastSoldierSpawn = 0;
            // spawn the soldier
            Debug.Log("Spawning a new soldier");

            // Create the Bullet from the Bullet Prefab
            var soldier = (GameObject)Instantiate(
                soldierPrefab,
                spawnPoint.transform, spawnPoint.transform);
            var vec = spawnPoint.transform.position;
            vec = new Vector3(vec.x, vec.y + soldier.transform.lossyScale.y / 2, vec.z);
            soldier.transform.SetPositionAndRotation(vec, spawnPoint.transform.rotation);
        } else if (this.timeSinceLastEmptyPlatformSpawn > PLATFORMS_SPAWN_INTERVAL_SEC) {
                this.timeSinceLastEmptyPlatformSpawn = 0;
                // spawn the soldier
                Debug.Log("Spawning a new platform");

                // Create the Bullet from the Bullet Prefab
                var emptyPlatform = (GameObject)Instantiate(
                    landingPlatformPrefab,
                    spawnPoint.transform, spawnPoint.transform);
                var vec = spawnPoint.transform.position;
                vec = new Vector3(vec.x, vec.y + emptyPlatform.transform.lossyScale.y / 2, vec.z);
            emptyPlatform.transform.SetPositionAndRotation(vec, spawnPoint.transform.rotation);
        }
    }
}
