using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textEffect : MonoBehaviour {

    public GameObject myText;
    bool text;
    float elapsedTime;

    void Start()
    {
        myText.SetActive(true);

    }
    void FixedUpdate()
    {
        elapsedTime += 1.0f * Time.deltaTime;
        if (elapsedTime >= 7)
        {
            myText.SetActive(false);
        }
    }

}
