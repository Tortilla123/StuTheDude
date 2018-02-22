using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectiles : MonoBehaviour {

    public float laserSpeed;
    public Rigidbody2D laser;
    public GameObject laserObject;


	// Use this for initialization
	void Awake () {
        if (transform.localRotation.z > 0)
            laser.AddForce(new Vector2(-1, 0) * laserSpeed, ForceMode2D.Impulse);
        else laser.AddForce(new Vector2(1, 0) * laserSpeed, ForceMode2D.Impulse);
        

	}

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Ground"))
        {
            laserObject.gameObject.SetActive(false);
        }
        if (coll.gameObject.CompareTag("MovingObject"))
        {
            laserObject.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
