using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lobby : MonoBehaviour {

	public string LobbyName { get; set; }

	private const int maxPlayers = 8;
	private int playerCount;
	public GameObject playerSpots;
	public GameObject lobbyTitle;

	//For waiting animation
	const float animationRate = 0.3f;
	private float animationCounter = 0.0f;
	private int animationFrame = 0;
	private const int numFrames = 4;

	// Use this for initialization
	void OnEnable () {
		if (SessionManager.IsHost) {
			CreateLobby ();
			animationFrame = 0;
			animationCounter = 0;
		} else {
			//Join
		}
	}

	void Update() {
		animationCounter += Time.deltaTime;
		if (animationCounter > animationRate) {
			animationCounter -= animationRate;
			++animationFrame;
			animationFrame %= numFrames;

			string dots = "";
			switch (animationFrame) {
			case 0:
				dots = "";
				break;
			case 1:
				dots = ".";
				break;
			case 2:
				dots = ". .";
				break;
			case 3:
				dots = ". . .";
				break;
			}

			for (int i = playerCount; i < maxPlayers; i++) {
				playerSpots.transform.GetChild (i)
					.gameObject.GetComponent<Text> ().text = dots;
			}
		}
	}
	
	// Update is called once per frame
	public void CreateLobby () {

		//reset player count
		playerCount = 0;

		//Empty all player spots
		for (int i = 0; i < maxPlayers; i++) {
			playerSpots.transform.GetChild (i)
				.gameObject.GetComponent<Text> ().text = "";
		}

		//set lobby name
		lobbyTitle.GetComponentInChildren<Text>().text = SessionManager.GameName;

		//Say you're the host!
		SessionManager.IsHost = true;

		//Add yourself
		AddPlayer (SessionManager.PlayerName);
	}

	private void AddPlayer(string name) {
		playerSpots.transform.GetChild (playerCount)
			.gameObject.GetComponent<Text>().text = name;
		playerCount++;
	}
}
