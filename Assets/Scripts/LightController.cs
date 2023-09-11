using UnityEngine;

public class LightController : MonoBehaviour
{
    public float dimSpeed = 1.0f; // Заданная скорость уменьшения intensity

    private Light lightComponent;
    private float initialIntensity;
    private UIController uiController;

    private void Start()
    {
        lightComponent = GetComponent<Light>();
        initialIntensity = lightComponent.intensity;
        uiController = GameObject.FindObjectOfType<UIController>();
    }

    private void Update()
    {
        if (lightComponent.intensity > 0.3f)
        {
            // Уменьшаем intensity света с заданной скоростью
            float newIntensity = Mathf.MoveTowards(lightComponent.intensity, 0f, dimSpeed * Time.deltaTime);
            lightComponent.intensity = newIntensity;
        }
        else
        {
            uiController.ShowCanvasWithTexts();
        }
    }

    public void ResetIntensity()
    {
        // Этот метод позволяет сбросить intensity света до начального значения
        lightComponent.intensity = initialIntensity;
    }
}
