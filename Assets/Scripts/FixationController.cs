using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UXF;

public class FixationController : MonoBehaviour
{   
    public Session session;

    // Activates the fixation point for 1 second then deactivates it 
    IEnumerator Fixate(){
        yield return new WaitForSeconds(session.settings.GetFloat("fixationTime"));
        gameObject.SetActive(false);
    }

    // Starts the Fixate coroutine
    public void StartFixate(){
        StartCoroutine(Fixate());
    }
}
