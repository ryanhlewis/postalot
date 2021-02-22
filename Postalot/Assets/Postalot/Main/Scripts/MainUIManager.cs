using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUIManager : MonoBehaviour
{

    //Screen object variables
    public GameObject homeUI;
    public GameObject profileUI;


    //Functions to change the main UI
    public void HomeScreen() 
    {
        homeUI.SetActive(true);
        profileUI.SetActive(false);
    }
    public void ProfileScreen() 
    {
        homeUI.SetActive(false);
        profileUI.SetActive(true);
    }
    
}
