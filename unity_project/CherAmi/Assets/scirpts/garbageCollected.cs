using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class garbageCollected : MonoBehaviour {
    public float DISTANCE_FROM_BOUNDING_BOX_CENTER;
    public static int GARBAGE_COLLECTION_INTERVAL_IN_SEC = 10;
    float timeSinceLastGarbageCollection = 0;
	// Use this for initialization
	void Start () {
        var bound_box_diagonal_from_center = Mathf.Sqrt(Mathf.Pow(game.maxY - game.minY, 2) + Mathf.Pow(game.maxX - game.minX, 2));
        // We start to garbage collect when the object is more than 1.5x the bounding box diagonal away from the center. This gives us a little bit of margin
        DISTANCE_FROM_BOUNDING_BOX_CENTER = 1.5f * bound_box_diagonal_from_center;
	}
	
	// Update is called once per frame
	void Update () {
        timeSinceLastGarbageCollection += Time.deltaTime;
        if (timeSinceLastGarbageCollection > GARBAGE_COLLECTION_INTERVAL_IN_SEC)
        {
            timeSinceLastGarbageCollection = 0;
            collectGarbage();
        }
	}

    void collectGarbage()
    {
        if (!game.IsWithinGamesBounds(this.transform.position) && game.getDistanceFromSceneCenter(this.transform.position) > DISTANCE_FROM_BOUNDING_BOX_CENTER) ;
        {
            Debug.Log("Bullet got too far, destroying it.");
            Destroy(this);
        }
    }
}
