using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public Button previousButton;
    public Button nextButton;
    public Text explanation0;
    public Text explanation1;
    public Text explanation2;
    private int explanationNum;
    
    public void Start()
    {
        explanationNum = 0;
    }

    // Starting the game.
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Quit the game.
    public void QuitGame()
    {
        Application.Quit();
    }

    // Switching to the next brief explanation.
    public void ToNextExplanation()
    {
        if (explanationNum == 0)
        {
            explanationNum = 1;
            explanation0.gameObject.SetActive(false);
            explanation1.gameObject.SetActive(true);
            previousButton.gameObject.SetActive(true);
            return;
        }
        if (explanationNum == 1)
        {
            explanationNum = 2;
            explanation1.gameObject.SetActive(false);
            explanation2.gameObject.SetActive(true);
            nextButton.gameObject.SetActive(false);
            return;
        }
        else
        {
            return;
        }
    }

    // Switching to the next brief explanation.
    public void ToPreviousExplanation()
    {
        if (explanationNum == 1)
        {
            explanationNum = 0;
            explanation1.gameObject.SetActive(false);
            explanation0.gameObject.SetActive(true);
            previousButton.gameObject.SetActive(false);
            return;
        }
        if (explanationNum == 2)
        {
            explanationNum = 1;
            explanation2.gameObject.SetActive(false);
            explanation1.gameObject.SetActive(true);
            nextButton.gameObject.SetActive(true);
            return;
        }
        else
        {
            return;
        }
    }
}
