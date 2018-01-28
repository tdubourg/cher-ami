using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class environment : MonoBehaviour {
    public GameObject soldierPrefab;
    public GameObject landingPlatformPrefab;
    public GameObject spawnPoint;
    public GameObject allyPrefab;


    public const float ENVIRONMENT_SCROLL_SPEED = 0.5f;
    public static Vector3 ENVIRONMENT_SCROLL_VECTOR = new Vector3(-1, 0, 0);

    public const int SOLDIERS_SPAWN_INTERVAL_SEC = 3;
    public const int PLATFORMS_SPAWN_INTERVAL_SEC = 4;
    public const int ALLY_ON_PLATFORM_FREQUENCY = 2; // an ally is on the platform every X platforms spawning
    public const double MINIMUM_TIME_BETWEEN_ANY_SPAWN_IN_SEC = 1.5;
    static List<soldier> soldiers = new List<soldier>();
    float timeSinceLastSoldierSpawn = 0; float timeSinceLastEmptyPlatformSpawn = 0;
    int platformsSinceLastAlly = 0;
    float timeSinceLastAnySpawn = 0;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var dt = Time.deltaTime;
        this.timeSinceLastSoldierSpawn += dt;
        this.timeSinceLastEmptyPlatformSpawn += dt;
        this.timeSinceLastAnySpawn += dt;

        if (this.timeSinceLastAnySpawn > MINIMUM_TIME_BETWEEN_ANY_SPAWN_IN_SEC && this.timeSinceLastSoldierSpawn > SOLDIERS_SPAWN_INTERVAL_SEC)
        {
            this.timeSinceLastSoldierSpawn = 0;
            this.timeSinceLastAnySpawn = 0;
            // spawn the soldier
            Debug.Log("Spawning a new soldier");

            // Create the Bullet from the Bullet Prefab
            var soldier = (GameObject)Instantiate(
                soldierPrefab,
                spawnPoint.transform, spawnPoint.transform);
            var vec = spawnPoint.transform.position;
            vec = new Vector3(vec.x, vec.y + soldier.transform.lossyScale.y / 2, vec.z);
            soldier.transform.SetPositionAndRotation(vec, spawnPoint.transform.rotation);
        } else if (this.timeSinceLastAnySpawn > MINIMUM_TIME_BETWEEN_ANY_SPAWN_IN_SEC && this.timeSinceLastEmptyPlatformSpawn > PLATFORMS_SPAWN_INTERVAL_SEC) {
            this.platformsSinceLastAlly += 1;
            this.timeSinceLastAnySpawn = 0;

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
            if (this.platformsSinceLastAlly > ALLY_ON_PLATFORM_FREQUENCY)
            {
                Debug.Log("Ally on the platform");
                this.platformsSinceLastAlly = 0;
                var platTr = emptyPlatform.transform;
                var ally = (GameObject)Instantiate(allyPrefab, platTr, platTr);
                var y = platTr.position.y + platTr.lossyScale.y / 2.0f + ally.transform.lossyScale.y / 2.0f;
                var position = new Vector3(platTr.position.x, y, platTr.position.z);
                ally.transform.SetPositionAndRotation(position, platTr.rotation);
            }
        }
    }
}
