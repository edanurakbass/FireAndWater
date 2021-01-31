using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour,ICollectable
{

    public GameObject floattingText;
   
    public void Collect()
    {
        
        Character.Instance.live += 5;
        Character.Instance.livetext.text = Character.Instance.live.ToString();
        ShowFloattingText();
    }
    void ShowFloattingText()
    {
        var offset = new Vector3(0, 10.0f, 0);
        var go = Instantiate(floattingText, transform.position + offset, Quaternion.identity);
    }
}
