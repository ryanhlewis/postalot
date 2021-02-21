using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopCodonScript : MonoBehaviour
{
    
   
   // called when the cube hits the floor
    void OnBecameVisible()
    {
        //Pause Camera, show loading button..


         //I've been spotted!
        Camera.main.GetComponent<loadContent>().Start();
        //Run it back.
        
        //Suicide. Come back in the next iteration.
        Destroy(gameObject);

    }


}
