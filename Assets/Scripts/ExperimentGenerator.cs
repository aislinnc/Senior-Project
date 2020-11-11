using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UXF;

public class ExperimentGenerator : MonoBehaviour
{
    // Generate experiment session
    public void Generate(Session session){
        Debug.Log("Experiment generator is working!");
        int numTrials = 10; 
        session.CreateBlock(numTrials);    
    }
}
