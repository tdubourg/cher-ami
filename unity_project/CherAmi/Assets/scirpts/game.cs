using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class game : MonoBehaviour {

    public static float maxX = 50.0f;
    public static float minX = -50.0f;
    public static float maxY = 65.0f;
    public static float minY = 0.0f;

	public Text scoreText;
	public Text healthText;
	private int score;
    private int health;

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
		health = 100;
        scoreText.text = "Score: " + score;
        healthText.text = "Health: " + health;
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

    void UpdateHealth()
    {
        health = pigeon.getInstance().Health;
        healthText.text = "Health: " + health;
    }

    // Update is called once per frame
    void Update () {
        UpdateHealth();
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
