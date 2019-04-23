using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSSpeed : MonoBehaviour
{
    public float speed;

    private bool win;
    private ParticleSystem PS;


    void Start()
    {
        win = false;
        PS = GetComponent<ParticleSystem>();
    }

    
    void Update()
    {
        var main = PS.main;
        if (win)
        {
            main.simulationSpeed = Mathf.Lerp(1, speed, Time.time);
        }
    }

    public void PSAccel()
    {
        win = true;
    }
}
