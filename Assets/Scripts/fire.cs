using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{


    public GameObject character;
    public float speed = 5.0f;

    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, character.transform.position, step);
        Destroy(this.gameObject, 7.0f);
    }

   
}
