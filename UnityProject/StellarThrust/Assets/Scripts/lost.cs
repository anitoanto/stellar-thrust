using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class lost : MonoBehaviour
{
    public GameObject revivebtn;
    public GameObject restartbtn;
    public GameObject quitbtn;
    string UrlForRevive = "";
    
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("collectionStellarthrust",0) < 50){
            PlayerPrefs.SetInt("collectionStellarthrust",0);
        }
        else{
            PlayerPrefs.SetInt("collectionStellarthrust",PlayerPrefs.GetInt("collectionStellarthrust",0) - 50);
        }
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
            //display or goto url
        }
    }
*/
    public void ReviveFun()
    {
        //StartCoroutine(GetRequest(UrlForRevive));
        Application.OpenURL(UrlForRevive);
    }
    public void RestartFun()
    {
        SceneManager.LoadScene("GamePlayScene");
    }
    public void QuitFun()
    {
        SceneManager.LoadScene("FstView");
    }
}
