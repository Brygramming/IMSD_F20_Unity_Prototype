using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothMotionNR : MonoBehaviour
{
	float Timer1;

    // Start is called before the first frame update
    void Start()
    {
    	//transform.position = new Vector3(-5, 0, 0);
    	Timer1 = 0;
    }

    // Update is called once per frame
    void Update()
    {
    	Timer1 += Time.deltaTime;
    	if(Timer1 >= 1)
    	{
    		Timer1 = 0;
    		transform.position += new Vector3(0, 1, 0);
    	}
    }
}