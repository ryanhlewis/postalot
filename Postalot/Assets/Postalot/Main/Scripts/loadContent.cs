using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//I hate using Firebase. Need to switch out.  Hopefully switch to MongoDB.
using Firebase;
using Firebase.Auth;
using Firebase.Database;

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

        string githubString = "https://github.com/ryanhlewis/postalot/blob/master/PostalotData/testuser1/";

        //I have to think a way of marking images. It has to be user-side, and not tied to the app in case of reinstallation.

        //#1 Database ties content seen to user to not display again != seen
        //#2 Webhost ties content seen in a small text file at root of user directory

        //Both are terrible solutions, and will eventually make INCREDIBLY big data heaps full of useless data.

        //However, JSON databases are quicker than text files..

        //Get list of users followed
        //I'll work these issues out soon. Currently, let me see if I can grab and include support for various file types randomly.

        //Get num of posts from user randomly picked
        //Again, later.
        int numOfPosts = 6;

        //The RNG goddess line
        //Realized this isn't a FTP Server, and I can't use normal REGEX type commands.   ex: *.jpg
        //A solution to this is to name the files 1-numberofPosts, and this solution only fails
        //if a user decides to delete a post, and all the posts must be renamed in a batch.

        //fetch the number
        int num =  Random.Range(0, numOfPosts); //both inclusive

        //Since it's not a FTP server, I can't exactly predict the file end either.. 6* wont give me 6.jpg
        //This is seriously getting to be a pain.

        //Cool fix: cut off all endings. It doesn't change file type at all.
        //Potential problem: knowing whether to use vidPrefab or picPrefab.

        githubString += num + "?raw=true";


        GameObject childGameObject = Instantiate(vidPrefab, parentContentPrefab.transform);
        childGameObject.GetComponent<UnityEngine.Video.VideoPlayer>().url = githubString;


        //GameObject childGameObject = Instantiate(picPrefab, parentContentPrefab.transform);
        
        //childGameObject.GetComponent<imagescript>().url = githubString;
        

        }


        //Here, add a pad, end stop codon
        //Basically, make a thing that once detected, or scrolled on, calls this script again.
        Instantiate(stopCodonPrefab, parentContentPrefab.transform);


        //Give one second per vid/image
        yield return new WaitForSeconds(stuffCount);
        //print("Coroutine ended: " + Time.time + " seconds");
    }



}
