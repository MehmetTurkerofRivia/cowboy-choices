using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class KarakterListesi : MonoBehaviour

{
    [SerializeField] TextMeshPro descript;
    public List<questions> quest;

    public void chosing()
    {
        questions rastgeleSoru = quest[Random.Range(0, quest.Count)];
        descript.text = rastgeleSoru.description;
    }


}

