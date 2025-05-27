using UnityEngine;
using TMPro;


public class MoneyManager : MonoBehaviour
{
    public TextMeshProUGUI moneyText;

    void Update()
    {
        moneyText.text = GameManager.money.ToString() + " $";

        if (GameManager.money < 60)
            moneyText.color = Color.darkRed;
        else
            moneyText.color = Color.white;
    }
}
