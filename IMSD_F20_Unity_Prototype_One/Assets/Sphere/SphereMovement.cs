using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMovement : MonoBehaviour
{
	public float MovementAmt;
	Vector3 StartingPosition;
	Vector3 FinishingPosition;
	public GameObject Enemies;
	public GameObject Goal;

    // Start is called before the first frame update
    void Start()
    {
        StartingPosition = transform.position;
        FinishingPosition = new Vector3(0, 0, 0);
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
    	} else if(Tch.gameObject.tag == "Win")
    	{
    		Destroy(Enemies);
    		Destroy(Goal);
    		transform.position = FinishingPosition;
    		Debug.Log("You Win");
    	}
    }
}