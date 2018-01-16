using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {
    Rigidbody2D rb;
    Quaternion rotation;
    public Direction direction;
    public Sprite one;
    public Sprite two;
    public Sprite three;
    float waitTime = 0.1f;
    // Use this for initialization
    void Start() {
        StartCoroutine("ChangeSprite");
        rotation = transform.rotation;
        rb = GetComponent<Rigidbody2D>();
        
        rb.AddForce(Vector3.right * 100);
        direction.right = true;
        CheckDirection();
    }

    // Update is called once per frame
    void Update() {
        
        if (Input.GetKeyUp(KeyCode.W))
        {
            direction.up = true;
            CheckDirection();
            rb.velocity = Vector3.zero;
            transform.rotation = Quaternion.identity;
            transform.Rotate(new Vector3(0,0,90));
            rb.AddForce(Vector3.up * 100);

        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            direction.down = true;
            CheckDirection();
            rb.velocity = Vector3.zero;
            transform.rotation = Quaternion.identity;
            transform.Rotate(new Vector3(0, 0, -90));
            rb.AddForce(Vector3.down * 100);

        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            direction.down = true;
            CheckDirection();
            rb.velocity = Vector3.zero;
            transform.rotation = Quaternion.identity;
            transform.Rotate(new Vector3(0, 0, 0));
            rb.AddForce(Vector3.right * 100);

        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            direction.down = true;
            CheckDirection();
            rb.velocity = Vector3.zero;
            transform.rotation = Quaternion.identity;
            transform.Rotate(new Vector3(0, 180, 0));
            rb.AddForce(Vector3.left * 100);

        }


    }
   public  struct Direction
        {
        public bool up, down, left, right;


        }
    void CheckDirection()
    {
        if (direction.right)
        {
            direction.left = false;
            direction.up = false;
            direction.down = false;
        }
        else if (direction.left)
        {
            direction.right = false;
            direction.up = false;
            direction.down = false;
        }
        else if (direction.up)
        {
            direction.right = false;
            direction.left = false;
            direction.down = false;
        }
        else if (direction.down)
        {
            direction.right = false;
            direction.left = false;
            direction.up = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Wall" || collision.gameObject.tag == "Obstacle")
        {   
            rb.velocity = Vector3.zero;
            rb.freezeRotation = true;
            
        }

    }
    IEnumerator ChangeSprite()
    {
        while(true)
        {
            GetComponent<SpriteRenderer>().sprite = one;
            yield return new WaitForSeconds(waitTime);
            GetComponent<SpriteRenderer>().sprite = two;
            yield return new WaitForSeconds(waitTime);
            //GetComponent<SpriteRenderer>().sprite = three;
            //yield return new WaitForSeconds(waitTime);
        }
    }
}
