using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UXF;

public class DistractorController : MonoBehaviour
{
    public Session distSession;
    public GameObject uxfRig;
    public SessionLogger sessionLogger;
    
    // FOR USE ONCE DOT MOTION WORKS 
    public GameObject dotMotion;
    public DotStimScript dotStimScript;
    private int horDir;
    private int verDir;
    private string combinedDirection;

    // Movement
    public Tracker distractorTracker;
    private int moveSpeed;
    private Vector3 distDir;

    void Start(){
        // Find UXF rig using find game object
        uxfRig = GameObject.Find("UXF_Rig");
        // use get component to get the script called session 
        sessionLogger = uxfRig.GetComponent<SessionLogger>();
        distSession = sessionLogger.session;

        // FOR USE ONCE DOT MOTION WORKS 
        // Get the combined direction of the stimulus dots
        dotMotion = GameObject.Find("DotStimulus");
        dotStimScript = dotMotion.GetComponent<DotStimScript>();
        combinedDirection = dotStimScript.combined_direction;

        // Set the direction and speed the distractor
        if(combinedDirection == "Northeast"){
            distDir = new Vector3(-1f, -1f, 0f);
        }
        else if(combinedDirection == "Southeast"){
            distDir = new Vector3(-1f, 1f, 0f);
        }
        else if(combinedDirection == "Northwest"){
            distDir = new Vector3(1f, -1f, 0f);
        }
        else{
            distDir = new Vector3(1f, 1f, 0f);
        }
        moveSpeed = distSession.settings.GetInt("distractorMoveSpeed");

        // Add a tracker of its position
        distSession.trackedObjects.Add(distractorTracker);
        distractorTracker.StartRecording();
    }

    void Update()
    {
        // Send the distractor in the opposite direction of the target
        transform.Translate(distDir*moveSpeed*Time.deltaTime);
    }
}
