using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

//Original Script taken from Chamuth
//https://github.com/Chamuth/unity-webcam/blob/master/MobileCam.cs

public class CameraScript : MonoBehaviour {

	//private bool camAvailable;
	private WebCamTexture cameraTexture;
	private Texture defaultBackground;

	public RawImage background;
	public AspectRatioFitter fit;
	//public bool frontFacing;

    private WebCamDevice[] webcamReference;
	private int webCamNum = 0;

	// Use this for initialization
	void Start () {
		defaultBackground = background.texture;
		WebCamDevice[] devices = WebCamTexture.devices;

        webcamReference = devices;

		if (devices.Length == 0)
			return;


		cameraTexture = new WebCamTexture(webcamReference[0].name, Screen.width, Screen.height);
		

		if (cameraTexture == null)
			return;

		cameraTexture.Play (); // Start the camera
		background.texture = cameraTexture; // Set the texture

		//camAvailable = true; // Set the camAvailable for future purposes.


        //Doesn't need to be in Update- 

        //My target aspect is 1280 by 720 anyway.
        float ratio = (float)cameraTexture.height / cameraTexture.width;
		fit.aspectRatio = ratio; // Set the aspect ratio

		float scaleY = cameraTexture.videoVerticallyMirrored ? -1f : 1f; // Find if the camera is mirrored or not
		background.rectTransform.localScale = new Vector3(1f, scaleY, 1f); // Swap the mirrored camera

		int orient = -cameraTexture.videoRotationAngle - 180;
		background.rectTransform.localEulerAngles = new Vector3(0,0, orient);

	}

    public void ShowCamera() {

        webCamNum++;

        if(webCamNum == webcamReference.Length)
        webCamNum = 0;
        Debug.Log(webCamNum);

        
        cameraTexture.Stop();


        
        cameraTexture = new WebCamTexture(webcamReference[webCamNum].name, Screen.width, Screen.height);

        if(cameraTexture == null) {
            ShowCamera();
            return;
        }


        cameraTexture.Play (); // Start the camera
		background.texture = cameraTexture;

        
        
        //My target aspect is 1280 by 720 anyway.
        float ratio = (float)cameraTexture.height / cameraTexture.width;
		fit.aspectRatio = ratio; // Set the aspect ratio

		float scaleY = cameraTexture.videoVerticallyMirrored ? -1f : 1f; // Find if the camera is mirrored or not
		background.rectTransform.localScale = new Vector3(1f, scaleY, 1f); // Swap the mirrored camera

		int orient = -cameraTexture.videoRotationAngle - 90;
		background.rectTransform.localEulerAngles = new Vector3(0,0, orient);

        background.rectTransform.sizeDelta = new Vector2(720, 1280);


        //Debug.Log(webcamReference[webCamNum].name);

    }


    IEnumerator TakePhoto()  
    {

     yield return new WaitForEndOfFrame(); 


        Texture2D photo = new Texture2D(cameraTexture.width, cameraTexture.height);
        photo.SetPixels(cameraTexture.GetPixels());
        photo.Apply();

        byte[] bytes = photo.EncodeToPNG();

        File.WriteAllBytes("Assets/" + "photo.png", bytes);
    }

	

}