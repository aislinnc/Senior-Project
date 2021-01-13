using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UXF;

public class TargetController : MonoBehaviour
{
    public Session targetSession;
    public GameObject uxfRig;
    public SessionLogger sessionLogger;
    
    // FOR USE ONCE DOT MOTION WORKS 
    public GameObject dotMotion;
    public DotStimScript dotStimScript;
    private string combinedDirection;
    
    // Movement
    public Tracker targetTracker;
    private int moveSpeed;
    public Vector3 targetDir;

    void Start(){
        // Find UXF rig using find game object
        uxfRig = GameObject.Find("UXF_Rig");
        // use get component to get a reference to the session 
        sessionLogger = uxfRig.GetComponent<SessionLogger>();
        targetSession = sessionLogger.session;

        // FOR USE ONCE DOT MOTION WORKS 
        // Get the horizontal and vertical direction of the stimulus dots
        dotMotion = GameObject.Find("DotStimulus");
        dotStimScript = dotMotion.GetComponent<DotStimScript>();
        combinedDirection = dotStimScript.combined_direction;
        targetSession.CurrentTrial.result["target_direction"] = combinedDirection; 

        // Set the direction and speed the target
        if(combinedDirection == "Northeast"){
            targetDir = new Vector3(1f, 1f, 0f);
        }
        else if(combinedDirection == "Southeast"){
            targetDir = new Vector3(1f, -1f, 0f);
        }
        else if(combinedDirection == "Northwest"){
            targetDir = new Vector3(-1f, 1f, 0f);
        }
        else{
            targetDir = new Vector3(-1f, -1f, 0f);
        }
        moveSpeed = targetSession.settings.GetInt("targetMoveSpeed");

        // Add a tracker of its position
        targetSession.trackedObjects.Add(targetTracker);
        targetTracker.StartRecording();
    }

    void Update()
    {
        // Target moves in the direction of the stimulus dots 
        transform.Translate(targetDir*moveSpeed*Time.deltaTime);
    }
}
