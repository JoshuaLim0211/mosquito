using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlaceInteraction : MonoBehaviour
{
    private bool isAgt;
    private bool isFly;


    public GameObject AgtPanel;
    private void Start()
    {
        isAgt = false;
        isFly = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Agt")
        {
            isAgt = true;
        }
        else if (collision.gameObject.tag == "Fly")
        {
            isFly = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isAgt = false;
        AgtPanel.SetActive(false);

        isFly = false;
    }
    void Update()
    {
        if (isAgt == true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                AgtPanel.SetActive(true);

            }
        }
        if (isFly == true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {

                SceneManager.LoadScene("Game");
            }
        }

    }
}
