using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatform : MonoBehaviour {
    public GameObject Platform;
    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Platform.transform.Rotate(0, 0,Time.deltaTime*speed);
	}
}
