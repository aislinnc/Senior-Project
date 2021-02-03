﻿using System.Collections;
  using System.Collections.Generic;
using UnityEngine;
using UXF;

public class CreateDotMotion : MonoBehaviour
{
    public Session session;
    public GameObject stim;
    public GameObject instStim;
    public DotStimScript dotStimScript;
    private List<float> posList;
    private Vector3 pos;
    public string combined_direction;
    public bool stimActive;
    public GameObject experiment;
    public GetKeyPress getKeyPress;
    private int level;

    public void Start(){
        stimActive = true;
    }
    
    public void CreateDotMotionStimulus(){
        // Set the location of the stimulus
        posList = session.settings.GetFloatList("stimulusLocation");
        pos =  new Vector3(posList[0], posList[1], posList[2]);

        // Check if it's the first trial 
        int numTrials = session.CurrentTrial.numberInBlock;
        if(numTrials < 2){
            level = 1;
        }
        else{
            experiment = GameObject.FindGameObjectWithTag("Experiment");
            getKeyPress = experiment.GetComponent<GetKeyPress>();
            level = getKeyPress.nextLevel;
        }
        session.CurrentTrial.result["difficulty_level"] = level;

        StartCoroutine(DotMotionCoroutine());
    }

    IEnumerator DotMotionCoroutine(){
        // Wait for the fixation point to dissapear
        yield return new WaitForSeconds(session.settings.GetFloat("fixationTime"));
        
        // Instantiate dot motion stimulus
        // HAVE TO ADD DIFFICULTY INTO DOT MOTION
        instStim = Instantiate(stim, pos, Quaternion.identity);
        instStim.transform.Rotate(-90f, 0f, 0f);
        instStim.SetActive(true);
        dotStimScript = instStim.GetComponent<DotStimScript>();
        combined_direction = dotStimScript.combined_direction;

        // Display it for .5 seconds
        yield return new WaitForSeconds(session.settings.GetFloat("stimulusTime"));
        
        // Destroy it
        Destroy(instStim);
        //instStim.SetActive(false);
        stimActive = false;
    }
}