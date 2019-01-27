using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestControllerScript : MonoBehaviour {

	void Start ()
    {
	}
	
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            string[] lines = new string[3];
            string test = "Trying to add a line to our DialogueSystem";
            string test2 = "Line 2 ";
            string test3 = "Line 3, last line";

            lines[0] = test;
            lines[1] = test2;
            lines[2] = test3;
            DialogueSystem.Instance.AddNewDialogue(lines, "TestControllerScript");
        }
	}
}
