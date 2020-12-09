using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UXF;

public class DistractorController : MonoBehaviour
{
    // Dot motion stimulus object
    public GameObject stim;
    private DotMotionController dotMoCont;
    // Target object
    public GameObject target;
    private TargetController targCont;
    // Size
    Vector3 normScale = new Vector3 (0.39515f, 0.02757752f, 0.39515f);
    // Movement
    Vector3 distDir;
    int moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        // Make the object invisible
        transform.localScale = new Vector3(0,0,0);

        // Set starting location
        dotMoCont = stim.GetComponent<DotMotionController>();
        transform.position = dotMoCont.pos;

        // TEMPORARY UNTIL I HAVE ACTUAL DOT MOTION STIMULUS
        targCont = target.GetComponent<TargetController>();
        if(targCont.direction == "left"){
            distDir = new Vector3 (0f, -1f, -1f);
        }
        else{
           distDir = new Vector3 (0f, 1f, 1f); 
        }

        // Set movement speed to that of the target
        moveSpeed = targCont.moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // After the dot motion stimulus dissapears the target moves away from it 
        if(stim.activeInHierarchy == false){
            transform.localScale = normScale;
            transform.Translate(distDir*moveSpeed*Time.deltaTime);
        }
    }
}
