using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{

    //Barebones Credit : https://drive.google.com/file/d/0B__1zp7jwQOKVVBlU0xTSV9zN3M/view

    //I have adapted the script to output to RawImage, as well as incorporate Front Camera, take video, pics, etc. 

    static WebCamTexture cam;
    public WebCamDevice[] devices;

    void Start() {
        //Unity suggests this is laggy to call everytime, and that I should instead cache the values.
        devices = WebCamTexture.devices;

        cam = new WebCamTexture();
    }



    public void StartCamera(int cameraNum)
    {

        //Funny enough, this is flipped on its side on a RawImage.
        cam.deviceName = devices[cameraNum].name;


        GetComponent<RawImage>().texture = cam;

        if (!cam.isPlaying)
            cam.Play();

        

    }

}