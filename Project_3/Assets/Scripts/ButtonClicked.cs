using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClicked : MonoBehaviour {

	//For change menu
	public GameObject thisMenu;
	public GameObject nextMenu;

	public void ChangeMenu() {
		thisMenu.SetActive (false);
		nextMenu.SetActive (true);
	}
}
