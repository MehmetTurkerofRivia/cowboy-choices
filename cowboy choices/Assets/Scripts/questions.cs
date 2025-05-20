using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "questions", menuName = "Scriptable Objects/questions")]
public class questions : ScriptableObject
{
    public string text;
    public int inc1;
    public int inc2;
    public int dec1;
    public int dec2;

    public int inc3;
    public int dec3;
    public int inc4;
    public int dec4;

    public void doit()
    {
        GameManager.money +=inc1;
        GameManager.honor +=inc2;

        GameManager.money -=dec1;
        GameManager.honor -=dec2;
    }

    public void doit2()
    {
        GameManager.money += inc3;
        GameManager.honor += inc4;

        GameManager.money -= dec3;
        GameManager.honor -= dec4;
    }
}
