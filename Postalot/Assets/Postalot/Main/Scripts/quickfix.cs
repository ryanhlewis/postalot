using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using UnityEngine.SceneManagement;



public class quickfix : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Login else
        
        if(FirebaseAuth.DefaultInstance.CurrentUser == null)
        SceneManager.LoadScene("Login");


        Screen.fullScreen = false;
            //getWindow().clearFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
