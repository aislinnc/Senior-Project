using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UXF;

public class DistractorController : MonoBehaviour
{
    public Session session;
    // Dot motion stimulus object
    public GameObject stim;
    // Target object
    public GameObject target;
    private TargetController targCont;
    // Movement
    private List<float> posList;
    private Vector3 pos;
    private int moveSpeed;
    Vector3 distDir;
    // Size
    Vector3 normScale = new Vector3 (0.39515f, 0.02757752f, 0.39515f);

    // Start is called before the first frame update
    void Start()
    {
        // Make the object invisible
        transform.localScale = new Vector3(0,0,0);

        // Set starting location
        posList = session.settings.GetFloatList("stimulusLocation");
        pos = new Vector3(posList[0], posList[1], posList[2]);
        transform.position = pos;

        // TEMPORARY UNTIL I HAVE ACTUAL DOT MOTION STIMULUS
        targCont = target.GetComponent<TargetController>();
        if(targCont.direction == "left"){
            distDir = new Vector3 (0f, -1f, -1f);
        }
        else{
           distDir = new Vector3 (0f, 1f, 1f); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        // After the dot motion stimulus dissapears the target moves away from it 
        if(stim.activeInHierarchy == false){
            transform.localScale = normScale;
            moveSpeed = session.settings.GetInt("distractorMoveSpeed");
            transform.Translate(distDir*moveSpeed*Time.deltaTime);
        }
    }
}
