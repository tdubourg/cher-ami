using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game : MonoBehaviour {


    static game singleTon = null;

    public static game getInstance()
    {
        return game.singleTon;
    }
    public static float maxX = 50.0f;
    public static float minX = -50.0f;
    public static float maxY = 65.0f;
    public static float minY = 0.0f;

	public GUIText scoreText;
	private int score;
    
    public static Vector3 getSceneCenter()
    {
        return new Vector3((maxX - minX) / 2, (maxY - minY) / 2, 0);
    }

    public static float getDistanceFromSceneCenter(Vector3 v)
    {
        return (v - game.getSceneCenter()).magnitude;
    }

    // Use this for initialization
    void Start () {
		score = 0;
        game.singleTon = this;

    }

    public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    static public bool IsWithinGamesBounds(Vector3 p)
    {
        if (p.x > maxX || p.y > maxY || p.x < minX || p.y < minY)
        {
            return false;
        }
        return true;
    }
}
