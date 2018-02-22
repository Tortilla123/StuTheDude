using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenLevel : MonoBehaviour
{
    public Rigidbody2D stu;

    //Player oxygen vairables
    public float playerOxygen;              //Player Oxygen lvl
    float currentOxygen = 0f;
    private float deplete;

    //HUD Oxygen Variables
    public Transform healthBar;
    public Image oxygenBar;
    
    //damage indicator for when hit by meteor variables
    public Image damageScreen;
    bool damage = false;
    Color damageColor = new Color(.5f, .5f, .5f, 0.50f);    //Damage indiccator numbers for opacity of the image
    float smoothColor = 50f;                                //smooths the image when hit.

    //variables for oxygen below 10
    public Image lowOxygen;
    Color lowOxygenColor = new Color(0.75f, 0.75f, 0.75f, .75f);

    public int sceneIndex;
    //PlayerControllerMain controller;

    // Use this for initialization
    void Start()
    {
        currentOxygen = playerOxygen;
        deplete = 1;
        //HUD  Initialization
        
        stu = GetComponent<Rigidbody2D>();
        //controller = GetComponent<PlayerControllerMain>();
        

    }
    void Update()
    {
        //code for when hit by a meteor
        if (damage)
            {
                 damageScreen.color = damageColor;
            }else
            {
                damageScreen.color = Color.Lerp(damageScreen.color, Color.clear, smoothColor*Time.deltaTime);
            }
            damage = false;

        if (currentOxygen <= 10)
        {
            StartCoroutine(Low());
        }
       
    }


    void FixedUpdate()
    {
        if (currentOxygen > 0)
        { 
            //depletes health by 1 every frame
            currentOxygen -= deplete * Time.fixedDeltaTime;
            //counter for time
            //elapsedTime += 1.0f * Time.deltaTime;
            float percentOxygen = currentOxygen / playerOxygen;

            healthBar.GetComponent<Image>().fillAmount = percentOxygen;   //GUI, code for depleting oxygen.
        }

        //Checks if player is dead, and kills him if he reaches 0, and respawns
        if (currentOxygen <= 0)
        {
            makeDead();
        }
    }
    IEnumerator Low()
    {
        //lowOxygen.color = lowOxygenColor;
        while (true)
        {
            lowOxygen.color = Color.Lerp(damageScreen.color, Color.clear, smoothColor * Time.deltaTime);
            yield return new WaitForSeconds(1f);
            lowOxygen.color = lowOxygenColor;
            yield return new WaitForSeconds(1f);
            lowOxygen.color = lowOxygenColor;
        }
    }
    void makeDead()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Meteor"))
        {
            damage = true;
            other.gameObject.SetActive(false);
            currentOxygen -= 5;
        }

        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            if (currentOxygen <= 100)
            {
                currentOxygen += 7F;
            }
            if (currentOxygen > 100)
            {
                currentOxygen = playerOxygen;
            }
            
        }
    }


}

