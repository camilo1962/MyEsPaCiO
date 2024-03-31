using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirPorContacto : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;

    public int scoreValue;
    private GameController gameControler;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameControler = gameControllerObject.GetComponent<GameController>();
    }

    //gameControler =GameObject.FindWithTag("GameController").GetComponent<GameController>();
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemigo")) return;

        if(explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
        
        if (other.CompareTag("Player"))
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameControler.GameOver();
        }

        gameControler.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
       
    }

   

   
}
