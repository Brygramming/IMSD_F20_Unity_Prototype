using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothMotionEnemies : MonoBehaviour
{
	float Timer1;
    Vector3 StopGoing;
    public float TimeSpeed;

    // Start is called before the first frame update
    void Start()
    {
    	Timer1 = 0;
    }

    // Update is called once per frame
    void Update()
    {
    	Timer1 += Time.deltaTime;
    	if(Timer1 >= 1)
    	{
    		Timer1 = TimeSpeed;
            if(transform.position.y >= 5)
            {
                StopGoing = new Vector3(0, -1, 0);
                transform.position += StopGoing;
            } else if(transform.position.y <= -3)
            {
                StopGoing = new Vector3(0, 1, 0);
                transform.position += StopGoing;
            } else
            {
                transform.position += StopGoing;
            }
    	}
    }

    /*void OnTriggerEnter(Collider Tch)
    {
        if(Tch.gameObject.tag == "Player")
        {
            //transform.position = StartingPosition;
            Debug.Log("Enemy touched");
        }
    }*/
}