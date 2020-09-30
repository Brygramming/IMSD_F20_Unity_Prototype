using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SphereMovement : MonoBehaviour
{
    public float MovementAmt;
    Vector3 StartingPosition;
    int SceneCounter = 0;

    //For Timed Enemy
    public GameObject TimedEnemy;
    Vector3 TimedEnemyPosition;

    //For New Level
    private bool newGame;
    public Transform[] Enemy;
    public GameObject RandomEnemies;
    /*public Transform player;
    public Transform enemyOne;
    public Transform enemyTwo;
    public Transform enemyThree;
    public Transform enemyFour;
    public Transform enemyFive;
    public Transform enemyCube;*/ //Timed-Cube
    public Text TextHUD;
    static public int time;
    static private float timer;
    static private int level;
    private int damage;

    // Start is called before the first frame update
    void Start()
    {
        StartingPosition = transform.position;
        TimedEnemyPosition = TimedEnemy.transform.position;         //Timed Enemy's Position
        time = 0;
        level = 1;
        newGame = false;
        //Enemy = transform.tag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        //Sphere Movements
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

        if(newGame == true)
        	{
        		SceneCounter = 0;
        		SceneManager.LoadScene(SceneCounter, LoadSceneMode.Single);
        		newGame = false;
        		Debug.Log("New Game");
        	}

        //Text
        Hud(); //level, damage
    }

    void OnTriggerEnter(Collider Tch)
    {
        if (Tch.gameObject.tag == "Enemy")
        {
            Damage();
            Debug.Log("player Damaged");
    	}
        else if (Tch.gameObject.tag == "Win")
        {
            level++;
            NewLevel();
            
            if(SceneCounter >= 3)
            {
            	SceneCounter = 3;
            }
            else
            {
            	SceneCounter++;
            	SceneManager.LoadScene(SceneCounter, LoadSceneMode.Single);
            }
        }
    }

    //A.I.
    void NewLevel()
    {
        float scale;

        //Default startup pattern
        transform.position = StartingPosition;
        TimedEnemy.transform.position = TimedEnemyPosition;

        if(level >= 4)
        {
        	RandomEnemies.SetActive(true);
            //Random pattern
            Enemy[0].localScale = new Vector3(1, scale = Random.Range(1f, 5f), 1);
            Enemy[1].localScale = new Vector3(1, scale = Random.Range(1, 5f), 1);
            Enemy[2].localScale = new Vector3(1, scale = Random.Range(1f, 4f), 1);
            Enemy[3].localScale = new Vector3(1, scale = Random.Range(1f, 6f), 1);
            Enemy[4].localScale = new Vector3(1, scale = Random.Range(1f, 6f), 1);
            Debug.Log("Random Levels");

            /*enemyOne.position = new Vector3(-5, Random.Range(-5f, 7f));
            enemyTwo.position = new Vector3(0, Random.Range(-5f, 7f));
            enemyThree.position = new Vector3(5, Random.Range(-5f, 8f));
            enemyFour.position = new Vector3(-2.5f, Random.Range(-5f, 8f));
            enemyFive.position = new Vector3(2.5f, Random.Range(-5f, 8f));*/
        }
        //newGame = false;
    }

    //A.I.
    void Damage()
    {
        damage++;
        //GameOver
        if (damage >= 3)
        {
            time = time - time;
            level = 1;
            damage = 0;
            RandomEnemies.SetActive(false);
            newGame = true;
        }
        transform.position = StartingPosition;
        TimedEnemy.transform.position = TimedEnemyPosition;
        //NewLevel();
    }

    //A.I.
    public void Hud() //int _level, int _damage
    {
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            timer = 0;
            time += 1;
        }
        TextHUD.text = "Level: " + level + " | Live: " + (3 - damage) + " | Time: " + time.ToString();
    }
}