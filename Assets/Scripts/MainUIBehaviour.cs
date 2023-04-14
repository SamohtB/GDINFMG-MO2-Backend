using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;

public class MainUIBehaviour : MonoBehaviour
{
    public static MainUIBehaviour instance;


    [Header("Tab Section")]
    //Pokemon Section
    [SerializeField] private GameObject pokemonOverviewTab;
    [SerializeField] private GameObject pokemonDetailsTab;

    //Pokemon Details
    [SerializeField] private GameObject itemOverviewTab;
    [SerializeField] private GameObject heldItemsDetailedTab;
    [SerializeField] private GameObject battleItemsDetailedTab;

    //Boost Emblem 
    [SerializeField] private GameObject boostEmblemTab;

    //Extra
    [SerializeField] private GameObject buildTab;
    [SerializeField] private GameObject damageTab;

    [Header("Navigation Section")]
    [SerializeField] private GameObject popUpTab;
    



    [Header("Prefab Holder")]
    [SerializeField] private GameObject pokemonSpawnData;

    private GameObject activeTab;

    private void Awake()
    {
        CreateSingleton();
    }

    void CreateSingleton()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        //DontDestroyOnLoad(gameObject);
    }


    private void Start()
    {
        activeTab = pokemonOverviewTab;
        DisableAllTab(); //Double Checking
        activeTab.SetActive(true);
        //Some Function To Call all default Data; from all tab;
    }


    //Navigation
    public void DisableAllTab()
    {
        //Pokemon
        pokemonOverviewTab.SetActive(false);
        pokemonDetailsTab.SetActive(false);

        //Item
        itemOverviewTab.SetActive(false);
        heldItemsDetailedTab.SetActive(false);
        battleItemsDetailedTab.SetActive(false);

        //Emblem
        boostEmblemTab.SetActive(false); 

        //Build
        buildTab.SetActive(false);

        //Calculator
        damageTab.SetActive(false);
    }

    public void OnPressPopUp()
    {
        popUpTab.SetActive(!popUpTab.activeSelf);   
    }


    //Switching Tab via popUp

    public void OnSwitchPokemonSection()
    {
        activeTab = pokemonOverviewTab;
        DisableAllTab();
        activeTab.SetActive(true);
    }

    public void OnSwitchItemSection()
    {
        activeTab = itemOverviewTab;
        DisableAllTab();
        activeTab.SetActive(true);
    }

    public void OnSwitchEmblemSection()
    {
        activeTab = boostEmblemTab;
        DisableAllTab();
        activeTab.SetActive(true);
    }

    public void OnSwitchBuild()
    {
        activeTab = buildTab;
        DisableAllTab();
        activeTab.SetActive(true);
    }

    public void OnSwitchDamageCalculator()
    {
        activeTab = damageTab;
        DisableAllTab();
        activeTab.SetActive(true);
    }

    //=============================== Detail Section ========================///
    //Pokemon Section

    public void OnSwitchPokemonDetail()
    {
        activeTab = pokemonDetailsTab;
        DisableAllTab();
        activeTab.SetActive(true);
    }


    //Held Item Section
    public void OnSwitchHeldItemDetail()
    {
        activeTab = heldItemsDetailedTab;
        DisableAllTab();
        activeTab.SetActive(true);
    }

    public void OnSwitchBattleItemDetail()
    {
        activeTab = battleItemsDetailedTab;
        DisableAllTab();
        activeTab.SetActive(true);
    }






    //Special Switching
    public void SwitchSection (GameObject fromTab, GameObject toTab) 
    {
        fromTab.SetActive(false);
        toTab.SetActive(true);
    }
    

}
