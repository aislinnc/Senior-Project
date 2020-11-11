using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UXF;

public class GetKeyPress : MonoBehaviour
{
    public Session session;
    public bool keyPressed;

    // Update is called once per frame
    public void Update()
    {
        // Checks if a key has been pressed
        // TEMPORARY
        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)){
            keyPressed = true;
        }
        else{
            keyPressed = false;
        }

        if(keyPressed == true){
            session.EndCurrentTrial();
        }
    }
}
