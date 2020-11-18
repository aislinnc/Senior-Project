using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UXF;

public class FixationController : MonoBehaviour
{
    // Set the fixation point's global position
    public void Start(){
        transform.position = new Vector3(0.5f, 0.5f, 0f);
    }
    
    // Activates the fixation point for 1 second then deactivates it 
    IEnumerator Fixate(){
        Debug.Log("In Fixate coroutine");
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }

    // Starts the Fixate coroutine
    public void StartFixate(){
        StartCoroutine(Fixate());
    }
}
