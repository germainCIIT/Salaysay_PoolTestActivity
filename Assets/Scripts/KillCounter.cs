using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillCounter : MonoBehaviour
{
    public static KillCounter instance;
    public int enemyKillCount;
    
    public TMP_Text KillTicker;
    bool ifReached30Kills = false;
    
    private void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        KillTicker.text = "Kills: " + enemyKillCount;
    }

    public void EnemyKillTick()
    {
        enemyKillCount++;
        KillTicker.text = "Kills: " + enemyKillCount;
        Debug.Log("Enemy Killed: " + enemyKillCount);
        
        if (enemyKillCount >= 30 && !ifReached30Kills)
        {
            Invoke("HPAlert", 0.2f);
            BuffEnemyHP();
        }
    }
    
    private void BuffEnemyHP()
    {
        GameObject[] Enemy = GameObject.FindGameObjectsWithTag("Enemy");
        
        foreach (GameObject enemies in Enemy)
        {
            EnemyScript unit = enemies.GetComponent<EnemyScript>();
            unit.EnemyHP = 3;
        }
    }

    private void HPAlert()
    {
        Debug.Log("Enemy HP buffed to 3");
    }
}
