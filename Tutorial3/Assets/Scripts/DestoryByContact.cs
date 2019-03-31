using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerexplosion;
    public int scoreValue;
    private GameController GC;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject != null)
        {
            GC = gameControllerObject.GetComponent<GameController>();
        }
        if(GC == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Boundary")
        {
            return;
        }
       
        if(other.tag == "Player")
        {
            Instantiate(explosion, other.transform.position, other.transform.rotation);
            GC.GameOver();
        }
        Instantiate(explosion, transform.position, transform.rotation);
        GC.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
