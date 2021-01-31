using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 5.0f;
    public int live = 0;
   
    public GameObject floattingFailText;

    public GameObject finalPlatform;
    public GameObject failPanel;
    public GameObject succesPanel;
    public Text livetext;

    private static Character _instance;
    public static Character Instance { get { return _instance; } }

    public GameObject water;

    private void Awake()
    {
        if (_instance != null && _instance != this) //Singleton
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "water")
        {
            Destroy(other.gameObject);
            ICollectable icollectable = other.GetComponent<ICollectable>();

            if (icollectable != null)
                icollectable.Collect();


        }
        else if (other.gameObject.tag == "fire")
        {
            live -= 5;
            livetext.text = live.ToString();
            ShowFloattingFailText();
            if (live <= 0)
            {
                failPanel.SetActive(true);
                Time.timeScale = 0;
            }
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "final")
        {
            if (live >= 10)
            {
                transform.position = new Vector3(finalPlatform.transform.position.x, finalPlatform.transform.position.y + 5.0f, finalPlatform.transform.position.z);
                finalPlatform.transform.position = new Vector3(finalPlatform.transform.position.x, finalPlatform.transform.position.y + 5.0f, finalPlatform.transform.position.z);
                succesPanel.SetActive(true);
                Time.timeScale = 0;
            }

        }
    }   

    void ShowFloattingFailText()
    {
        var offset1 = new Vector3(0, 10.0f, 0);
        var g = Instantiate(floattingFailText, transform.position + offset1, Quaternion.identity);
    }

}

