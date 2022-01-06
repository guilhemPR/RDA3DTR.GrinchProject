using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift : MonoBehaviour
{
    private float _giftFallTimer;
    private float giftFallTimerTempo = 1f;
   
    public Player _player;
    public UIScript _UiScript;
    
    private bool _ThisGiftIsTaken = false;

    private Vector2 _GiftPosition;
   
    
    public Rigidbody2D GiftBottomRigidbody2D;
    public Collider2D GiftCollider2D;
    
    

    void Start()
    {
        GiftCollider2D = gameObject.GetComponent<Collider2D>();
        GiftBottomRigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        _GiftPosition = new Vector2(transform.position.x, transform.position.y);
        _player = FindObjectOfType<Player>();
        _UiScript = FindObjectOfType<UIScript>();


    }


    void Update()
    {
        //If the Gift is not taken by the player, manage the gift fall speed;
        if ( _ThisGiftIsTaken == false)
        {
            GiftFallTimer();
        }
        //Else if the player do not take the gift but the gift has taken by the player, then the gift is destroy;
        else if (_player.giftIsTaken == false && _ThisGiftIsTaken )
        {
            Destroy(this.gameObject);
            _UiScript.ScoreChange();

        }
        //
        else
        {
            GiftCollider2D.isTrigger = true;
            GiftFollowPlayer();
            _ThisGiftIsTaken = true;

        }
       
        Debug.Log(_giftFallTimer);
    }
    
    // 
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Player>() == true && _player.giftIsTaken == false)
        {
            _ThisGiftIsTaken = true;

        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    
    // Indicate new position of Gift
    public void GiftTransform()
    {
        _GiftPosition.y--;
        gameObject.transform.position = new Vector2(transform.position.x, _GiftPosition.y);
    }

    // Indicate the time beetween gift movement
    private void GiftFallTimer()
    {
        _giftFallTimer += Time.deltaTime;

        if (_giftFallTimer > giftFallTimerTempo)
        {
            _giftFallTimer = 0f;
            GiftTransform();
        }
    }

    private void GiftFollowPlayer()
    {
        gameObject.transform.position = _player.transform.position;
    }
}
