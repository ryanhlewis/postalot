﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Appwrite;


public class loadContent : MonoBehaviour
{
    //Custom
    public int amountofStuff = 20;
    public GameObject picPrefab;
    public GameObject vidPrefab;
    public GameObject parentContentPrefab;
    public GameObject stopCodonPrefab;

    //Database
   
    Client client = new Client();
    

    // Start is called before the first frame update
    public void Start()
    {
        client .SetEndPoint("https://postalot.ga/v1").SetProject("6054edbdaa0f1");

        //Account and Storage
        Account account = new Account(client);
        Storage storage = new Storage(client);

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

        //Happens once every 20-30 posts / reload

        //Get list of users followed                        Need to redo this for AppWrite.
/*
        var DBTask = DBreference.Child("usersFollowed").Child(auth.CurrentUser.DisplayName).GetValueAsync();
        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);
        if (DBTask.Result.Value == null)
             {
                //They follow nobody! Empty feed!   //Or random feed..?
                Debug.Log("Broken!");
                yield break;
            }
  */      
        //Debug.Log(DBTask.Result.Value);

    //    string newString = (string)DBTask.Result.Value;
        string newString = "testuser1 testuser2";
        string[] usersFollowedArray = newString.Split(' ');
        
        //Debug.Log(usersFollowedArray[0] + usersFollowedArray[2] + usersFollowedArray[1]);




        //Let's load stuffCount elements.
        for(int i = 0;i <= stuffCount; i++){

        string githubString = "https://github.com/ryanhlewis/postalot/blob/master/PostalotData/";

        //I have to think a way of marking images. It has to be user-side, and not tied to the app in case of reinstallation.

        //#1 Database ties content seen to user to not display again != seen
        //#2 Webhost ties content seen in a small text file at root of user directory

        //Both are terrible solutions, and will eventually make INCREDIBLY big data heaps full of useless data.

        //However, JSON databases are quicker than text files..

        //Choose a user..

        string chosenUser = usersFollowedArray[Random.Range(0,usersFollowedArray.Length)];
        Debug.Log(chosenUser);


                                                            //Need to redo this in AppWrite
        //Get num of posts from user randomly picked
        //Again, later.
        /*
        var DBTask1 = DBreference.Child("numOfPosts").Child(chosenUser).GetValueAsync();
        yield return new WaitUntil(predicate: () => DBTask1.IsCompleted);
*/
        //string tempConversion = (string)DBTask1.Result.Value;
        //int numOfPosts = int.Parse(tempConversion);
        //Debug.Log(DBTask1.Result.Value);
        //int numOfPosts = System.Convert.ToInt32(DBTask1.Result.Value);
        int numOfPosts = 2;

        //The RNG goddess line
        //Realized this isn't a FTP Server, and I can't use normal REGEX type commands.   ex: *.jpg
        //A solution to this is to name the files 1-numberofPosts, and this solution only fails
        //if a user decides to delete a post, and all the posts must be renamed in a batch.

        //fetch the number
        int num =  Random.Range(1, numOfPosts); //both inclusive

        //Since it's not a FTP server, I can't exactly predict the file end either.. 6* wont give me 6.jpg
        //This is seriously getting to be a pain.

        //Cool fix: cut off all endings. It doesn't change file type at all.
        //Potential problem: knowing whether to use vidPrefab or picPrefab.

        githubString += chosenUser + "/" + num + "?raw=true";

        //The raw image class is so good that it has a default Red Question mark for stuff it cant access
        //and I have no idea how to get to it, or compare it, after a long time searching.

        //Eric the Mod from Unity claims that the only way to check is to compare width and height.
        //https://forum.unity.com/threads/solved-default-image-using-www-class.16459/
        //This will null out any 8x8 photos anyone wants to post,
        //and if I want to make this "efficient" and compare each pointer to a red question mark..
        //you can see how inefficient that would be.

        //Make everything as an image first..

        GameObject childGameObject = Instantiate(picPrefab, parentContentPrefab.transform);
        
        childGameObject.GetComponent<imagescript>().url = githubString;
        
        //Programming in waits is terrible, I know. For some reason, this code is TOO QUICK. It makes the
        //gameObject and assigns it the URL, but by the time the IF Statement gets checked, the gameObject
        //has not created or called its image/video. 

        //I just wish the creators of the RawImage class would have just made a NULL texture instead of an uncallable question mark sprite.
        while (childGameObject.GetComponent<RawImage>().texture == null)
        {
        yield return null;
        }

        //If image fails, fallback to video..
        if(childGameObject.GetComponent<RawImage>().texture.width == 8 && childGameObject.GetComponent<RawImage>().texture.height == 8) {
        //Debug.Log("no way");
        GameObject.Destroy(childGameObject); //Keep reference!
        childGameObject = Instantiate(vidPrefab, parentContentPrefab.transform);
        childGameObject.GetComponent<UnityEngine.Video.VideoPlayer>().url = githubString;
        }

        //Post has been made, now assign username/pfp, comments, description, etc.

        string profileString = "https://github.com/ryanhlewis/postalot/blob/master/PostalotData/" + chosenUser + "/profile.png?raw=true";

        
        //Unity pitfall: parents are only transform parents??

        Transform parentTransform = childGameObject.transform;
        
        parentTransform.GetChild(2).GetComponent<Text>().text = chosenUser; //Database user call probably.
        
        parentTransform.GetChild(1).GetChild(0).GetComponent<imagescript>().url = profileString;

        parentTransform.GetChild(1).GetChild(0).GetComponent<imagescript>().Start();



        //For a description, comments, etc. I will need to go back to database programming.

        //Debug.Log(FirebaseAuth.DefaultInstance.CurrentUser.DisplayName);




        

        }


        //Here, add a pad, end stop codon
        //Basically, make a thing that once detected, or scrolled on, calls this script again.
        Instantiate(stopCodonPrefab, parentContentPrefab.transform);


        //End coroutine
        yield return null;
        //print("Coroutine ended: " + Time.time + " seconds");
    }



}
