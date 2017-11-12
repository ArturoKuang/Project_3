using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //void OnCollisionEnter2D(Collision2D coll)
    //{
    //    //GameObject.FindWithTag("Player").GetComponent<coll>();
    //    //Physics.IgnoreCollision(, GetComponent<Collider>());
    //    if (coll.gameObject.tag == "Player")
    //    {
    //        GetComponent<SpriteRenderer>().color = Color.red;
    //    }
    //}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

   void OnTriggerExit2D(Collider2D other)
    {
        GetComponent<SpriteRenderer>().color = Color.white;

    }
}
