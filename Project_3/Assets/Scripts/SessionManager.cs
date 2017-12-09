using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionManager : MonoBehaviour {
	public static string PlayerName { get; set; }
	public static string GameName { get; set; }
	public static bool IsHost { get; set; }
	public void SetIsHost(bool val) {
		IsHost = val;
	}

	public static Sprite ActiveButton { get; set; }
	public Sprite activeButton;
	public static Sprite InactiveButton { get; set; }
	public Sprite inactiveButton;

	//For debugging
	public string playerName;
	public string gameName;
	public bool isHost;

	void Start() {
		Screen.autorotateToPortraitUpsideDown = false;
		Screen.autorotateToLandscapeLeft = false;
		Screen.autorotateToLandscapeRight = false;
		Screen.orientation = ScreenOrientation.Portrait;

		ActiveButton = activeButton;
		InactiveButton = inactiveButton;

		DontDestroyOnLoad (gameObject);
	}

	void Update() {
		//For debugging
		playerName = PlayerName;
		gameName = GameName;
		isHost = IsHost;
	}
}
