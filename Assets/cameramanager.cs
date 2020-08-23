using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramanager : MonoBehaviour
{
    public Transform[] campositions;
    public GameObject[] humans;
    public float addx, addy, addz;
    public int index=0,index2=999;
    // Start is called before the first frame update
    void Start()
    {
        humans = GameObject.FindGameObjectsWithTag("human");
    }

   public void changeposition()
    {
        this.transform.parent = null;
        this.transform.position = campositions[index].position;
        this.transform.rotation = campositions[index].rotation;
        index ++;
        if (index > 5)
        {
            index = 0;
        }
    }
    public void ghodagadi()
    {
        this.transform.parent = null;
        humans = GameObject.FindGameObjectsWithTag("human");
        index2 = Random.Range(0, 500);
        Debug.Log("indexis" + index2);
        while (humans[index2].GetComponent<playerController>().covidstatus!=1)
        {
            index2 = Random.Range(0, 999);
        }
      this.transform.position=  (new Vector3(humans[index2].transform.position.x-addx, humans[index2].transform.position.y-addy, humans[index2].transform.position.z+addz));
        transform.LookAt(humans[index2].transform);
        this.transform.parent = humans[index2].transform;
    }

}
