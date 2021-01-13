using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UXF;

public class GetKeyPress : MonoBehaviour
{
    public Session session;
    public GameObject target;
    private TargetController targetController;
    public GameObject distractor;
    private DistractorController distractorController;
    private bool keyPressed;
    
    // FOR USE ONCE DOT MOTION WORKS 
    public GameObject stim;
    public DotStimScript dotStimScript;
    private string combinedDirection;
    private bool success;
    
    public GameObject experiment;
    private CreateDotMotion createDotMotion;
    private int currentLevel;
    private bool lastTrial;

    public void Start(){
        // Get the combined direction of the dot motion stimulus
        stim = GameObject.Find("DotStimulus");
        dotStimScript = stim.GetComponent<DotStimScript>();
        combinedDirection = dotStimScript.combined_direction;

        // Check if this is the last trial
        createDotMotion = experiment.GetComponent<CreateDotMotion>();
        lastTrial = createDotMotion.lastTrial;

        // Get the distractor and targets trackers
        targetController = target.GetComponent<TargetController>();
        distractorController = distractor.GetComponent<DistractorController>();
    }

    // Update is called once per frame
    public void Update()
    {   
        // FOR USE ONCE DOT MOTION WORKS 
        // Doesn't register key presses until stimulus is gone
        if(stim.activeInHierarchy == false){
            // If the left arrow key was pressed 
            if(Input.GetKeyDown(KeyCode.LeftArrow)){
                keyPressed = true;
                // If it was the right key to press
                if(combinedDirection == "Northwest" || combinedDirection == "Southwest"){
                    success = true;
                }
                else{
                    success = false;
                }
            }
            else if(Input.GetKeyDown(KeyCode.RightArrow)){
                keyPressed = true;
                if(combinedDirection == "Northeast" || combinedDirection == "Southeast"){
                    success = true;
                }
                else{
                    success = false;
                }
            }
            // If neither key was pressed
            else{
                keyPressed = false;
            }
        }
        
        // If a key was pressed end the current trial and start a new one 
        if(keyPressed == true){
            // Stop target and distractor controller
            targetController.targetTracker.StopRecording();
            distractorController.distractorTracker.StopRecording();

            // FOR USE ONCE DOT MOTION WORKS 
            if(success == true){
               session.CurrentTrial.result["outcome"] = "success"; 
            }
            else{
                session.CurrentTrial.result["outcome"] = "fail";
            }
            
            if(lastTrial == false){
                // End the current trial
                Block currentBlock = session.CurrentBlock;
                Trial newTrial = currentBlock.CreateTrial();
                session.EndCurrentTrial();

                // Destroy target and distractor at the end of the trail
                target = GameObject.Find("target");
                distractor = GameObject.Find("distractor");
                Destroy(stim);
                Destroy(target);
                Destroy(distractor);

                newTrial.Begin();
            }
            else{
                // End the current trial
                Block currentBlock = session.CurrentBlock;
                Trial newTrial = currentBlock.CreateTrial();
                session.EndCurrentTrial();
                
                // End the session
                session.End();
            }

        }
    }
}
