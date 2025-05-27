using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingManager : MonoBehaviour
{
    [SerializeField] private GameObject maingame;
    [SerializeField] private GameObject HonorEnding;
    [SerializeField] private GameObject MoneyEnding;


    public void Restart()
    {
        GameManager.honor = 50;
        GameManager.money = 50;
        SceneManager.LoadScene(0);
    }

    public void Update()
    {
        if (GameManager.honor<=0)
        {
            maingame.SetActive(false);
            HonorEnding.SetActive(true);
        }
        if (GameManager.money<=0)
        {
            maingame.SetActive(false);
            MoneyEnding.SetActive(true);
        }
    }
}
