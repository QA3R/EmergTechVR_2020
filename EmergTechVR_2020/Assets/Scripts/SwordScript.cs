using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    public GameObject enemyScriptObj;
    public EnemyScript enemyScript;

    // Start is called before the first frame update
    void Start()
    {
        enemyScriptObj = GameObject.FindGameObjectWithTag("Enemy");
        enemyScript = enemyScriptObj.GetComponent<EnemyScript>();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Enemy_Sword" && enemyScript.isImmortal)
        {
            Debug.Log("Sword has collided");
            enemyScript.DecreaseParryCounter();
        }
        else
        {
            Debug.Log("Attack was blocked");
        }
    }
}
