using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UXF;

public class DotMotionController : MonoBehaviour
{
    public Session session;
    // Stimulus position and size
    private List<float> posList;
    private Vector3 pos;
    // Size
    Vector3 normScale = new Vector3 (1f, 0.0456f, 1f);

    // Starts the DotMotion coroutine
    public void StartDotMotion(){
        StartCoroutine(DotMotion());
    }

    // Activates the dot motion stimulus for .5 seconds then deactivates it 
    IEnumerator DotMotion(){   
        // Set the objects position
        posList = session.settings.GetFloatList("stimulusLocation");
        pos = new Vector3(posList[0], posList[1], posList[2]);
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
