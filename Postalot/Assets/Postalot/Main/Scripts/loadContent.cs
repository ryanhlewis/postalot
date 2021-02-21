using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadContent : MonoBehaviour
{
    public int amountofStuff = 20;
    public GameObject picPrefab;
    public GameObject vidPrefab;
    public GameObject parentContentPrefab;
    public GameObject stopCodonPrefab;

    // Start is called before the first frame update
    public void Start()
    {

        //Script is called once every so often.

        //Make new imageRaw, vidRaw, objects into Content from github.
        //Extend length of Content to fit.

        //Extend length of canvas to fit
        parentContentPrefab.GetComponent<RectTransform>().sizeDelta += new Vector2(0,-650*amountofStuff);

        //Coroutine.. Async Command to load content..
        StartCoroutine(loadStuff(amountofStuff));

        
    }


    private IEnumerator loadStuff(int stuffCount)
    {

        //Let's load stuffCount elements.
        for(int i = 0;i <= stuffCount; i++){

        string githubString = "https://github.com/ryanhlewis/postalot/blob/master/PostalotData/testuser1/dogepicture.jpg?raw=true";


        GameObject childGameObject = Instantiate(picPrefab, parentContentPrefab.transform);
        
        childGameObject.GetComponent<imagescript>().url = githubString;
        
        //I might need names, probably not.
        //childGameObject.name = "InstantiateChild";


        //Extend length of canvas to fit
        //parentContentPrefab.GetComponent<RectTransform>().sizeDelta = new Vector2(0,-1*stuffCount);
        //rt.sizeDelta = new Vector2(100, 100);
        


        }

        //Extend length of canvas to fit
        //parentContentPrefab.GetComponent<RectTransform>().sizeDelta = new Vector2(0,-650*amountofStuff);

        //Here, add a pad, end stop codon
        //Basically, make a thing that once detected, or scrolled on, calls this script again.
        Instantiate(stopCodonPrefab, parentContentPrefab.transform);


        //Give one second per vid/image
        yield return new WaitForSeconds(stuffCount);
        //print("Coroutine ended: " + Time.time + " seconds");
    }



}
