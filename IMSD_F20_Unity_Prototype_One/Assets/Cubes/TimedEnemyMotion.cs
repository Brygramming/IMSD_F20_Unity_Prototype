using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedEnemyMotion : MonoBehaviour
{
    float Timer;
    Vector3 Right;
    public float TimeSpeed;

    // Start is called before the first frame update
    void Start()
    {
    	Timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
    	Timer += Time.deltaTime;
    	if(Timer >= 2)
    	{
    		Timer = TimeSpeed;
    		Right = new Vector3(1, 0, 0);
    		transform.position += Right;
    	}
    }
}
