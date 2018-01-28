using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;


public class game : MonoBehaviour {
    public GameObject SgtStubbyPrefab;

    static game singleTon = null;

    public static game getInstance()
    {
        return game.singleTon;
    }
    public static float maxX = 50.0f;
    public static float minX = -50.0f;
    public static float maxY = 65.0f;
    public static float minY = 0.0f;


	public Text restartText;

	private bool gameOver;
	private bool restart;

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
        game.singleTon = this;

		gameOver = false;
		restart = false;
		restartText.text = "";

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

	public void GameOver ()
	{
		//gameOverText.text = "Game Over!";
		gameOver = true;
	}

    // Update is called once per frame
    void Update () {
        UpdateHealth();
		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				//Time.timeScale = 1;
				SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
				//SceneManager.loadScene(Scene
			}
		}

		if (gameOver)
		{
			//Time.timeScale = 0;
			restartText.text = "Game Over! Press 'R' to Restart";
			restart = true;
			//break;

		}
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
