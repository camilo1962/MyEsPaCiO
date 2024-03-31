using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContoladorNaveEnemiga : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpawn;
    public float delay;
    public float fireRate;


    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        InvokeRepeating("Fire", delay, fireRate);
    }

  
    void Update()
    {
        
    }

    void Fire()
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        audioSource.Play();
    }
}
