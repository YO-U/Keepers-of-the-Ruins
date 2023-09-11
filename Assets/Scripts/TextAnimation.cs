using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class TextAnimation : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public TextMeshProUGUI textComponent;
    public float fadeDuration = 0.5f;
    public string customText = "Sample Text";
    [SerializeField] private int customNumber = 0;
    public GameObject triggerToActivate;

    private void Start()
    {
        canvasGroup.alpha = 0f;
        triggerToActivate.SetActive(false);
    }

   public void Starting()
   {
       customNumber++;
       if (customNumber == 5)
       {
           customText = "УБЕГИ ОТСЮДА!";
           triggerToActivate.SetActive(true);
       }
       else
       {
           triggerToActivate.SetActive(false);
       }
        StartCoroutine(ShowText());
    }

    private IEnumerator ShowText()
    {
        // Появление Canvas
        while (canvasGroup.alpha < 1f)
        {
            canvasGroup.alpha += Time.deltaTime / fadeDuration;
            yield return null;
        }
        canvasGroup.alpha = 1f;

        // Появление текста по буквам
        textComponent.text = "";
        for (int i = 0; i < customText.Length; i++)
        {
            textComponent.text += customText[i];
            yield return new WaitForSeconds(0.1f); // Задержка между появлением букв
        }

        // Вывод числа
        if (customNumber != 5)
        {
            textComponent.text += " " + customNumber;
        }

        // Исчезновение текста по буквам
        yield return new WaitForSeconds(2f); // Задержка перед исчезновением текста
        textComponent.text = "";
        for (int i = 0; i < customText.Length; i++)
        {
            textComponent.text += " ";
            yield return new WaitForSeconds(0.1f); // Задержка между исчезновением букв
        }

        // Исчезновение Canvas
        while (canvasGroup.alpha > 0f)
        {
            canvasGroup.alpha -= Time.deltaTime / fadeDuration;
            yield return null;
        }
        canvasGroup.alpha = 0f;
    }
}

