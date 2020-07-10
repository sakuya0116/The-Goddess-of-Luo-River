using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public bool noEvents;
    public bool isBoat;
    public bool isGodess;
    public bool isTalking;

    public Text hint;
    public GameObject pop;

    public Text hintOnPlayer;
    public GameObject popOnPlayer;

    public bool onBoat;

    public GameObject panel;

    public GameObject boat;

    //public GameObject mask;

    private int mouseCount;

    // Start is called before the first frame update
    void Start()
    {
        noEvents = true;
        isBoat = false;
        isGodess = false;
        isTalking = false;

        mouseCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit)
            {
                if (hit.collider.tag == "npc")
                {
                    if (noEvents == true)
                    {
                        pop.SetActive(true);
                        //mask.SetActive(true);
                        hint.text = "My lord, it's already sunset, and our horses are fatigued, we need to have a rest.";
                        isTalking = true;

                    }
                    if (isBoat == true)
                    {
                        pop.SetActive(true);
                        hint.text = "My lord, you want to cross the river? Please go on board. ";
                        isTalking = true;
                    }

                    if(isGodess == true)
                    {
                        pop.SetActive(true);
                        hint.text = "My lord, if she's wearing a jade hair crown, red outerwear, yellow dress and blue shawl, she must be the Godess of the river!";
                        isTalking = true;
                    }
                }

                if (hit.collider.name == "boat" && isBoat==false)
                {
                    popOnPlayer.SetActive(true);
                    hintOnPlayer.text = "I need someone to send me to the other side of the river.";
                    isBoat = true;  noEvents = false;
                    isTalking = true;
                }

                if(hit.collider.name == "Goddess" && isGodess == false)
                {
                    popOnPlayer.SetActive(true);
                    hintOnPlayer.text = "Oh! Who's she? I never met a lady like her...";
                    isBoat = false;
                    isGodess = true;
                    isTalking= true;
                }

                if (hit.collider.name == "Goddess" && isGodess == true && isTalking==false)
                {
                    panel.GetComponent<Animator>().SetBool("isOn", true);
                }



            }
            if (!hit)
            {
                if (isTalking)
                {
                    mouseCount++;
                    if (noEvents == true)
                    {
                        if (mouseCount == 1)
                        {
                            hint.text = "We are near the bank of Luo River, please walk around for a while and enjoy the scenery.";
                        }

                        if (mouseCount == 2)
                        {
                            pop.SetActive(false);
                            //mask.SetActive(false);
                            mouseCount = 0;
                            isTalking = false;
                        }
                    }

                    if (isBoat)
                    {
                        if(mouseCount == 1 && popOnPlayer.activeSelf)
                        {
                            popOnPlayer.SetActive(false);
                            isTalking = false;
                            mouseCount = 0;
                        }

                        if (mouseCount == 1 && pop.activeSelf)
                        {
                            pop.SetActive(false);
                            isTalking = false;
                            mouseCount = 0;
                            transform.position = new Vector2(18.17f, -3.6f);
                            transform.SetParent(boat.transform);
                            onBoat = true;
                        }
                    }

                    if (isGodess)
                    {
                        if(mouseCount==1&& popOnPlayer.activeSelf)
                        {
                            popOnPlayer.SetActive(false);
                            isTalking = false;
                            mouseCount = 0;
                        }

                        if (mouseCount == 1 && pop.activeSelf)
                        {
                            pop.SetActive(false);
                            isTalking = false;
                            mouseCount = 0;
                        }
                    }

                }
            }
        }





    }
}
