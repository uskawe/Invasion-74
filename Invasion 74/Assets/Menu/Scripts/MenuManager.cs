using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Scenes")]
    [SerializeField] private string gameLevelName; 

    public void OnPlayButtonPressed()
    {
        SceneManager.LoadScene(gameLevelName);
    }

    public void OnQuitButtonPressed()
    {
        Application.Quit();
        Debug.Log("Quit button pressed, only works in build.");
    }
}
