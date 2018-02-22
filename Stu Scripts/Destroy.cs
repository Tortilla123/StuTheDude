using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {
    public GameObject Meteor; //Add your player

    void Update()
    {
        if (Meteor.transform.position.y < -100)
        {
            Destroy(Meteor, 3f);
        }

    }
}
