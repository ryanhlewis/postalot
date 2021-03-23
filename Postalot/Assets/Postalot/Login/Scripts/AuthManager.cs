using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Appwrite;
using System.Net.Http;
using System.IO;
using System;
using System.Json;
using System.Net;
using System.Linq;
using UnityEngine.UI;

using UnityEngine.SceneManagement;



public class AuthManager : MonoBehaviour
{
    //APPWRITE- The Open Source Firebase!
    [Header("AppWrite")]
    //Custom Client-side AppWrite Implementation
    Client client = new Client();
    //Must call checkName before 
    JsonObject profile;
    Account account;

    //Login variables
    [Header("Login")]
    public InputField emailLoginField;
    public InputField passwordLoginField;
    public Text warningLoginText;
    public Text confirmLoginText;

    //Register variables
    [Header("Register")]
    public InputField usernameRegisterField;
    public InputField emailRegisterField;
    public InputField passwordRegisterField;
    public InputField passwordRegisterVerifyField;
    public Text warningRegisterText;

    //Custom variables from me
    [Header("Custom Vars")]
    public GameObject registerPrompt;
    public GameObject forgotPasswordPrompt;




    void Awake()
    {
    client .SetEndPoint("https://postalot.ga/v1").SetProject("6054edbdaa0f1");
        
    Uri target1 = new Uri("https://postalot.ga");

    if(PlayerPrefs.GetString("cookieStorage1") != null)
    client .cookieJar.SetCookies(target1,PlayerPrefs.GetString("cookieStorage1"));

    //Custom Account.cs implementation for AppWrite. They should really merge my pull request..
    account = new Account(client);

    }


    //Function for the login button
    public void LoginButton()
    {
        //Call the login coroutine passing the email and password
        StartCoroutine(Login(emailLoginField.text, passwordLoginField.text));
    }
    //Function for the register button
    public void RegisterButton()
    {

        //Call the register coroutine passing the email, password, and username
        StartCoroutine(Register(emailRegisterField.text, passwordRegisterField.text, usernameRegisterField.text));
    }


    //Forgot Password Method

    public void ForgotPassword()
    {


     StartCoroutine(ForgotPasswordCatch(emailLoginField.text));


    }




    private IEnumerator ForgotPasswordCatch(string _email)
    {
        //Call the AppWrite auth forgot password
      
      
        var FPTask =  account.CreateRecovery(_email, "postalot.ga"); //Need a redirect to APP url! 
        //Wait until the task completes
        yield return new WaitUntil(predicate: () => FPTask.IsCompleted);


        //In all honesty, I have no clue if this function can error out, but I'll take precautions.

        if (FPTask.Exception != null)
        {
            //If there are errors handle them
            Debug.LogWarning(message: $"Failed to register task with {FPTask.Exception}");

            string message = "Reset failed!";
    
            warningLoginText.text = message;
        }
        else
        {
            
            //User is now logged in
            //Now get the result
            //User = FPTask.Result;
            //Debug.LogFormat("Reset password email sent successfully: {0} ({1})", User.DisplayName, User.Email);
            warningLoginText.text = "";
            confirmLoginText.text = "Email sent!";

            //Remove forgot password button
            forgotPasswordPrompt.SetActive(false);


        }
    }








    private IEnumerator Login(string _email, string _password)
    {
        //Call the Firebase auth signin function passing the email and password
        var LoginTask = account.CreateSession(_email, _password);
        //Wait until the task completes
        yield return new WaitUntil(predicate: () => LoginTask.IsCompleted);

        if (LoginTask.Exception != null)
        {
            //If there are errors handle them
            Debug.LogWarning(message: $"Failed to register task with {LoginTask.Exception}");

            //There's no Exception class in AppWrite .NET yet. Either I have to add one, or they will add one eventually.

            confirmLoginText.text = "";
            warningLoginText.text = "";//message;
        }
        else
        {
            //User is now logged in
            //Now get the result

            //Grab their LOGIN COOKIE!!! COOKIE JAR.
              IEnumerable<string> cookies = LoginTask.Result.Headers.SingleOrDefault(header => header.Key == "Set-Cookie").Value;

              PlayerPrefs.SetString("cookieStorage1", cookies.ToArray()[1].Substring(0,cookies.ToArray()[1].IndexOf(';')));

            Debug.Log(PlayerPrefs.GetString("cookieStorage1"));


            //We've grabbed their cookies, now let's grab their profile to use access a username.

            var getProfile = account.Get();
    
            yield return new WaitUntil(predicate: () => getProfile.IsCompleted);

            Debug.Log(getProfile);

            //Places account data into local JSON Array
            profile = (JsonObject)(JsonObject.Parse(getProfile.Result.Content.ReadAsStringAsync().Result));

            Debug.Log(profile["name"]);


            Debug.LogFormat("User signed in successfully: {0} ({1})", profile["name"], profile["email"]);

            //Get rid of register/login buttons
            forgotPasswordPrompt.SetActive(false);
            registerPrompt.SetActive(false);

            //Probably put some LoadScene, or loading thing right here.



            //Go to game!!!


            SceneManager.LoadScene("Main");


            warningLoginText.text = "";
            confirmLoginText.text = "Logged in";
        }
    }

    private IEnumerator Register(string _email, string _password, string _username)
    {
        if (_username == "")
        {
            //If the username field is blank show a warning
            warningRegisterText.text = "Missing username";
        }
        else if(passwordRegisterField.text != passwordRegisterVerifyField.text)
        {
            //If the password does not match show a warning
            warningRegisterText.text = "Password does not match!";
        }
        else 
        {

            //First, make sure that username aint taken.

           //Must be logged in to access the database?
           // I need a workaround.

           //I've requested the AppWrite devs to make this a feature. Commenting this out for now..

/*
             var DBTask2 = DBreference.Child("username").Child(_username).GetValueAsync();


            yield return new WaitUntil(predicate: () => DBTask2.IsCompleted);

            if (DBTask2.Result.Value != null)
             {
                    Debug.LogWarning(message: $"Failed to register task with {DBTask2.Exception}");
                    warningRegisterText.text = "Username already taken!";
                }
             else
             {
*/
    

            //Database username is now updated
        
            
            //Call the Firebase auth signin function passing the email and password
            var RegisterTask = account.Create(_email, _password, _username);
            //Wait until the task completes
            yield return new WaitUntil(predicate: () => RegisterTask.IsCompleted);

            if (RegisterTask.Exception != null)
            {
                //If there are errors handle them
                Debug.LogWarning(message: $"Failed to register task with {RegisterTask.Exception}");


                //Exceptions in a future release of AppWrite.

                confirmLoginText.text = "";
                warningRegisterText.text = "";//message;
            }
            else
            {
                //User has now been created

                        Login(_email,_password);


                        //Now return to login screen
                        UIManager.instance.LoginScreen();
                        warningRegisterText.text = "";
                    
                
            }
        }
    }
}
