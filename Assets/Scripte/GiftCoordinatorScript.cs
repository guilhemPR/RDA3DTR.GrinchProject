using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class GiftCoordinatorScript : MonoBehaviour

 
{
    public GameObject Gift;
    private GameObject NewGift;
    public Player Player;
    private int _giftApparitionOrder;

    private int _giftApparitionTime;
    private Stopwatch _stopwatchGiftApparition;

    private int _giftApparitionDifficultyMin = 2000;
    private int _giftApparitionDifficultyMax = 4000;

    private Vector2[] _GiftApparitionPosition; 
    
    
    void Start()
    {
        _giftApparitionTime = Random.Range(_giftApparitionDifficultyMin, _giftApparitionDifficultyMax);

        _stopwatchGiftApparition = new Stopwatch();
        _stopwatchGiftApparition.Start();
        
    }


    void Update()
    {
        if (_GiftApparitionPosition == null)
        {

            for (int i = 0; i < Player.playerPosition.Length - 1; i++)
            {
              
                if (_GiftApparitionPosition == null)
                {
                    _GiftApparitionPosition = new Vector2[Player.playerPosition.Length-1];
                }
              
                _GiftApparitionPosition[i] = Player.playerPosition[i];
                _GiftApparitionPosition[i].y = 4f;
              

            }
        }
        
        if (_stopwatchGiftApparition.ElapsedMilliseconds > _giftApparitionTime)
        {
            
            
            _giftApparitionOrder = Random.Range(0,3);
           
      
            NewGift = Instantiate(Gift, _GiftApparitionPosition[_giftApparitionOrder], Quaternion.identity);
            
            _stopwatchGiftApparition.Stop();
            _stopwatchGiftApparition = new Stopwatch();
            _stopwatchGiftApparition.Start();
            

        }
    }
}
