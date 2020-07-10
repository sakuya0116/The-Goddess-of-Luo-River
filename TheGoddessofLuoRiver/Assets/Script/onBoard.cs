using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onBoard : MonoBehaviour
{
    public bool isOnBoard;


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            isOnBoard = true;
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            isOnBoard = false;
        }

    }

}
