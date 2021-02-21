using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class imagescript : MonoBehaviour
{

public string url;

RawImage m_RawImage;
Texture2D m_Texture;



void Start(){    
    
    m_RawImage = GetComponent<RawImage>();

    StartCoroutine(DownloadImage(url));

}

IEnumerator DownloadImage(string MediaUrl)
{   
    UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
    yield return request.SendWebRequest();
    if(request.isNetworkError || request.isHttpError) 
        Debug.Log(request.error);
    else
        m_RawImage.texture = ((DownloadHandlerTexture) request.downloadHandler).texture;
} 

}
