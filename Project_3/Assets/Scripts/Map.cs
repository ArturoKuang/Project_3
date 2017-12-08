using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour {

	public GameObject map;
	public GameObject player;

	public GameObject lat;
	public GameObject lon;

	//About half a mile
	private const double halfMile = 0.00724637681 / 4.0f;

	//Latitude longitutde variables
	private float startLatitude;
	private float startLongitude;

	private float latitude;
	private float longitude;

	private float mapWidth;
	private float mapHeight;

	private float horizontalAccuracy;

	// Use this for initialization
	void Start () {
		
	}

	void OnEnable() {
		print ("ON ENABLE");

		StartCoroutine(OnEnableAction ());
	}

	IEnumerator OnEnableAction () {

		print ("ON ENABLE");

		//Place player
		player.transform.position = map.transform.position;

		//get map width/heigth
		RectTransform rt = map.GetComponent<RectTransform>();
		mapWidth = rt.rect.width * rt.localScale.x;
		mapHeight = rt.rect.height * rt.localScale.y;

		/*
		 * 	Start getting GPS
		 * 
		 * * * * */

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
	void Update () {

		//Get new coordinates
		latitude = Input.location.lastData.latitude;
		longitude = Input.location.lastData.longitude;	

		Vector3 position = player.transform.position;
		Vector3 mapPosition = map.transform.position;

		//Get unity coordinates
		double deltaLatitude = latitude - startLatitude;
		double localLatitude = deltaLatitude / halfMile;
		lat.GetComponent<Text>().text = localLatitude.ToString ();

		position.x = (float)(mapPosition.x + (localLatitude * mapWidth));

		double deltaLongitude = longitude - startLongitude;
		double localLongitude = deltaLongitude / halfMile;
		lon.GetComponent<Text>().text = localLongitude.ToString ();

		position.y = (float)(mapPosition.y + (localLongitude * mapHeight));

		player.transform.position = position;
	}
}
