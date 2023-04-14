using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BuildData : MonoBehaviour
{
    [Header("Pokemon Base")]
    [SerializeField] private Image pokemonImage;
    [SerializeField] private TextMeshProUGUI pokemonName;

    [Header("BuildInfomration")]
    [SerializeField] private TextMeshProUGUI buildName;
    [SerializeField] private TextMeshProUGUI skillName1;
    [SerializeField] private TextMeshProUGUI skillName2;

    [Header("Item Information")]
    [SerializeField] private HeldItemImageData hItem1;
    [SerializeField] private HeldItemImageData hItem2;
    [SerializeField] private HeldItemImageData hItem3;
    [SerializeField] private BattleItemImageData bItem1;

    [Header("Emblem Information")]
    [SerializeField] private List<GameObject> data; //Create Another Emblem Class
    [SerializeField] private List<GameObject> data2;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    

}
