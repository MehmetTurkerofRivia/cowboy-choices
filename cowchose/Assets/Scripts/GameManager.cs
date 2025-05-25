using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int money = 0;
    public static int honor = 0;
    void Start()
    {
        
    }
    void Update()
    {
        if (honor>=100)
            honor = 100;

        if (honor<=0)
            honor = 0;
    }

    public void honorupdate()
    {
        honor += 5;
    }

    public void honordecrase()
    {
        honor -= 5;
    }
    
}
