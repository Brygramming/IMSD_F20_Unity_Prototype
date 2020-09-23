using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoughMotionNR : MonoBehaviour
{
	float Timer2;
	//public float Push = 1;

    // Start is called before the first frame update
    void Start()
    {
       Timer2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
    	Timer2 += Time.deltaTime;
    	if(Timer2 >= 1)
    	{
    		Timer2 = 0;
    		transform.position += new Vector3(0, Random.Range(-0.5f, 2), 0);
    	}
    }
}
