using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poop : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    void Start()
    {
        animator.GetComponent<Animator>();
    }

    void Update()
    {
        
    }
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            GameManager.Instanse.Score();
            animator.SetTrigger("Poop");
        }

        if (collision.gameObject.tag == "Player")
        {
            GameManager.Instanse.GameOver();
            Destroy(this.gameObject);
        }
    }
   
}
