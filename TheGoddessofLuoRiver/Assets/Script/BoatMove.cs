using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMove : MonoBehaviour
{
    public bool canMove;

    public Vector3 origBoat;
    public Vector3 targetBoat;

    public Animator anim;

    public GameObject player;
    public GameObject npc;

    // Start is called before the first frame update
    void Start()
    {
        origBoat = transform.position;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (npc.GetComponent<Dialog>().onBoat)
        {
            npc.transform.SetParent(transform);
        }

        if(transform.Find(npc.name)==null)
            canMove = false;
        else
            canMove = true;

        if (GetComponent<onBoard>().isOnBoard && canMove)
        {
            player.transform.SetParent(transform);
            if(anim.GetBool("isGo"))
            {
                anim.SetInteger("move", 1);
                player.GetComponent<Move>().MoveSpeed = 0;
                StartCoroutine("offBoardGo");
            }
            else
            {
                anim.SetInteger("move", 2);
                player.GetComponent<Move>().MoveSpeed = 0;
                StartCoroutine("offBoardBack");
            }
           

        }

        
    }

    IEnumerator offBoardGo()
    {
        yield return new WaitForSeconds(13);
        anim.SetBool("isGo", false);
        transform.DetachChildren();
        GetComponent<onBoard>().isOnBoard = false;
        player.GetComponent<Move>().MoveSpeed = 4;
    }

    IEnumerator offBoardBack()
    {
        yield return new WaitForSeconds(13);
        anim.SetBool("isGo", true);
        transform.DetachChildren();
        GetComponent<onBoard>().isOnBoard = false;
        player.GetComponent<Move>().MoveSpeed = 4;
    }
}
