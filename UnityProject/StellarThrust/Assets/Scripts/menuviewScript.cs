using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class menuviewScript : MonoBehaviour
{
    public Text totalcolltxt;
    public GameObject PlayBtn;
    public GameObject quitBtn;
    public GameObject AddCoinBtn;
    public GameObject SeeProfileBtn;
    string UrlForAddCoin = "";
    string UrlForSeeProfile = "";
    int cvalue;
    // Start is called before the first frame update
    void Start()
    {
        cvalue = PlayerPrefs.GetInt("collectionStellarthrust",0);
        totalcolltxt.text = "Total collection : " + cvalue.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GetRequest(string uri)
    {
        UnityWebRequest uwr = UnityWebRequest.Get(uri);
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);
            //display or goto url
        }
    }

    public void AddCoinBtnFun()
    {
        PlayerPrefs.SetInt("collectionStellarthrust",0);
        StartCoroutine(GetRequest(UrlForAddCoin));
    }
    public void SeeProfileBtnFun()
    {
        StartCoroutine(GetRequest(UrlForSeeProfile));
    }
    public void QuitFunnn()
    {
        Application.Quit();
    }
    public void PlayFun()
    {
        SceneManager.LoadScene("GamePlayScene");
    }
}
