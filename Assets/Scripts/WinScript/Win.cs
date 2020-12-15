using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{

    public GameObject won1;
    public GameObject won2;

    // Start is called before the first frame update
    void Start()
    {
        won1 = GameObject.FindGameObjectWithTag("Win1");
        //won2 = GameObject.FindGameObjectWithTag("Win2");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("backspace"))
        {
            SceneManager.LoadScene(0);
            won1.gameObject.SetActive(false);
            //won2.gameObject.SetActive(false);
        }
    }
}
