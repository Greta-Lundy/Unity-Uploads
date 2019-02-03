using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover2 : MonoBehaviour
{


    public float speed = 8.0f;

    private Transform target;

    void Awake()
    {

        transform.position = new Vector3(-6.5f, 0.0f, -4.25f);

        GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);

        target = cylinder.transform;
        target.transform.localScale = new Vector3(0.15f, 1.0f, 0.15f);
        target.transform.position = new Vector3(6.5f, 0.0f, -4.25f);
        cylinder.SetActive(false);
    }

    void Update()
    {

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);


        if (Vector3.Distance(transform.position, target.position) < 0.001f)
        {

            target.position = new Vector3(target.position.x * -1, 0, target.position.z);
        }
    }
}
