using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class environment : MonoBehaviour {
    public const int SOLDIERS_SPAWN_INTERVAL_SEC = 5;
    static List<soldier> soldiers = new List<soldier>();
    float timeSinceLastSoldierSpawn = 0;
    public int TryAttribute = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var dt = Time.deltaTime;
        this.timeSinceLastSoldierSpawn += dt;
        if (this.timeSinceLastSoldierSpawn > SOLDIERS_SPAWN_INTERVAL_SEC)
        {
            this.timeSinceLastSoldierSpawn = 0;
            // spawn the soldier
            Debug.Log("Spawning a new soldier");
          //  Instantiate(Player, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}

/*
var Environment = pc.createScript('Environment');

var soldiers = [];

SOLDIERS_SPAWN_INTERVAL_SEC = 5; // interval in seconds, to spawn a soldier
    
// initialize code called once per entity
Environment.prototype.initialize = function()
{
    this.timeSinceLastSpawn = 0;
};

// update code called every frame
Environment.prototype.update = function(dt)
{
    // console.log("envUpd");

    var player = this.entity; // This script is attached to the pigeon so this.entity points to the player
                              // console.log("Current player position is", player.getPosition());
                              // console.log("pcscriptcomponent", pc.ScriptComponent.scripts);
                              // console.log(Pigeon);
    this.genEnvironment(dt);

};

Environment.prototype.genEnvironment = function(dt)
{
    // console.log("genEnv");
    // console.log("elapsedTime", Game.game.elapsedTime);
    this.timeSinceLastSpawn += dt;
    // console.log("Time since last soldier spawn:", this.timeSinceLastSpawn, dt);
    if (this.timeSinceLastSpawn > SOLDIERS_SPAWN_INTERVAL_SEC)
    {
        console.log("Spawning a new soldier");
        this.timeSinceLastSpawn = 0;
        var newSoldier = this.app.root.findByName("soldier").clone();
        var ppos = Pigeon.pigeon.getPosition();
        var ground_pos = this.app.root.findByName("GROUND").getPosition();
        console.log("minX", Pigeon.pigeon.attributes.get("minX"));
        newSoldier.setPosition(ppos.x + 10, ground_pos.y, 0);
        this.app.root.addChild(newSoldier);
    }
}
*/