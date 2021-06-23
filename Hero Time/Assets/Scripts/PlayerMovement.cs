using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PlayerMovement : MonoBehaviour
{
    public float movespeed = 3f;
    public Rigidbody2D rb;
    Vector2 movement;
    public Text myScoreText;
    public int ScoreNum;
    public AudioClip coinSound;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movespeed * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter2D(Collider2D Coin)
    {
        if(Coin.gameObject.tag == "Coins")
        {
          
            ScoreNum += 1;
            AudioSource.PlayClipAtPoint(coinSound, transform.position);
            Destroy(Coin.gameObject);
            myScoreText.text = "Score: " + ScoreNum;
        }
        
    }
}
