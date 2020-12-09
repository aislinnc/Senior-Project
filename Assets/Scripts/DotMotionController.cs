using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UXF;

public class DotMotionController : MonoBehaviour
{
    // Set positions for the stimulus
    static Vector3 lowerLeft = new Vector3 (0f, 2.5f, 2.5f);
    static Vector3 upperLeft = new Vector3 (0f, 7.5f, 2.5f);
    static Vector3 lowerRight = new Vector3 (0f, -2.5f, 2.5f);
    static Vector3 upperRight = new Vector3 (0f, -2.5f, 7.5f);
    static Vector3[] positions = {lowerLeft, upperLeft, lowerRight, upperRight};
    public Vector3 pos;
    Vector3 normScale = new Vector3 (1f, 0.0456f, 1f);

    // Starts the DotMotion coroutine
    public void StartDotMotion(){
        // Detirmine position of stimulus
        ChoosePosition();
        StartCoroutine(DotMotion());
    }

    // Randomly chooses location of dot motion stimulus
    public void ChoosePosition(){
        int rand = Random.Range(0,3);
        pos = positions[rand];
    }

    // Activates the dot motion stimulus for .5 seconds then deactivates it 
    IEnumerator DotMotion(){   
        // Set the objects position
        transform.position = pos;

        // Make the object invisible
        transform.localScale = new Vector3(0,0,0);   

        // Wait for the fixation point to dissapear
        yield return new WaitForSeconds(1f);
        
        // Activate the stimulus and set its location
        transform.localScale = normScale;

        // Display it for .5 seconds
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}
