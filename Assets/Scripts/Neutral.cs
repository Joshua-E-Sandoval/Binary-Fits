using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Neutral : MonoBehaviour
{
    NavMeshAgent agent;
    private Rigidbody rb;
    public GameObject health;

    BeaconControl beaconControl;
    GameObject[] beacons;

    public bool IsHunted = false;
    
    // Start is called before the first frame update
    void Start()
    { 
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        health = null;
    }

    void Update()
    {
        if (health != null)
        {
            agent.SetDestination(health.transform.position);
        }
        if (health == null)
        {

            beacons = GameObject.FindGameObjectsWithTag("Beacon");
            for(int i = 0; i < beacons.Length; i++)
            {
                beaconControl = beacons[i].GetComponent<BeaconControl>();
                if (!beaconControl.IsTarget && health == null)
                {
                    health = beacons[i];
                    beaconControl.IsTarget = true;
                }
            }
        }
    }
}
