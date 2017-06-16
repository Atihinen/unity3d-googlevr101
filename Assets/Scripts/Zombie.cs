using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {
    private GameObject target;
    private float speed;
	private readonly string targetTag = "Player";
	public float minSpeed = 0.1f;
	public float maxSpeed = 0.5f;
	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag (targetTag);
		speed = Random.Range(this.minSpeed, this.maxSpeed);
	}
	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
        float dist = Vector3.Distance(transform.position, target.transform.position);
        if (dist < 1f)
        {
            Destroy(gameObject);
        }
    }
}
