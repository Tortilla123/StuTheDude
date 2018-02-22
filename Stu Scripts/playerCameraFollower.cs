using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCameraFollower : MonoBehaviour {
    public Transform stu; //what the camera is following
    public float smoothing; //the dampening movements of camera

    Vector3 offset;

    float lowY; //lowest point the camera will go, 

	// Use this for initialization
	void Start () {
        offset = transform.position - stu.position;

        lowY = transform.position.y;	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 stuCamPos = stu.position + offset;
        transform.position = Vector3.Lerp(transform.position, stuCamPos, smoothing * Time.deltaTime);

        if (transform.position.y < lowY) { transform.position = new Vector3(transform.position.x, lowY, transform.position.z); }
	}
}
