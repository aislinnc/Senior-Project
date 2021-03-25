using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;
using UXF;

public class LaserCollideChecker : MonoBehaviour
{
    public GameObject experiment;
    public GetKeyPress getKeyPress;
    public CreateDotMotion createDotMotion;
    public Transform controllerTransform;
    public GameObject target;
    public GameObject distractor;

    void Start(){
        // Get experiment object for bool if an object has been entered and if the target/dist are active
        experiment = GameObject.FindGameObjectWithTag("Experiment");
        getKeyPress = experiment.GetComponent<GetKeyPress>();
        createDotMotion = experiment.GetComponent<CreateDotMotion>();
    }

    void Update(){
        // Check if the target and distractor are active
        if(createDotMotion.stimActive == false){
            target = GameObject.FindGameObjectWithTag("Target");
            distractor = GameObject.FindGameObjectWithTag("Distractor");
        }

        // Check if the object has been entered
        if (Physics.Raycast(controllerTransform.position, controllerTransform.forward, out var controllerHit)){
            if (controllerHit.collider.gameObject == target){
                getKeyPress.targetEntered = true;
            }
            else if(controllerHit.collider.gameObject == distractor){
                getKeyPress.distEntered = true;
            }
        }
    }
}
