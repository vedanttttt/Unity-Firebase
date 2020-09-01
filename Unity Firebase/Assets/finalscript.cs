using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class finalscript : MonoBehaviour
{
    DatabaseReference reference;
    public UnityEngine.UI.Text text;
    public InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        // Set up the Editor before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://fir-database-a453e.firebaseio.com/");

        // Get the root reference location of the database.
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SaveData()
    {
        

    }
    public void LoadData()
    {
        FirebaseDatabase.DefaultInstance.GetReference("latitude").ValueChanged += HandleValueChanged;
    }
    public void LoodData()
    {
        FirebaseDatabase.DefaultInstance.GetReference("longitude").ValueChanged += HandleValueChanged;
    }
    
    public void LuodData()
    {
        FirebaseDatabase.DefaultInstance.GetReference("DHT11").Child("Temperature").ValueChanged += HandleValueChanged;
    }
   
    
    public void LuudData()
    {
        FirebaseDatabase.DefaultInstance.GetReference("DHT11").Child("Humidity").ValueChanged += HandleValueChanged;
    }

    

    private void HandleValueChanged(object sender, ValueChangedEventArgs e)
    {
        if (e.Snapshot.Exists)
        {
            text.text = e.Snapshot
                  .GetValue(true) // wait for the result of asynchronous operation
                  .ToString();
        }
        
       else if (e.Snapshot.Child("Humidity").Exists)
        {
            text.text = e.Snapshot.Child("Humidity")
                  .GetValue(true) // wait for the result of asynchronous operation
                  .ToString();
        }
        
        
        else if (e.Snapshot.Child("Temperature").Exists)
        {
            text.text = e.Snapshot.Child("Temperature")
                  .GetValue(true) // wait for the result of asynchronous operation
                  .ToString();
        }
        
        
        else
        {
            //data not exist to firebase
        }

    }
}
