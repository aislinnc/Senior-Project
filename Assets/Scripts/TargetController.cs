using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UXF;

public class TargetController : MonoBehaviour
{
    public Session session;
    // Dot motion stimulus object
    public GameObject stim;
    // Target movement
    private List<float> posList;
    private Vector3 pos;
    private int moveSpeed;
    public string direction;
    Vector3 targetDir;
    // Size
    Vector3 normScale = new Vector3 (0.39515f, 0.02757752f, 0.39515f);
    // Camera
    public Camera cam;
    
    void Start(){
        // Make the object invisible
        transform.localScale = new Vector3(0,0,0);   
        
        // Set target starting location to dot stimulus location
        posList = session.settings.GetFloatList("stimulusLocation");
        pos =  new Vector3(posList[0], posList[1], posList[2]);
        transform.position = pos;

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
            moveSpeed = session.settings.GetInt("targetMoveSpeed");
            transform.Translate(targetDir*moveSpeed*Time.deltaTime);

            // Translate position to viewport position
            Vector3 viewPos = cam.WorldToViewportPoint(transform.position);
            if(viewPos.x > 1 || viewPos.x < 0 || viewPos.y > 1 || viewPos.y < 0){
                gameObject.SetActive(false);
            }
        }
    }
}
