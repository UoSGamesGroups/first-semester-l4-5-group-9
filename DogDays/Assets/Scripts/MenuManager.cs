using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


public class MenuManager : MonoBehaviour 
{
    public Canvas QuitMenu;
    public Button StartText;
    public Button ExitText;

    void Start () 
    {
        QuitMenu.enabled = false;       // quit menu false to prevent appearing on game load

        QuitMenu = QuitMenu.GetComponent<Canvas>();
        StartText = StartText.GetComponent<Button>();
        ExitText = ExitText.GetComponent<Button>();
               
    }

    public void ExitPress() 
    {
        QuitMenu.enabled = true;
        StartText.enabled = false;
        ExitText.enabled = false;
    }

    public void NoPress() {
        QuitMenu.enabled = false;
        StartText.enabled = true;
        ExitText.enabled = true;
    }

    public void StartLevel() 
    {
        SceneManager.LoadScene(3);
    }

    public void StartInstructions() 
    {
        SceneManager.LoadScene(1);
    }

    public void ReturnToMainMenu() 
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame() 
    {
        Application.Quit();
    }

}