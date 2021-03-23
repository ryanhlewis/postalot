using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class quickfix : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Fix jitter
        
        //Vsync is terrible!
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 1000;


        //Login else
        
        //if(profile == null)
        //SceneManager.LoadScene("Login");


        Screen.fullScreen = false;
            //getWindow().clearFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
