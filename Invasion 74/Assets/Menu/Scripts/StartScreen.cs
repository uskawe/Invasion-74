using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem; 

public class StartScreen : MonoBehaviour
{
    [Header("Referências")]
    public CanvasGroup fadeGroup;
    public TMP_Text pressAnyKeyText;

    [Header("Configurações")]
    public float fadeDuration = 1f;
    public string nextSceneName = "MainMenu";

    private bool isWaitingForInput = false;

    void Start()
    {
        fadeGroup.alpha = 1;
        StartCoroutine(FadeIn());
    }

    void Update()
    {
        if (isWaitingForInput && Keyboard.current.anyKey.wasPressedThisFrame)
        {
            StartCoroutine(FadeOutAndLoadNextScene());
        }
    }

    private System.Collections.IEnumerator FadeIn()
    {
        float t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            fadeGroup.alpha = 1 - (t / fadeDuration);
            yield return null;
        }

        fadeGroup.alpha = 0;
        pressAnyKeyText.gameObject.SetActive(true);
        isWaitingForInput = true;
    }

    private System.Collections.IEnumerator FadeOutAndLoadNextScene()
    {
        isWaitingForInput = false;

        float t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            fadeGroup.alpha = t / fadeDuration;
            yield return null;
        }

        fadeGroup.alpha = 1;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        SceneManager.LoadScene(nextSceneName);
    }
}
