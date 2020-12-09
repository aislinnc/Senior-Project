using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UXF;

public class TargetController : MonoBehaviour
{
    // Dot motion stimulus object
    public GameObject stim;
    private DotMotionController dotMoCont;
    public int moveSpeed = 4;
    public string direction;
    Vector3 targetDir;
    Vector3 normScale = new Vector3 (0.39515f, 0.02757752f, 0.39515f);
    
    void Start(){
        // Make the object invisible
        transform.localScale = new Vector3(0,0,0);   
        
        // Set target starting location to dot stimulus location
        dotMoCont = stim.GetComponent<DotMotionController>();
        transform.position = dotMoCont.pos;

        // TEMPORARY UNTIL I HAVE ACTUAL DOT MOTION STIMULUS 
        int rand = Random.Range(0,1);
        if(rand == 0){
            direction = "left";
            targetDir = new Vector3 (0f, 1f, 1f);
        }
        else{
            direction = "right";
            targetDir = new Vector3 (0f, -1f, -1f);
        }
    }

    void Update()
    {
        // After the dot motion stimulus dissapears the target moves away from it 
        if(stim.activeInHierarchy == false){
            transform.localScale = normScale;
            transform.Translate(targetDir*moveSpeed*Time.deltaTime);
        }
    }
}
