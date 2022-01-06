using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class GameScript : MonoBehaviour
{
    
    void Update()
    {
        
        if(Time.realtimeSinceStartup > 60)
        {
            Time.timeScale = 0;
            
        }
    }
}
   
