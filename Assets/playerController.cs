using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
public class playerController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Vector3 home,office;
    public Simulation sim;
    public int covidstatus=0,playerid;
    public Material corona,redhat;
    public GameObject hat;
    private void Start()
    {

        sim = GameObject.FindGameObjectWithTag("sim").GetComponent<Simulation>();
        FindObjectOfType<Simulation>().gohomeevent += gohome;
        FindObjectOfType<Simulation>().goofficeevent += gooffice;
        home = this.transform.position;
      
        office = sim.offices[UnityEngine.Random.Range(72, 1407)].transform.position;
        agent.updateRotation = false;
        if (covidstatus == 1)
        {
            this.GetComponent<Renderer>().material = corona;
            this.GetComponent<TrailRenderer>().material = corona;
            hat.GetComponent<Renderer>().material = redhat;
        }

    }
  
    public void gooffice()
    {
        agent.SetDestination(office);
      
    }
    public void gohome()
    {
        agent.SetDestination(home);
     
    }
    private void OnTriggerEnter(Collider other)
    {
        if (this.covidstatus == 1 && Random.Range(0,10)%7==0 && other.GetComponent<playerController>().covidstatus!=1)
        {
            this.sim.patients += 1;
            other.GetComponent<Renderer>().material = corona;
            other.GetComponent<playerController>().covidstatus = 1;
            other.GetComponent<TrailRenderer>().material = corona;
            other.GetComponent<playerController>().hat.GetComponent<Renderer>().material = redhat;
            this.sim.patientadded();
            
            
        }
            
    }
}
