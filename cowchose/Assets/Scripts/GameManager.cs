using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int money = 50;
    public static int honor = 50;
    void Update()
    {
        if (honor>=100)
            honor = 100;

        if (honor<=0)
            honor = 0;
    }    
}
