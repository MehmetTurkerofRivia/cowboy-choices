using UnityEngine;
using UnityEngine.UI;

public class HonorSlider : MonoBehaviour
{
    public Slider slider;
    void Update()
    {
        slider.value = (GameManager.honor) / 100f;
    }

    public void increaseHonor()
    {
        GameManager.honor += 5;
    }

    public void decreaseHonor()
    {
        GameManager.honor -= 5;
    }
}
