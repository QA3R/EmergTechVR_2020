using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public int parryCount;
    public int hitWindow;
    public int health;

    public bool isImmortal;
    public bool inCollision;

    public Text healthCounter;
    public Text parryCounter;
    public Text enemyState;
  
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
            parryCounter.text = "PARRY COUNT: " + parryCount.ToString();
        }
        else if (!isImmortal && hitWindow <=0) 
        {
            isImmortal = true;
            parryCount = 7;
            Debug.Log("THE ENEMY ENTERED ITS DEFENSE STATE");
            enemyState.text = "STATE: DEFENDING";
            parryCounter.text = "PARRY COUNT: " + parryCount.ToString();
        }

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Weapon" && !isImmortal && !inCollision)
        {
            hitWindow--;
            health--;
            ChangeState();
            Debug.Log("The enemy has " + health + " health left.");
            healthCounter.text = "HEALTH: " + health.ToString();
            inCollision = true;
        }
        else if (collision.gameObject.tag == "Weapon" && isImmortal)
        {
            Debug.Log("THE ENEMY IS IN DEFENSE STATE");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Weapon" && !isImmortal && inCollision)
        {
            inCollision = false;
        }
    }
}
