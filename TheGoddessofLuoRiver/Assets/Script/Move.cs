using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody2D m_rg;
    private Animator anim;

    public float MoveSpeed;

    public GameObject Ui;

    public float minX;
    public float maxX;


    void Start()
    {
        m_rg = GetComponent<Rigidbody2D>();
        anim = GetComponent <Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            m_rg.velocity = new Vector2(MoveSpeed, m_rg.velocity.y);

            transform.localScale = new Vector2(0.25f, 0.25f);
            //Ui.transform.localScale = new Vector2(Ui.transform.localScale.x, Ui.transform.localScale.y);
            anim.SetBool("isWalking", true);
        }

        else if (Input.GetAxis("Horizontal") < 0)
        {
            m_rg.velocity = new Vector2(-MoveSpeed, m_rg.velocity.y);

            transform.localScale = new Vector2(-0.25f, 0.25f);
            //Ui.transform.localScale = new Vector2(-Ui.transform.localScale.x, Ui.transform.localScale.y);
            anim.SetBool("isWalking", true);
        }
        else
        {
            m_rg.velocity = new Vector2(0, m_rg.velocity.y);
            anim.SetBool("isWalking", false);
        }

        if (transform.position.x < minX)
        {
            transform.position = new Vector2(minX, transform.position.y);
        }
        else if (transform.position.x > maxX)
        {
            transform.position = new Vector2(maxX, transform.position.y);
        }

   
        
    }


}
