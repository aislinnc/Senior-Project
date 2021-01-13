using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UXF;

public class CreateTargetAndDistractor : MonoBehaviour
{
    public Session session;
    public GameObject stim;
    public GameObject targetPrefab;
    public GameObject distractorPrefab;
    private List<float> posList;
    private Vector3 pos;
    private bool instantiated; //To make sure prefabs are only instantiated once 

    void Start()
    {
        // Set target starting location to dot stimulus location
        posList = session.settings.GetFloatList("stimulusLocation");
        pos =  new Vector3(posList[0], posList[1], posList[2]);
        instantiated = false;
        stim = GameObject.Find("DotStimulus");
    }

    void Update()
    {
        if(stim.activeInHierarchy == false && instantiated == false){
            Instantiate(targetPrefab, pos, Quaternion.identity);
            Instantiate(distractorPrefab, pos, Quaternion.identity);
            instantiated = true;
        }
    }
}
