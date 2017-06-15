using UnityEngine;
using System.Collections;

public class PlayerAim : MonoBehaviour {
    public GameObject indicator;
    private readonly string zombieTag = "zombie";
    private bool countDown = false;
    private readonly float maxTimeout = 2;
    private float timeout;
	public Camera cam;
	// Use this for initialization
	void Start () {
        indicator.SetActive(false);
        timeout = maxTimeout;
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit vHit = new RaycastHit();
        Ray vRay = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if(Physics.Raycast(vRay, out vHit, 100))
        {
			Debug.DrawLine (transform.position, vHit.point, Color.cyan);
            if (vHit.collider.gameObject.tag.Equals(this.zombieTag))
            {
                Debug.Log("Zombiee!");
                indicator.SetActive(true);
                countDown = true;
            }
            else
            {
                resetIndicator();
            }
        }
        if (countDown)
        {
            timeout -= Time.deltaTime;
            if (timeout < 0)
            {
                Destroy(vHit.collider.gameObject);
                resetIndicator();
            }
        }
    }

    private void resetIndicator()
    {
        indicator.SetActive(false);
        countDown = false;
        timeout = maxTimeout;
    }
}
