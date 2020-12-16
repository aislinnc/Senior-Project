using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UXF;

public class FixationController : MonoBehaviour
{   
    public Session session;
    private float fixationTime;

    // Activates the fixation point for 1 second then deactivates it 
    IEnumerator Fixate(){
        Debug.Log("In Fixate coroutine");
        yield return new WaitForSeconds(fixationTime);
        gameObject.SetActive(false);
    }

    // Starts the Fixate coroutine
    public void StartFixate(){
        fixationTime = session.settings.GetFloat("fixationTime");
        StartCoroutine(Fixate());
    }
}
