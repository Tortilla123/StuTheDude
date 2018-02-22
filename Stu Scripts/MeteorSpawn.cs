using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawn : MonoBehaviour
{
    public GameObject Meteor1;              //meteor1 Prefab
    public GameObject Meteor2;                //meteor2 Pickup Prefab
    public Vector3 meteor1Values;             //Vector 3 values for meteor1 spawn positions
    public Vector3 meteor2Values;        //Vector 3 values for meteor2 spawn positions
    public int meteorCount;                  //How many hearts will spawn per level
    public float meteorsTime;            //Time between meteor1 spawns
    public float firstMeteorsTime;            //Time before first meteor1 spawns

    void Start()
    {
        StartCoroutine(SpawnMeteor1());       //Function to spawn meteor1
        StartCoroutine(SpawnMeteor2());  //Function to spawn meteor2
    }

    IEnumerator SpawnMeteor1()
    {
        yield return new WaitForSeconds(firstMeteorsTime);

        //If the waves are not over and at 0, continue
            for (int i = 0; i < meteorCount; i++)
            {
                //randomizes meteor falling between specified x and y
                Vector3 spawnPosition = new Vector3(Random.Range(-meteor1Values.x, meteor1Values.x), meteor1Values.y, meteor1Values.z);
                //rotation of the game object
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(Meteor1, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(meteorsTime);  
            }
        }

    IEnumerator SpawnMeteor2()
    {
        yield return new WaitForSeconds(firstMeteorsTime);
            for (int i = 0; i < meteorCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-meteor2Values.x, meteor2Values.x), meteor2Values.y, meteor2Values.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(Meteor2, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(meteorsTime);
            }
    }
}

