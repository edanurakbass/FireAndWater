using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManager : MonoBehaviour
{
    
    public GameObject fire;

    Vector3 spawn = new Vector3(-11.47f, 1.41f, 12.29f);


    private void Start()
    {
        InvokeRepeating("MoveFire", 0.5f, 2f);    
        
    }

    public void MoveFire()
    {
        Instantiate(fire, spawn, Quaternion.identity);
        
    }

    







}
