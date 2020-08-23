using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class cscfyfy : MonoBehaviour
{
    public GameObject fury;
    public NavMeshAgent agent;
    public ThirdPersonCharacter tpc;
    // Destroy everything that enters the trigger
    private void Start()
    {
        agent = GetComponentInChildren<NavMeshAgent>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "furytrigger")
        {
            tpc.m_MoveSpeedMultiplier = 3;
            agent.stoppingDistance = 5;
            fury.SetActive(true);
            Destroy(other.gameObject);
        }
        Debug.Log(other.name);
        Destroy(other.gameObject);
    }
}