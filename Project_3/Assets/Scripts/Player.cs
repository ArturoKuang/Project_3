using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

[System.Serializable]
public class PlayerData
{
    public string myName;
    public GameObject myObject;

    public PlayerData(string n, GameObject g)
    {
        myName = n;
        myObject = g;
    }

    public PlayerData()
    {

    }
}

public class Player : NetworkBehaviour {

    [SerializeField]
    private GameObject myCanvas;

    [SyncVar]
    public string myName = "PLAYER";

    [SerializeField]
    Text nameText;

    [SerializeField]
    private float speed = 2f;

    [SerializeField]
    RectTransform myTransform;

    [SerializeField]
    private GameManager gameManager;

    PlayerData myData;

    void Start()
    {
        myCanvas = GameObject.FindGameObjectWithTag("PlayerCanvas");
        gameManager = FindObjectOfType<GameManager>();

        if (isLocalPlayer)
        {
            //CmdPlayerHasJoined(myData);
            GetComponent<Image>().color = Color.blue;
            nameText.color = Color.green;
        }
        else
            nameText.color = Color.red;

        nameText.text = myName;

        transform.SetParent(myCanvas.transform);
    }

    //[Command]
    //public void CmdPlayerHasJoined(PlayerData myData)
    //{
    //    RpcPlayerHasJoined(myData);
    //    gameManager.players.Add(this);
    //    gameManager.playersName.Add(myName);
    //}

    //[ClientRpc]
    //public void RpcPlayerHasJoined(PlayerData myDataa)
    //{
    //    myName = myDataa.myName;
    //    nameText.text = myName;
    //    gameManager.players.Add(this);
    //    gameManager.playersName.Add(myName);
    //}

    void Update()
    {
        if (!isLocalPlayer)
            return;

        Vector2 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        myTransform.Translate(move * speed * Time.deltaTime);
    }

}
