using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UXF;

public class ExperimentGenerator : MonoBehaviour
{
    // Generate experiment session
    public void Generate(Session session){
        session.CreateBlock();    
    }
}
