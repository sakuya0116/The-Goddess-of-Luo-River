using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetColor : MonoBehaviour
{
    public string color;

    public Color red;
    public Color yellow;
    public Color green;
    public Color blue;

    public GameObject red_colorPalate;
    public GameObject yellow_colorPalate;
    public GameObject green_colorPalate;
    public GameObject blue_colorPalate;

    public Animator colorPanel;

    public bool open;
    public GameObject puzzlePanel;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit)
            {
                
                if (hit.collider.name == "Red")
                {
                    colorPanel.SetBool("isOn", true);
                    red_colorPalate.GetComponent<Image>().color = red;
                    Invoke("closePanel", 3);

                }

                if (hit.collider.name == "Green")
                {
                    colorPanel.SetBool("isOn", true);
                    green_colorPalate.GetComponent<Image>().color = green;
                    Invoke("closePanel", 3);
                }

                if (hit.collider.name == "Yellow")
                {
                    colorPanel.SetBool("isOn", true);
                    yellow_colorPalate.GetComponent<Image>().color = yellow;
                    Invoke("closePanel", 3);
                }

                if (hit.collider.name == "Blue")
                {
                    colorPanel.SetBool("isOn", true);
                    blue_colorPalate.GetComponent<Image>().color = blue;
                    Invoke("closePanel", 3);
                }
            }
        }

        if (puzzlePanel.GetComponent<Animator>().GetBool("isOn"))
        {
            colorPanel.SetBool("isOn", true);
        }

        if (puzzlePanel.GetComponent<Animator>().GetBool("isComplete"))
        {
            colorPanel.SetBool("isComplete", true);
        }

    }

    void closePanel()
    {
        colorPanel.SetBool("isOn", false);
    }

    public void controlColorPanel()
    {
        if (colorPanel.GetBool("isOn"))
        {
            colorPanel.SetBool("isOn", false);
        }
        else
            colorPanel.SetBool("isOn", true);
    }
}
