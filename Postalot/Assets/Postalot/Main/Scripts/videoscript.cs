using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.Video;

public class videoscript : MonoBehaviour
{

//public string url;

RawImage m_RawImage;
Texture2D m_Texture;
VideoPlayer videoPlayer;



void Start(){    
    
    m_RawImage = GetComponent<RawImage>();
    videoPlayer = GetComponent<VideoPlayer>();

    //m_RawImage.texture = videoPlayer.texture;

}

void Update(){

    //Constantly update the video texture

    m_RawImage.texture = videoPlayer.texture;


    //Function to ensure video pauses plays off camera and on


        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.transform.position.z);
        Debug.Log("screenCenter "+screenCenter);
 
        Vector3 screenHeight = new Vector3(Screen.width / 2, Screen.height, Camera.main.transform.position.z);
        Debug.Log("screenHeight " + screenHeight);
 
        Vector3 screenWidth = new Vector3(Screen.width, Screen.height/2, Camera.main.transform.position.z);
        Debug.Log("screenWidth " + screenWidth);
 
        Vector3 goscreen = Camera.main.WorldToScreenPoint(transform.position);
        Debug.Log("GoPos " + goscreen);
 
        float distX = Vector3.Distance(new Vector3(Screen.width / 2, 0f, 0f), new Vector3(goscreen.x, 0f,0f));
        Debug.Log("distX " + distX);
 
        float distY = Vector3.Distance(new Vector3(0f, Screen.height / 2, 0f), new Vector3(0f, goscreen.y, 0f));
        Debug.Log("distY " + distY);
 
        if(distX > Screen.width / 2 || distY > Screen.height / 2)
        {
            videoPlayer.Pause();
        }
        else
            videoPlayer.Play();



}


}
