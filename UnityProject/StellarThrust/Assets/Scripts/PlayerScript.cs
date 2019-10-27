using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public Text sc;
    public GameObject ground;
    public GameObject fire;
    public GameObject winscreen;
    Vector3 initialpos;
    Vector3 gpos;
    int s = 0;
    // Start is called before the first frame update
    void Start()
    {
        winscreen.SetActive(false);
        initialpos = transform.position;
        gpos = ground.transform.position;
        fire.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        s = (int)transform.position.x + 50;
        sc.text = "Score : " + s.ToString();
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
        if (transform.position.x > 124 )
        {
            winscreen.SetActive(true);
        }
        

    }
    void FixedUpdate()

    {
        ground.transform.position = gpos;
        if(transform.position.y > initialpos.y && (!Input.GetKeyDown(KeyCode.UpArrow) || !Input.GetKeyDown(KeyCode.Space)))
        {
            transform.position += Vector3.down * 5 * Time.deltaTime;
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
        
    }
    void jump()
    {
        if (transform.position.y < initialpos.y + 10)
        {
            fire.SetActive(true);
        transform.position += Vector3.up * 40 * Time.deltaTime;
        }
                //transform.position += Vector3.up * 2 * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "winner")
        {
            Debug.Log("ok");
        }
    }
}
