using UnityEngine;
using TMPro;


public class MoneyManager : MonoBehaviour
{
    public TextMeshProUGUI paraText;

    void Update()
    {
        paraText.text = GameManager.money.ToString() + " $";
    }
}
