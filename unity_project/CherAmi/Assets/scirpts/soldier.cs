using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soldier : OwnNamedObject {
    public const int SOLDIER_HIT_BLINK_NUMBER = 3;
    public const float SOLDIER_HIT_BLINK_INTERVAL = 0.1f;

    const float INTERVAL_BETWEEN_SHOTS_IN_SEC = 1.0f;
    static int SOLDIERS_COUNT = 0;
    float timeSinceLastShot = 0;
    public AudioClip firingSound1;
    public AudioClip firingSound2;
    AudioSource audioSource;


    void DisableAllRenderers()
    {
        var allRenderers = gameObject.GetComponentsInChildren<Renderer>();

        foreach (var childRenderer in allRenderers)
        {
            childRenderer.enabled = false;
        }
    }

    void EnableAllRenderers()
    {
        var allRenderers = gameObject.GetComponentsInChildren<Renderer>();

        foreach (var childRenderer in allRenderers)
        {
            childRenderer.enabled = true;
        }
    }


    IEnumerator blinkAndDie()
    {
        //Debug.Log("Entering blink()");
        for (int i = 0; i < SOLDIER_HIT_BLINK_NUMBER; i++)
        {
            //Debug.Log("Turning renderer OFF");

            DisableAllRenderers();
            yield return new WaitForSeconds(SOLDIER_HIT_BLINK_INTERVAL);
            //Debug.Log("Turning renderer ON");

            //GetComponent<Renderer>().enabled = true;
            EnableAllRenderers();
            yield return new WaitForSeconds(SOLDIER_HIT_BLINK_INTERVAL);

        }
        Destroy(this.gameObject);
    }


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
        }
	}

    public void die()
    {
        StartCoroutine(blinkAndDie());
        
    }

    static public GameObject getChildGameObject(GameObject fromGameObject, string name)
    {
        Transform[] ts = fromGameObject.transform.GetComponentsInChildren<Transform>();
        foreach (Transform t in ts) if (t.gameObject.name == name) return t.gameObject;
        return null;
    }

    void Fire()
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject) Instantiate(
            bulletPrefab,
            this.transform.position,
            this.transform.rotation);

        var rifle = getChildGameObject(this.gameObject, "rifle");
        Debug.Log(rifle);
        var height = rifle.transform.lossyScale.y;
        var width = rifle.transform.lossyScale.x;
        var y = rifle.transform.position.y + 0.15f * height; // rifle seems located aout 85% up
        var x = rifle.transform.position.x - width / 2.3f;
        var position = new Vector3(x, y, this.transform.position.z);
        // The soldier is actually rotated, so we should use the transform rotation from something stable: the ground
        bullet.transform.SetPositionAndRotation(position, game.getInstance().groundGameObject.transform.rotation);

        if (Random.Range(1, 5) == 3)
        {
            PlayFiringSound(Random.Range(0, 2));
        }
        
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
