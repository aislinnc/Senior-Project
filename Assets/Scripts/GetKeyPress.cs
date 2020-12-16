using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UXF;

public class GetKeyPress : MonoBehaviour
{
    public Session session;
    private bool keyPressed;

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

        // If a key was pressed end the current trial and start a new one 
        if(keyPressed == true){
            Block currentBlock = session.CurrentBlock;
            Trial newTrial = currentBlock.CreateTrial();
            session.EndCurrentTrial();
            newTrial.Begin();
        }
    }
}
