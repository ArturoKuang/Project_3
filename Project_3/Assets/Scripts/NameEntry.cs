using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class NameEntry : MonoBehaviour {

	private Text entry;
	public enum StoreEntry
	{
		None,
		PlayerName,
		GameName
	} 
	public StoreEntry storeEntry;

	public Button[] buttons;

	// Use this for initialization
	void Start() { OnEnable(); }
	void OnEnable () {
		entry = transform.Find("Text").GetComponent<Text> ();
		NameEntered ();
	}

	public void NameEntered() {
		
		//Disable buttons if name doesn't exist!
		bool entryIsEmpty = (entry.text == "");
		foreach (Button b in buttons) {
			b.enabled = !entryIsEmpty;
			b.GetComponent<Image> ().sprite = entryIsEmpty ? 
				SessionManager.InactiveButton : 
				SessionManager.ActiveButton;
		}

		switch(storeEntry) {
		case StoreEntry.PlayerName:
			SessionManager.PlayerName = entry.text;
			break;
		case StoreEntry.GameName:
			SessionManager.GameName = entry.text;
			break;
		}
	}
}
