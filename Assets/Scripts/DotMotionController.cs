using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UXF;

public class DotMotionController : MonoBehaviour
{
    static Vector3 lowerLeft = new Vector3 (0.25f, 0.25f, 0f);
    static Vector3 upperLeft = new Vector3 (0.25f, 0.75f, 0f);
    static Vector3 lowerRight = new Vector3 (0.75f, 0.75f, 0f);
    static Vector3 upperRight = new Vector3 (0.75f, 0.25f, 0f);
    static Vector3[] positions = {lowerLeft, upperLeft, lowerRight, upperRight};

    public Vector3 position;

    public void ChoosePosition(){
        int rand = Random.Range(0,3);
        position = positions[rand];
    }

    // Activates the dot motion stimulus for .5 seconds then deactivates it 
    IEnumerator DotMotion(){        
        // Wait for the fixation point to dissapear
        yield return new WaitForSeconds(1f);
        
        // Activate the stimulus and set its location
        gameObject.SetActive(true);
        gameObject.transform.position = position;

        // Display it for .5 seconds
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }

    // Starts the DotMotion coroutine
    public void StartDotMotion(){
        // Detirmine position of stimulus
        ChoosePosition();
        StartCoroutine(DotMotion());
    }
}
