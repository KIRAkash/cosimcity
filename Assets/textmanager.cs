using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class textmanager : MonoBehaviour
{
    public TMP_Text total,infected;
    public Simulation sim;
    // Start is called before the first frame update
    void Start() {
        total.text = sim.samplesize.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        infected.text = sim.patients.ToString();
    }
}
