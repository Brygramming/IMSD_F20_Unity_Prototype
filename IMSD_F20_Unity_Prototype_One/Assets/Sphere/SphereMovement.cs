using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMovement : MonoBehaviour
{
    public float MovementAmt;
    Vector3 StartingPosition;
    Vector3 FinishingPosition;

    //For Timed Enemy
    public GameObject TimedEnemy;
    Vector3 TimedEnemyPosition;

    public GameObject Enemies;
    public GameObject Goal;

    //For New Level
    private bool newGame;
    public Transform player;
    public Transform enemyOne;
    public Transform enemyTwo;
    public Transform enemyThree;
    public Transform enemyFour;
    public Transform enemyFive;
    public Transform enemyCube;
    private int levelCount = 1;

    // Start is called before the first frame update
    void Start()
    {
        StartingPosition = transform.position;
        FinishingPosition = new Vector3(0, 0, 0);
        TimedEnemyPosition = TimedEnemy.transform.position;

        //Timed Enemy's Position

        //New Level
        newGame = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-MovementAmt * Time.deltaTime, 0, 0);
            Debug.Log("Left");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(+MovementAmt * Time.deltaTime, 0, 0);
            Debug.Log("Right");
        }

        if (transform.position.x <= -10)
        {
            transform.position = StartingPosition;
        }
        else if (transform.position.x >= 10)
        {
            transform.position = new Vector3(9, 0, 0);
        }
    }

    void OnTriggerEnter(Collider Tch)
    {
        if (Tch.gameObject.tag == "Enemy")
        {
            transform.position = StartingPosition;
            Debug.Log("Enemy touched");
            //Timed Enemy
            TimedEnemy.transform.position = TimedEnemyPosition;
            Debug.Log("Timed Enemy Touched");
        }
        else if (Tch.gameObject.tag == "Win")
        {
            //Destroy(Enemies);
            //Destroy(Goal);
            //Destroy(TimedEnemy);
            transform.position = FinishingPosition;

            NewLevel();
            Debug.Log("Level: " + levelCount.ToString() + " - Next level!");
        }
    }
    void NewLevel()     //A.I.
    {
        //Default startup pattern
        player.position = new Vector3(-6.6f, 0);
        enemyCube.position = new Vector3(-15, 1);
        if (newGame)
        {
            enemyOne.position = new Vector3(-5, -3);
            enemyTwo.position = new Vector3(0, -3);
            enemyThree.position = new Vector3(5, -3);
            enemyFour.position = new Vector3(-2.5f, -3);
            enemyFive.position = new Vector3(2.5f, -3);
            levelCount = 1;
        }
        else
        {
            //Random pattern
            enemyOne.position = new Vector3(-5, Random.Range(-5f, 8f));
            enemyTwo.position = new Vector3(0, Random.Range(-5f, 8f));
            enemyThree.position = new Vector3(5, Random.Range(-5f, 8f));
            enemyFour.position = new Vector3(-2.5f, Random.Range(-5f, 8f));
            enemyFive.position = new Vector3(2.5f, Random.Range(-5f, 8f));
            levelCount++;
        }
        newGame = false;

    }
}