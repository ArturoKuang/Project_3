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

	//For debugging
	public string playerName;
	public string gameName;
	public bool isHost;

	void Start() {
		DontDestroyOnLoad (gameObject);
	}

	void Update() {
		//For debugging
		playerName = PlayerName;
		gameName = GameName;
		isHost = IsHost;
	}
}
