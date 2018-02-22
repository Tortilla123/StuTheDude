using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class death : MonoBehaviour {

    public int sceneIndex;
    public float minHeightForDeath;
    public GameObject player; //Add your player

    void Update()
    {
        if (player.transform.position.y < minHeightForDeath)
            loadSceneByIndex();
            
    }
    void loadSceneByIndex()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    
}
