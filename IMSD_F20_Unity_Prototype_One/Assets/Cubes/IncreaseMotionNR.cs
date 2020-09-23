using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseMotionNR : MonoBehaviour
{
	float Timer3;
    public float Increase = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        Timer3 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Timer3 += Time.deltaTime;
        if(Timer3 >= 1)
        {
            Timer3 = 0;
            transform.position += new Vector3(0, 1, 0) * Increase;
            Increase = 1 + Increase;
        }
    }
}