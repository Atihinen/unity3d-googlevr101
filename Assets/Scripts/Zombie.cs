using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {
    private GameObject target;
    private float speed;
	// Use this for initialization
	void Start () {
        target = Camera.main.gameObject;
        speed = Random.Range(0.5f, 3);
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
