using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MissonManager : MonoBehaviour
{
    

    Action PassagerSpwanEvent; 
    Action GoalSpawnEvent;
    public Action PassagerSpwanEvent1 { get => PassagerSpwanEvent; set => PassagerSpwanEvent = value; }
    public Action GoalSpawnEvent1 { get => GoalSpawnEvent; set => GoalSpawnEvent = value; }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ImNeedARide()
    {
        PassagerSpwanEvent1.Invoke();
    }

    public void ImWantToGoTo()
    {
       // GoalSpawnEvent.Invoke();
    }
    
}
