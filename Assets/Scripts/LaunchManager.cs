using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class LaunchManager : MonoBehaviourPunCallbacks
{
    public static LaunchManager instance;
    //Variables
    [SerializeField]
    string username;
    [SerializeField]
    bool clearPrefs;

    #region Unity Methods
    void Awake()
    {
        if (clearPrefs)
            DeletePlayerPrefs();

        username = "username";
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("playerName"))
        {
            PhotonNetwork.NickName = SystemInfo.deviceModel + "__" + SystemInfo.deviceName;
            username = PhotonNetwork.NickName;
        }
        else
        {
            username = PlayerPrefs.GetString("playerName");
        }

        LoadSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
    #endregion

    #region Public Methods

    public void LoadSettings()
    {
        if (PlayerPrefs.HasKey("playerName"))
        {
            PhotonNetwork.NickName = PlayerPrefs.GetString("playerName");
            ConnectToPhotonServers();
            PhotonNetwork.LoadLevel(1);
        }
    }

    public void ConnectToPhotonServers()
    {
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public void inputName(string playerName)
    {
        if (!string.IsNullOrEmpty(playerName))
        {
            //return;
            username = playerName;
        }
        //username = playerName;
    }

    public void setPlayerName()
    {
        PlayerPrefs.SetString("playerName", username);
        PlayerPrefs.SetInt("playerRank", 1);
        PhotonNetwork.NickName = username;
        ConnectToPhotonServers();
        PhotonNetwork.LoadLevel(1);
    }
    #endregion

    #region PUN Callbacks
    public override void  OnConnected()
    {
        Debug.Log($"{PhotonNetwork.NickName} is connected to PHOTON SERVER");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log($"{PhotonNetwork.NickName} is connected to MASTER PHOTON SERVER");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        base.OnDisconnected(cause);
        Debug.Log($"{PhotonNetwork.NickName} is disconnected sekof {cause}");
    }


    #endregion
}
