using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyScript : MonoBehaviour
{
    public int parryCount;
    public int hitWindow;
    public int health;

    public bool isImmortal;

    public TextMesh healthCounter;
    public TextMesh parryCounter;
    public TextMesh enemyState;
  
    // Start is called before the first frame update
    void Start()
    {
        isImmortal = true;
        parryCount = 7;
        hitWindow = 7;
        health = 10;
        parryCounter.text = "PARRY COUNT: " + parryCount.ToString();
        healthCounter.text = "HEALTH: " + health.ToString();
        enemyState.text = "STATE: DEFENDING";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecreaseParryCounter()
    {
        parryCount --;
        ChangeState();
        parryCounter.text = "PARRY COUNT: " + parryCount.ToString();
        Debug.Log("The enemy can block " + parryCount + " more times.");
    }

    public void ChangeState()
    {
        if (isImmortal && parryCount <= 0)
        {
            isImmortal = false;
            hitWindow = 7;
            Debug.Log("THE ENEMY IS EXPOSED");
            enemyState.text = "STATE: EXPOSED";
        }
        else if (!isImmortal && hitWindow <=0) 
        {
            isImmortal = true;
            parryCount = 7;
            Debug.Log("THE ENEMY ENTERED ITS DEFENSE STATE");
            enemyState.text = "STATE: DEFENDING";
        }

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Weapon" && !isImmortal)
        {
            hitWindow--;
            health--;
            ChangeState();
            Debug.Log("The enemy has " + health + " health left.");
            healthCounter.text = "HEALTH: " + health.ToString();
        }
        else if (collision.gameObject.tag == "Weapon" && isImmortal)
        {
            Debug.Log("THE ENEMY IS IN DEFENSE STATE");
        }
    }
}
