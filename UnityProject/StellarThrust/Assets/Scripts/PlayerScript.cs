using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public Text hrrSctxt;
    public GameObject ground;
    public GameObject fire;
    Vector3 initialpos;
    Vector3 gpos;
    int cStat = 0;
    // Start is called before the first frame update
    void Start()
    {
        initialpos = transform.position;
        gpos = ground.transform.position;
        fire.SetActive(false);
        hrrSctxt.text = "Collection : " + cStat.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        var speed = 18;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > -14.1)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }

        //from here

    }
    void FixedUpdate()

    {
        ground.transform.position = gpos;
        if (transform.position.y > initialpos.y && (!Input.GetKeyDown(KeyCode.UpArrow) || !Input.GetKeyDown(KeyCode.Space)))
        {
            transform.position += Vector3.down * 20 * Time.deltaTime;
            fire.SetActive(false);
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space) && transform.position.y < 0)
        {
            jump();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            initialpos = transform.position;
        }
        
        //from here

    }
    void jump()
    {
        if (transform.position.y < initialpos.y + 10)
        {
            fire.SetActive(true);
            transform.position += Vector3.up * 40 * Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemytag")
        {
            SceneManager.LoadScene("Lost");
        }
        if (collision.gameObject.tag == "pointtag")
        {
            cStat += 1;
            hrrSctxt.text = "Collection : " + cStat.ToString();
        }
    }

}
