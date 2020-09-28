using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private bool newGame = true;
    public Transform player;
    public Transform enemyOne;
    public Transform enemyTwo;
    public Transform enemyThree;
    public Transform enemyFour;
    public Transform enemyFive;
    public Transform enemyCube;
    public Text text;
    public int time;
    private float timer;
    private int level;
    private int damage;
    // Start is called before the first frame update
    void Start()
    {
        StartingPosition = transform.position;
        FinishingPosition = new Vector3(0, 0, 0);
        TimedEnemyPosition = TimedEnemy.transform.position;
        time = 0;
        //Timed Enemy's Position

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
        Hud(level, damage);        //Text

    }

    void OnTriggerEnter(Collider Tch)
    {
        if (Tch.gameObject.tag == "Enemy")
            Damage();
        else if (Tch.gameObject.tag == "Win")
            NewLevel();
        /*        {
                    Destroy(Enemies);
                    Destroy(Goal);
                    Destroy(TimedEnemy);
                    transform.position = FinishingPosition;
                    Debug.Log("Level: " + levelCount.ToString() + " - Next level!");
                }*/
    }
    void NewLevel()     //A.I.
    {
        float scale;
        //Default startup pattern
        player.position = new Vector3(-6.6f, 0);
        enemyCube.position = new Vector3(-15, 1);
        if (newGame)
        {
            enemyOne.localScale = new Vector3(1, 1);
            enemyTwo.localScale = new Vector3(1, 1);
            enemyThree.localScale = new Vector3(1, 1);
            enemyFour.localScale = new Vector3(1, 2.5f);
            enemyFive.localScale = new Vector3(1, 6);

            enemyOne.position = new Vector3(-5, -3);
            enemyTwo.position = new Vector3(0, -3);
            enemyThree.position = new Vector3(5, -3);
            enemyFour.position = new Vector3(-2.5f, -3);
            enemyFive.position = new Vector3(2.5f, -3);
            time = time - time;
            level = 1;
            damage = 0;
        }
        else
        {
            //Random pattern
            enemyOne.localScale = new Vector3(1, scale = Random.Range(1f, 7f));
            enemyTwo.localScale = new Vector3(1, scale = Random.Range(1, 7));
            enemyThree.localScale = new Vector3(1, scale = Random.Range(1f, 7f));
            enemyFour.localScale = new Vector3(1, scale = Random.Range(1f, 7f));
            enemyFive.localScale = new Vector3(1, scale = Random.Range(1f, 7f));

            enemyOne.position = new Vector3(-5, Random.Range(-5f, 8f));
            enemyTwo.position = new Vector3(0, Random.Range(-5f, 8f));
            enemyThree.position = new Vector3(5, Random.Range(-5f, 8f));
            enemyFour.position = new Vector3(-2.5f, Random.Range(-5f, 8f));
            enemyFive.position = new Vector3(2.5f, Random.Range(-5f, 8f));
            level++;
            
        }
        newGame = false;

    }

    void Damage()     //A.I.
    {
        damage++;
        level--;

        if (damage >= 3) //GameOver
            newGame = true;
        NewLevel();
    }

    public void Hud(int _level, int _damage)
    {
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            timer = 0;
            time += 1;
        }
        text.text = "Level: " + _level + " | Live: " + (3 - _damage) + " | Time: " + time.ToString();
    }
}