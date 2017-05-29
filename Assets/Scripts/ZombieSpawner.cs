using UnityEngine;
using System.Collections;

public class ZombieSpawner : MonoBehaviour {
    private readonly string spawnPointTag = "Respawn";
    private GameObject[] spawnPoints;
    public GameObject zombie;
    public float coolDown = 5;
    private float actualCoolDown;
	// Use this for initialization
	void Start () {
        spawnPoints = GameObject.FindGameObjectsWithTag(this.spawnPointTag);
        Debug.Log("Zombie spwaners: " + spawnPoints.Length);
        actualCoolDown = coolDown;
	}
	
	// Update is called once per frame
	void Update ()
    {
        actualCoolDown -= Time.deltaTime;
        if(actualCoolDown < 0)
        {
            int ind = Random.Range(0, spawnPoints.Length);
            Debug.Log("Index: " + ind);
            GameObject spawn = spawnPoints[ind];
            Instantiate(zombie, spawn.transform.position, spawn.transform.rotation);
            actualCoolDown = coolDown;
        }

    }
}
