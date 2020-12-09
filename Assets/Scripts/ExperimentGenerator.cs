using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UXF;

public class ExperimentGenerator : MonoBehaviour
{
    // Generate experiment session
    public void Generate(Session session){
        //session.CreateBlock();   
        
        //session.CurrentBlock.CreateTrial(); //This creates an error when trying to select participant
        //UXF.Block currentBlock = session.CurrentBlock; //Also creates problems when trying to select participant 
        //session.BeginNextTrial(); //Says there's no next trial
        //UXF.Block.CreateTrial(); //says an object ref is needed but I haven't been able to access the current block

        // This is the only way I could get it to operate, can I just keep adding trials on after this?
        int trialNum = 5;
        session.CreateBlock(trialNum);
        session.BeginNextTrial();
    }
}
