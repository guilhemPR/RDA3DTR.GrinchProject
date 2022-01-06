using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Player : MonoBehaviour
{

    private KeyCode _playerLeftKeyCode = KeyCode.Q;
    private KeyCode _playerRightKeyCode = KeyCode.D;
  
    
    public Vector2 _playerLeftPosition = new Vector2(-6.5f, -0.8f);
    public Vector2 _playerCentrePosition = new Vector2(-2.5f, -1.95f);
    public Vector2 _playerRightPosition = new Vector2(1f, -1.95f);
    public Vector2 _playerChestPosition = new Vector2(-6.17f, -2f);

    private int _playerPositionInt = 1;
  

    private int _timeDebufLimite = 200;
    private Stopwatch _stopwatchDebuf;
   
    public Vector2[] playerPosition;
    public Animator playerAnimator;
    private Rigidbody2D _rigidbody;
    
    public bool giftIsTaken = false;
    public Gift _Gift;
   
    
    
    
    
    
    private void Start()
    {
        playerPosition = new Vector2[] { _playerLeftPosition, _playerCentrePosition, _playerRightPosition, _playerChestPosition };
        gameObject.transform.position = playerPosition[_playerPositionInt];
        _stopwatchDebuf = new Stopwatch();
        _stopwatchDebuf.Start();
        playerAnimator = GetComponent<Animator>();
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
       
    }

  
    private void Update()
    {
        

        if (Input.GetKeyDown(_playerLeftKeyCode) && _playerPositionInt > 0 && _stopwatchDebuf.ElapsedMilliseconds > _timeDebufLimite) 
        {
            
            _playerPositionInt--;
            gameObject.transform.position = playerPosition[_playerPositionInt];
            
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            
            StopWatch();
        }
       
        if (Input.GetKeyDown(_playerRightKeyCode) && _playerPositionInt < playerPosition.Length - 1 && _stopwatchDebuf.ElapsedMilliseconds > _timeDebufLimite)
        {
            
            _playerPositionInt++;
            Debug.Log(_playerPositionInt);
            gameObject.transform.position = playerPosition[_playerPositionInt];
            
            

            gameObject.GetComponent<SpriteRenderer>().flipX = false;
           
            StopWatch();
        }
        
        
      
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Gift>() == true && !giftIsTaken)
        {
                playerAnimator.SetTrigger("GetGift");
                giftIsTaken = true;
                
                
        }

       
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Chests"))
        {
            giftIsTaken = false;
            
        }
    }


    public void StopWatch()
    {
        _stopwatchDebuf.Stop();
        _stopwatchDebuf = new Stopwatch();
        _stopwatchDebuf.Start();
    }

  

}
