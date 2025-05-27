using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "questions", menuName = "Scriptable Objects/questions")]
public class questions : ScriptableObject
{
    public string description;
    public int change_do_it_money;
    public int change_do_it_honor;

    public int change_dont_money;
    public int change_dont_honor;
    public void doit()
    {
        GameManager.money += change_do_it_money;
        GameManager.honor += change_do_it_honor;
    }
    public void doit2()
    {
        GameManager.money += change_dont_money;
        GameManager.honor += change_dont_honor;
    }
}
