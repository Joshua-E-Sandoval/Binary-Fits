using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControler : MonoBehaviour
{
    public GameObject BFGoodBug,
                      BFGVirus,
                      Beacon;
    int i = 0;
    public List<GameObject> good;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           good.Add(Instantiate( BFGoodBug, new Vector3 ( i, 0, i ) , Quaternion.identity));
           i += 5;
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            good.Add(Instantiate(Beacon, new Vector3(i, 0, -i), Quaternion.identity));
            i += 5;
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            good.Add(Instantiate(BFGVirus, new Vector3(-i, 0, -i), Quaternion.identity));
            i += 5;
        }
    }
}
