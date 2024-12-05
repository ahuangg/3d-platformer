using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DemoEventListener : MonoBehaviour
{

    private UnityAction noParamEventListener;
    private UnityAction<int> oneParamEventListener;
    private UnityAction<float, float> twoParamEventListener;



   

    void Awake()
    {

        noParamEventListener = new UnityAction(noParamEventHandler);
        oneParamEventListener = new UnityAction<int>(oneParamEventHandler); 
        twoParamEventListener = new UnityAction<float, float>(twoParamEventHandler);


    }


    // Use this for initialization
    void Start()
    {

     			
    }


    void OnEnable()
    {
        EventManager.StartListening<NoParamEvent>(noParamEventListener);
        EventManager.StartListening<OneParamEvent, int>(oneParamEventListener);
        EventManager.StartListening<TwoParamEvent, float, float>(twoParamEventListener);          
    }

    void OnDisable()
    {
        EventManager.StopListening<NoParamEvent>(noParamEventListener);
        EventManager.StopListening<OneParamEvent, int>(oneParamEventListener);
        EventManager.StopListening<TwoParamEvent, float, float>(twoParamEventListener);
    }

  
    // Update is called once per frame
    void Update()
    {
    }
        
    void noParamEventHandler()
    {
        print("noParamEventHandler() called");
    }

    void oneParamEventHandler(int i)
    {
        print("We got i = " + i);
    }
       
    void twoParamEventHandler(float a, float b)
    {
        float total = a + b;

        print("a (" + a.ToString() + ") + b (" + b.ToString() + ") = " + total.ToString());      
    }

}
