using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour {

    public Transform spawnPoint;//Add empty gameobject as spawnPoint
    public float minHeightForDeath;
    public GameObject player; //Add your player

    void Update()
    {
        if (player.transform.position.y < minHeightForDeath)
            player.transform.position = spawnPoint.position;
    }

    
}
