using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandonRotador : MonoBehaviour
{

    public float velicidadGiro;
    private Rigidbody rig;

    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }

    void Start()
    {
      
       
        rig.angularVelocity = Random.insideUnitCircle * velicidadGiro;
    }



}
