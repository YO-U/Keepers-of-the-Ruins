using UnityEngine;

public class CanvasTrigger : MonoBehaviour
{
    public GameObject canvasToShow; // Привязываем сюда Canvas, который должен появиться на экране
    private bool ch = false;
    private CanvasGroup canvasGroup; // Ссылка на компонент CanvasGroup

    private void Start()
    {
        canvasGroup = canvasToShow.GetComponent<CanvasGroup>(); // Получаем ссылку на компонент CanvasGroup при старте объекта
    }

    private void Update()
    {
        if (ch)
        {
            //canvasToShow.SetActive(true);
            StartCoroutine(FadeInCanvas()); // Запускаем корутину на плавное появление Canvas'а
            Time.timeScale = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            ch = true;
        }
    }

    private System.Collections.IEnumerator FadeInCanvas()
    {
        float duration = 1f; // Длительность анимации появления Canvas'а (в секундах)
        float startAlpha = 0f; // Начальное значение альфа-канала (0 - полностью прозрачный)
        float targetAlpha = 1f; // Целевое значение альфа-канала (1 - полностью непрозрачный)
        float currentTime = 0f;

        canvasToShow.SetActive(true); // Включаем Canvas перед началом анимации
        canvasGroup.alpha = startAlpha; // Устанавливаем начальное значение альфа-канала

        while (currentTime < duration)
        {
            currentTime += Time.unscaledDeltaTime; // Учитываем время вне зависимости от установленной шкалы времени
            float alphaValue = Mathf.Lerp(startAlpha, targetAlpha, currentTime / duration);
            canvasGroup.alpha = alphaValue;
            yield return null;
        }

        canvasGroup.alpha = targetAlpha; // Убеждаемся, что альфа-канал установлен в целевое значение после завершения анимации
    }
}

