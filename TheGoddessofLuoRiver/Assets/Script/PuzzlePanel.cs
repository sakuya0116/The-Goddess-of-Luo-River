using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzlePanel : MonoBehaviour
{
    Animator anim;

    public GameObject head;
    public GameObject coat;
    public GameObject dress;
    public GameObject shawl;

    public GameObject colorPanel;

    public GameObject goddess;
    public GameObject goddess_color;
    public GameObject player;
    bool isBowed;

    public GameObject restart;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(head.activeSelf&&coat.activeSelf&&dress.activeSelf&&shawl.activeSelf)
        {
            anim.SetBool("isComplete", true);
            StartCoroutine("Bow");
        }
        if (goddess_color.activeSelf)
        {
            Invoke("idleAnime", 1);
            player.GetComponent<Animator>().SetBool("isBow", true);
            isBowed = true;
        }

        if (isBowed)
        {
            Invoke("idlePlayer", 1);
            restart.SetActive(true);
        }

    }

    public void CloseTab()
    {
        anim.SetBool("isOn", false);
    }

    public void idleAnime()
    {
        goddess_color.GetComponent<Animator>().SetBool("isBow", false); 

    }

    IEnumerator Bow()
    {
        yield return new WaitForSeconds(3);
        goddess.SetActive(false);
        goddess_color.SetActive(true);
    }

    public void idlePlayer()
    {
        player.GetComponent<Animator>().SetBool("isBow", false);
       // CancelInvoke();
        isBowed = false;
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

}
