using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Simulation : MonoBehaviour
{
    public bool day = false;
    public int samplesize = 500;
    public bool officecalc = true;
    public GameObject[] humans;
    public GameObject playerprefab,canvascontent,camera;
    public delegate void Gohomeevent();
    public Gohomeevent gohomeevent;
    public delegate void Goofficeevent();
    public Gohomeevent goofficeevent;
    public PhysicMaterial corona;
    public CityGeneratorScript cgs;
    public List<GameObject> offices,homes;
    public int patients = 0;
    public Material nightsky,daysky;
    public WMG_Axis_Graph graph;
    public WMG_Series SERIES1;
    public List<Vector2> points;
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        SERIES1= graph.addSeries();

        offices = cgs.placedOffice;
        homes = cgs.placedHome;
        points.Add(new Vector2(timer, patients));
        for (int i = 1; i <= samplesize; i++)
        {
            
            Vector3 position = new Vector3(UnityEngine.Random.Range(-22, -60), 17, UnityEngine.Random.Range(-1, -167));
            GameObject temp = Instantiate(playerprefab,homes[UnityEngine.Random.Range(69,1420)].transform.position, Quaternion.identity);
            if (i < 6)
            {
                temp.GetComponent<playerController>().covidstatus = 1;
            }

            else
            {
                temp.GetComponent<playerController>().covidstatus = UnityEngine.Random.Range(0, 100);
            }

            temp.GetComponent<playerController>().playerid = i;
        }
        humans = GameObject.FindGameObjectsWithTag("human");

    }

    // Update is called once per frame
    public void gohome()
    {
        //for (int i = 0; i <= samplesize - 1; i++)
        //{
        //    humans[i].GetComponent<playerController>().gohome();
        //}
        RenderSettings.skybox = nightsky;
        if (gohomeevent != null)
        {
            gohomeevent();
        }
        
    }
    public void gooffice()
    {
        RenderSettings.skybox = daysky;
        if (goofficeevent != null)
        {
            goofficeevent();
        }
    }

   public void patientadded()
    {
        points.Add(new Vector2(timer, patients));
        SERIES1.pointValues.SetList(points);
       
        graph.Refresh();
        
       
    }
    void Update()
    {
        timer = timer + Time.deltaTime;
        if(timer>40 && timer<45)
        {
            canvascontent.SetActive(true);
            camera.GetComponent<Animator>().enabled = false;
        }
    }
    public void changespeed(float speed)
    {
        for (int i = 0; i <= samplesize - 1; i++)
        {
            humans[i].GetComponent<NavMeshAgent>().speed = speed;
            humans[i].GetComponent<NavMeshAgent>().angularSpeed = (float)(120.0 + (speed * 10.8));

        }
    }
    public void maskon()
    {
        for (int i = 0; i <= samplesize - 1; i++)
        {
            humans[i].GetComponent<CapsuleCollider>().radius = 1;
            Debug.Log("masked" + i);
        }
    }
    public void maskoff()
    {
        for (int i = 0; i <= samplesize - 1; i++)
        {
            humans[i].GetComponent<CapsuleCollider>().radius = (float)1.5;

        }
    }

}
