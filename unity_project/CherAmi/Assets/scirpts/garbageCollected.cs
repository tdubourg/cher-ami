using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class garbageCollected : MonoBehaviour {
    public float DISTANCE_FROM_BOUNDING_BOX_CENTER;
    public static int GARBAGE_COLLECTION_INTERVAL_IN_SEC = 5;
    float timeSinceLastGarbageCollection = 0;
    OwnNamedObject onb;
	// Use this for initialization
	void Start () {
        var bound_box_diagonal_from_center = Mathf.Sqrt(Mathf.Pow(game.maxY - game.minY, 2) + Mathf.Pow(game.maxX - game.minX, 2));
        // We start to garbage collect when the object is more than 1.5x the bounding box diagonal away from the center. This gives us a little bit of margin
        DISTANCE_FROM_BOUNDING_BOX_CENTER = 1.5f * bound_box_diagonal_from_center;
        Debug.Log("distance threshold for deletion:" + DISTANCE_FROM_BOUNDING_BOX_CENTER);
        this.onb = this.transform.GetComponent<OwnNamedObject>();
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("GBG Update on " + this.onb.getOwnName());
        timeSinceLastGarbageCollection += Time.deltaTime;
        if (timeSinceLastGarbageCollection > GARBAGE_COLLECTION_INTERVAL_IN_SEC)
        {
            timeSinceLastGarbageCollection = 0;
            collectGarbage();
        }
	}

    void collectGarbage()
    {
        Debug.Log("Trying to garbage collect " + this.onb.getOwnName());
        if (!game.IsWithinGamesBounds(this.transform.position))
        {
            Debug.Log(this.onb.getOwnName() + " is not within the bouding box");
            Debug.Log("Scene center:" + game.getSceneCenter());
            if (game.getDistanceFromSceneCenter(this.transform.position) > DISTANCE_FROM_BOUNDING_BOX_CENTER)
            {
                Debug.Log(this.onb.getOwnName() + " got too far, destroying it.");
                Destroy(this.gameObject);
            }
        }
    }
}
