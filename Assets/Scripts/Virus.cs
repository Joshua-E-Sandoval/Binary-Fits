using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Virus : MonoBehaviour
{
    public GameObject target;
    NavMeshAgent agent;
    GameObject[] targets;
    Neutral Neutral;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null) { agent.SetDestination(target.transform.position); }
        if (target == null)
        {
            targets = GameObject.FindGameObjectsWithTag("GoodBug"); 
            for(int i = 0; i < targets.Length; i++)
            {
                Neutral = targets[i].GetComponent<Neutral>();
                if(!Neutral.IsHunted && target == null)
                { 
                    target = targets[i];
                    Neutral.IsHunted = true;
                }
            }
        }
    }
}
