using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoDestroyScene : MonoBehaviour
{
	private static NoDestroyScene iinstance;
 	void Awake()
 	{
 		
         
     	if(iinstance == null)
     	{
     		iinstance = this;
     		DontDestroyOnLoad (this);
     	} else
     	{
         	Destroy(gameObject);
     	}
 	}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	
    }
}