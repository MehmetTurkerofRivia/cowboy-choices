using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI descript;
    [SerializeField] private Button b1;
    [SerializeField] private Button b2;
    public List<questions> quest;

    private questions rastgeleSoru;

    void Start()
    {
        YeniSoru();
    }
        public void YeniSoru()
    {
        rastgeleSoru = quest[Random.Range(0, quest.Count)];
        descript.text = rastgeleSoru.description;
    }
}
