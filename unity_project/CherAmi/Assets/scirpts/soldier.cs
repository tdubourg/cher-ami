using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soldier : OwnNamedObject {
    const int INTERVAL_BETWEEN_SHOTS_IN_SEC = 1;
    static int SOLDIERS_COUNT = 0;
    float timeSinceLastShot = 0;
    public AudioClip firingSound1;
    public AudioClip firingSound2;
    AudioSource audioSource;

    override public void nameIt()
    {
        soldier.SOLDIERS_COUNT += 1;
        ownName = "Soldier N" + soldier.SOLDIERS_COUNT;
    }


    public GameObject bulletPrefab;

    // Use this for initialization
    void Start () {
        nameIt();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
        var dt = Time.deltaTime;
        this.timeSinceLastShot += dt;
        if (this.timeSinceLastShot > INTERVAL_BETWEEN_SHOTS_IN_SEC)
        {
            this.timeSinceLastShot = 0;
            Fire();
           // Debug.Log("Spawning a new bullet for soldier " + ownName);
        }
	}

    void Fire()
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject) Instantiate(
            bulletPrefab,
            this.transform.position,
            this.transform.rotation);

        if (Random.Range(1, 5) == 3)
        {
            PlayFiringSound(Random.Range(0, 2));
        }

        // Destroy the bullet after 2 seconds
        //Destroy(bullet, 2.0f);
    }

    void PlayFiringSound(int soundNum)
    {
        switch (soundNum)
        {
            case 0:
                audioSource.PlayOneShot(firingSound1, 0.7F);
                break;
            case 1:
                audioSource.PlayOneShot(firingSound2, 0.7F);
                break;
        }
    }
}
