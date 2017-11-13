using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationTracker : MonoBehaviour
{

    public Text text;

	private bool startedProperly = false;

    //Latitude longitutde variables
    private float startLatitude;
    private float startLongitude;

    private float latitude;
    private float longitude;

    private float horizontalAccuracy;

    // Use this for initialization
    IEnumerator Start()
    {
        print("LocationTracker started");

        // check if user has location service enabled
		/*
        if (!Input.location.isEnabledByUser)
        {
			startedProperly = true;
            yield break;
        }
        */
		startedProperly = true; // sure

        // Start service before querying location
        Input.location.Start(1.0f, 1.0f);

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            print("Timed out");
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
            yield break;
        }
        else
        {
            startLatitude = Input.location.lastData.latitude;
            startLongitude = Input.location.lastData.longitude;
            horizontalAccuracy = Input.location.lastData.horizontalAccuracy;

            // Access granted and location value could be retrieved
            print("Location: " + startLatitude + " " + startLongitude);
        }
    }

    // Update is called once per frame
    void Update()
    {
		if (!startedProperly) return;
        
		latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;

        // Access granted and location value could be retrieved
        print("Location: " + startLatitude + " " + startLongitude);

        text.text = "" +
            "Location:\n" 
			+ latitude + "\n" 
			+ longitude + "\n" 
			+ "Delta:\n" 
			+ (latitude - startLatitude) + "\n" 
			+ (longitude - startLongitude);
    }
}
