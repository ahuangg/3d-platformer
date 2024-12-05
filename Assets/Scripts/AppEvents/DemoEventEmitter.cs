using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoEventEmitter : MonoBehaviour {

    public bool triggerMe = true;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
        if (triggerMe)
        {
            triggerMe = !triggerMe;

            EventManager.TriggerEvent<NoParamEvent>();
            EventManager.TriggerEvent<OneParamEvent, int>(5);
            EventManager.TriggerEvent<TwoParamEvent, float, float>(3f, 5f);

        }
       
	}
}
