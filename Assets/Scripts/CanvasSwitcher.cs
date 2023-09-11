using UnityEngine;

public class CanvasSwitcher : MonoBehaviour
{
    public GameObject canvas1;
    public GameObject canvas2;

    public void SwitchToCanvas2()
    {
        canvas1.SetActive(false);
        canvas2.SetActive(true);
    }
    public void SwitchToCanvas1()
    {
        canvas2.SetActive(false);
        canvas1.SetActive(true);
    }
}

