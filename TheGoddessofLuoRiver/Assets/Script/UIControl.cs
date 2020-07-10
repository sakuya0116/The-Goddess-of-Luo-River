using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControl : MonoBehaviour
{
    public GameObject[] script;
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (script[0].activeSelf)
        {
            StartCoroutine(showScript(1));
        }
        if (script[1].activeSelf)
        {
            StopCoroutine(showScript(1));
            StartCoroutine(showScript(2));
        }
        if (script[2].activeSelf)
        {
            StopCoroutine(showScript(2));
            StartCoroutine(showScript(3));
        }
        if (script[3].activeSelf)
        {
            StopCoroutine(showScript(3));
            Invoke("closePanel", 8);
        }
    }

  IEnumerator showScript(int i)
    {
        yield return new WaitForSeconds(8);
        script[i].SetActive(true);
        
    }

    void closePanel()
    {
        panel.SetActive(false);
    }
}
