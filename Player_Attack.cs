using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public GameObject hitBox;
    Enemy_Health enemy;
    Basic_Movement playMov;
    
    bool once;


    void Start()
    {
        playMov = this.GetComponent<Basic_Movement>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            once = true;
            if (playMov.flipped == false)
            {
                hitBox.GetComponent<Transform>().transform.position = this.transform.position + new Vector3(1.3f, 0, 0);
            }
            if (playMov.flipped == true)
            {
                hitBox.GetComponent<Transform>().transform.position = this.transform.position + new Vector3(-1.3f, 0, 0);
            }
            hitBox.GetComponent<SpriteRenderer>().enabled = true;
            hitBox.GetComponent<CapsuleCollider2D>().enabled = true;
            
            StartCoroutine("HitBoxTime");
        }

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (once)
        {
            if (other.gameObject.tag == "Enemy")
            {
                other.GetComponent<Enemy_Health>().health --;
            }
            once= false;
        }

    }

    IEnumerator HitBoxTime()
    {
        yield return new WaitForSeconds(0.2f);
        hitBox.GetComponent<Transform>().transform.position = new Vector3(0, -1000, 0);
        hitBox.GetComponent<SpriteRenderer>().enabled = false;
        hitBox.GetComponent<CapsuleCollider2D>().enabled = false;
        

    }
}
