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

    // Start is called before the first frame update
    void Start()
    {
        StartingPosition = transform.position;
        FinishingPosition = new Vector3(0, 0, 0);
        TimedEnemyPosition = TimedEnemy.transform.position;

        //Timed Enemy's Position
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
        	transform.position += new Vector3 (-MovementAmt * Time.deltaTime, 0, 0);
        	Debug.Log("Left");
        }else if (Input.GetKey(KeyCode.D))
        {
        	transform.position  += new Vector3 (+MovementAmt * Time.deltaTime, 0, 0);
        	Debug.Log("Right");
        }

        if(transform.position.x <= -10)
        {
        	transform.position = StartingPosition;
        } else if(transform.position.x >= 10)
        {
        	transform.position = new Vector3(9, 0, 0);
        }
    }

    void OnTriggerEnter(Collider Tch)
    {
    	if(Tch.gameObject.tag == "Enemy")
    	{
    		transform.position = StartingPosition;
    		Debug.Log("Enemy touched");

            //Timed Enemy
            TimedEnemy.transform.position = TimedEnemyPosition;
            Debug.Log("Timed Enemy Touched");
    	} else if(Tch.gameObject.tag == "Win")
    	{
    		Destroy(Enemies);
    		Destroy(Goal);
            Destroy(TimedEnemy);
    		transform.position = FinishingPosition;
    		Debug.Log("You Win");
    	}
    }
}