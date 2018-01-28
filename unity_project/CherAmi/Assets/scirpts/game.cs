using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;


public class game : MonoBehaviour {
    public GameObject SgtStubbyPrefab;
    public GameObject groundGameObject;
    static game singleTon = null;

    public static game getInstance()
    {
        return game.singleTon;
    }
    public static float maxX = 50.0f;
    public static float minX = -50.0f;
    public static float maxY = 65.0f;
    public static float minY = 0.0f;

    const int SGT_STUBBY_TRIGGER_INTERVAL = 20;
    float timeSinceLastSgtStubbyTrigger = 0;


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
        scoreText.text = score.ToString();
        healthText.text = health.ToString();
    }

    public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore ()
	{
		scoreText.text = score.ToString();
	}

    void UpdateHealth()
    {
        health = pigeon.getInstance().Health;
        healthText.text = health.ToString();
    }

	public void GameOver ()
	{
		//gameOverText.text = "Game Over!";
		gameOver = true;
	}

    // Update is called once per frame
    void Update () {
        var dt = Time.deltaTime;
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

        this.timeSinceLastSgtStubbyTrigger += dt;
        if (this.timeSinceLastSgtStubbyTrigger > SGT_STUBBY_TRIGGER_INTERVAL)
        {
            this.timeSinceLastSgtStubbyTrigger = 0;
            triggerSgtStubby();
        }

		if (gameOver)
		{
			//Time.timeScale = 0;
			restartText.text = "Game Over! Press 'R' to Restart";
			restart = true;
			//break;

		}
    }

    public void triggerSgtStubby()
    {
        var newSgtStubby = (GameObject)Instantiate(SgtStubbyPrefab, groundGameObject.transform, groundGameObject.transform);
        var x = groundGameObject.transform.position.x - groundGameObject.transform.lossyScale.x / 2.0f - newSgtStubby.transform.lossyScale.x; // not dividing sgtstubby width by 2 in purpose, to give it a bit of distance
        var y = groundGameObject.transform.position.y + groundGameObject.transform.lossyScale.y / 2.0f + newSgtStubby.transform.lossyScale.y / 2;
        var position = new Vector3(x, y, groundGameObject.transform.position.z);
        newSgtStubby.transform.SetPositionAndRotation(position, groundGameObject.transform.rotation);
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
