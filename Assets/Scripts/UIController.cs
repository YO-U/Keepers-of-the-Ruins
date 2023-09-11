using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Canvas canvas;
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;

    public float fadeDuration = 1f;
    public float delayBetweenTexts = 1f;

    private void Start()
    {
        // Скрываем тексты и делаем канвас прозрачным изначально
        canvas.enabled = false;
        text1.color = Color.clear;
        text2.color = Color.clear;
        text3.color = Color.clear;
    }

    public void ShowCanvasWithTexts()
    {

        StartCoroutine(FadeCanvasInAndShowTexts());
    }

    private IEnumerator FadeCanvasInAndShowTexts()
    {
        Cursor.visible = true;
        // Плавно делаем канвас видимым
        canvas.enabled = true;
        float timer = 0f;
        while (timer < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            text1.color = new Color(text1.color.r, text1.color.g, text1.color.b, alpha);
            yield return null;
            timer += Time.deltaTime;
        }

        // Задержка перед появлением первого текста
        yield return new WaitForSeconds(delayBetweenTexts);

        // Появление первого текста
        text1.color = Color.white;

        // Задержка перед появлением второго текста
        yield return new WaitForSeconds(delayBetweenTexts);

        // Появление второго текста
        text2.color = Color.white;


        // Появление второго текста
        for (int i = 0; i > -1; i++)
        {
            yield return new WaitForSeconds(delayBetweenTexts);
            text3.color = Color.white;
            yield return new WaitForSeconds(delayBetweenTexts);
            text3.color = Color.clear; // Исчезновение текста
        }

    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    

}

