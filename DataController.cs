using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

public class DataController : MonoBehaviour {
    string URL = "https://quickdrawfiles.appspot.com/drawing/dog?isAnimated=false&format=json&key=";
    string key = "AIzaSyCLxdiMV5-46xuFWFbdDhVoJi7DMwe-H9Q";
    string JsonData;
    private void Start()
    {

        StartCoroutine(GetText());

    }
    IEnumerator GetText()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL + key);
      yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {

            Debug.Log(www.downloadHandler.data);      
            
           

             
           
        }          
    }








}
