using UnityEngine;
using UnityEngine.UI;

public class HonorSlider : MonoBehaviour
{
    public Slider slider;
    void Update()
    {
        slider.value = (GameManager.honor) / 100f;
    }
}
