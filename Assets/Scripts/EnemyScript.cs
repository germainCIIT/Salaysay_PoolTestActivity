using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private Transform Player;
    
    public int EnemyHP = 2;
    private int CurrentHP;
   
    private NavMeshAgent navAgent;

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        CurrentHP = EnemyHP;
    }
    
    void Update()
    {
        if (Player != null)
        {
            navAgent.SetDestination(GameObject.FindGameObjectWithTag("Player").gameObject.transform.position);
        }
    }
    
    public void TakeDamage(int Damage)
    {
        EnemyHP -= Damage;
        CurrentHP = EnemyHP;

        if (CurrentHP <= 0)
        {
            Destroy(gameObject);
            KillCounter.instance.EnemyKillTick();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            TakeDamage(1);
            Debug.Log("Damage Taken");
        }
    }
}

