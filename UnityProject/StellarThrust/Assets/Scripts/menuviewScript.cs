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
    string UrlForAddCoin = "https://block-contentos.herokuapp.com/transact?coins=";
    string UrlForSeeProfile = "https://block-contentos.herokuapp.com/account?totalcoins=";
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
/*
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
        PlayerPrefs.SetInt("collectionStellarthrust",0);
        PlayerPrefs.SetInt("collectiontotalStellarthrust",PlayerPrefs.GetInt("collectiontotalStellarthrust",0) + coins);

            //display or goto url withs coins(int)
        }
    }
    IEnumerator GetRequestseepro(string uri)
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
            //display or goto url with totalcoin(int)
        }
    }
 */
    public void AddCoinBtnFun()
    {
        int coins = PlayerPrefs.GetInt("collectionStellarthrust",0);
        int totalcoin = PlayerPrefs.GetInt("collectiontotalStellarthrust",0);
        PlayerPrefs.SetInt("collectionStellarthrust",0);
        PlayerPrefs.SetInt("collectiontotalStellarthrust",PlayerPrefs.GetInt("collectiontotalStellarthrust",0) + coins);
        Application.OpenURL(UrlForAddCoin + coins.ToString());
        //StartCoroutine(GetRequest(UrlForAddCoin));
    }
    public void SeeProfileBtnFun()
    {
        int totalcoin = PlayerPrefs.GetInt("collectiontotalStellarthrust",0);
        Application.OpenURL(UrlForSeeProfile + totalcoin.ToString());
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
