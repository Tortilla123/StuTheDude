using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour {

    private PlayerControllerMain Stu;

	// Use this for initialization
	void Start () {
        Stu = FindObjectOfType<PlayerControllerMain>();
Debug.Log("Poinnter Up");
	}
	
	public void Left()
    {
        Stu.Move(-1);
        
    }
    public void Exit()
    {
        Stu.Move(0);
    }

    public void Right()
    {
        Stu.Move(1);
    }

    public void Jump()
    {
        Stu.Jump();
    }
}
