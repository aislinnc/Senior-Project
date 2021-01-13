using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UXF;

public class CreateDotMotion : MonoBehaviour
{
    public Session session;
    public GameObject stim;
    private List<float> posList;
    private Vector3 pos;
    private int difficultyLevels;
    private int currentLevel;
    public bool lastTrial;

    public void Start(){
        difficultyLevels = session.settings.GetInt("difficultyLevels");
        lastTrial = false;
    }

    public void CreateDotMotionStimulus(){
        posList = session.settings.GetFloatList("stimulusLocation");
        pos =  new Vector3(posList[0], posList[1], posList[2]);
        DifficultyAdjuster();
        session.CurrentTrial.result["difficulty_level"] = currentLevel; 

        StartCoroutine(DotMotionCoroutine());
    }

    IEnumerator DotMotionCoroutine(){
        // Wait for the fixation point to dissapear
        yield return new WaitForSeconds(1f);
        
        // Instantiate dot motion stimulus 
        // HAVE TO ADD DIFFICULTY INTO DOT MOTION
        Instantiate(stim, pos, Quaternion.identity);

        // Display it for .5 seconds
        yield return new WaitForSeconds(session.settings.GetFloat("stimulusTime"));
        
        // Destroy it
        stim.SetActive(false);
    }

    public void DifficultyAdjuster(){
        // Get number of trials
        int numTrials = session.CurrentTrial.numberInBlock;

        // If there aren't more than 3 previous trials, the level remains in the middle
        if(numTrials < 4){
            // If there's an odd number of difficulty levels
            if(difficultyLevels%2 != 0){
                currentLevel = (int) (difficultyLevels/2);
            }
            else{
                currentLevel = difficultyLevels/2;
            }
        }
        // More than 3 trials
        else{
            bool sameLevel = true;
            bool successful = true;
            // Loop through the past 3 trials
            for(int i = 1; i < 4; i++){
                // Check if all three levels were on the same trial 
                int pastTrialLevel = (int) session.GetTrial(numTrials-i).result["difficulty_level"];
                if(pastTrialLevel != currentLevel){
                    sameLevel = false;
                }
                // Check if the three past trials were successful
                string pastTrialSuccess = (string) session.GetTrial(numTrials-i).result["outcome"];
                if (pastTrialSuccess == "fail"){
                    successful = false;
                }
            }

            // If they haven't completed three of the same level, current level remains the same
            if(sameLevel == true){
                // If they were successful in every trial, increase the difficulty
                if(successful == true){
                    if(currentLevel == difficultyLevels){
                        lastTrial = true;
                    }
                    else{
                        currentLevel++;
                    }
                }
                // If they failed at least one, decrease the difficulty
                else{
                    currentLevel--;
                }
            }
        }
    }
}
