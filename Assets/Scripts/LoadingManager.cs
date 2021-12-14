using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Photon.Pun;

public class LoadingManager : MonoBehaviour
{
    // Variables
    [Header("Static Instance")]
    public static LoadingManager instance;

    [Header("Loading Circle")]
    public RectTransform circleImg;
    public float rotateSpeed = -200f;

    [Header("Loading Texts")]
    public string[] loadingTexts;
    public TextMeshProUGUI loadingTxtDisplay;

    [Header("Background Image")]
    public Animator backgroundAnimator;
    public enum backgroundAnimType { BottomRight, BottomLeft, UpperRight, Center}
    public backgroundAnimType backgroundAnim;


    void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowLoadingTexts());

        switch (backgroundAnim)
        {
            case backgroundAnimType.BottomLeft:
                backgroundAnimator.SetInteger("BackgroundAnimation", 1);
                break;
            case backgroundAnimType.BottomRight:
                backgroundAnimator.SetInteger("BackgroundAnimation", 2);
                break;
            case backgroundAnimType.UpperRight:
                backgroundAnimator.SetInteger("BackgroundAnimation", 3);
                break;
            case backgroundAnimType.Center:
                backgroundAnimator.SetInteger("BackgroundAnimation", 4);
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        circleImg.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);

        if (!PhotonNetwork.IsConnected)
            LaunchManager.instance.LoadSettings();
    }

    public IEnumerator ShowLoadingTexts()
    {
        for(int i = 0; i < loadingTexts.Length; i++)
        {
            loadingTxtDisplay.text = loadingTexts[i];
            yield return new WaitForSeconds(3f);
        }
        Debug.Log("Loading Game");
        StartCoroutine(LoadScene("Player Lobby"));

    }

    public IEnumerator LoadScene(string newScene)
    {
        yield return new WaitForSeconds(5f);
        PhotonNetwork.JoinLobby();
        PhotonNetwork.LoadLevel(newScene);
    }
}
