using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class BoostEmblemData : MonoBehaviour
{
    [Header("Main")]
    [SerializeField] private Dropdown colorFilter;
    [SerializeField] private Dropdown attribTypeFilter;
    [SerializeField] private Dropdown tierFilter;

    [SerializeField] private GameObject EmblemList;


    [Header("Navigation")]
    //Displayer
    [SerializeField] private GameObject showcaseHeader;
    [SerializeField] private GameObject emblemShowCase;

    //Loadout
    [SerializeField] private GameObject loadoutHeader;
    [SerializeField] private GameObject EmblemLoadOut;

    [Header("Reference")]
    [SerializeField] private GameObject spawnData;
    [SerializeField] private GameObject spawnHeldLocation;

    private List<GameObject> spawnEmblemList;
    




    // Start is called before the first frame update
    void Start()
    {
        spawnEmblemList = new List<GameObject>();
    }

    //Everytime a new a change in filter has been made;
    public void OnFilterChange()
    {
        //attackStyleFilter.AddOptions()
    }

    //Default Spawning
    public void SpawnDefault()
    {
        //Todo: Unity Web Request handling for default image

        //Call Boost Emblem
        //Call

    }

    private void SpawnEmblemParameters(string pokemonName)
    {
        GameObject copy = Instantiate(spawnData);

        if (copy.GetComponent<HeldItemImageData>() == null)
            Debug.LogError("Missing Emblems Item Data Component");
        else
            copy.GetComponent<HeldItemImageData>().OnRegisterName(pokemonName);

        copy.transform.SetParent(spawnHeldLocation.transform, false);
        spawnEmblemList.Add(copy);
    }

    public void DeleteAllHeldItem()
    {
        foreach (GameObject heldItem in spawnEmblemList)
        {
            Destroy(heldItem);
        }

        spawnEmblemList.Clear();
        Debug.Log($"Boost Emblem Size after deleting all: {spawnEmblemList.Count}");
    }

    //Spawn Specifics

    public void SpawnEmblem(List<Dictionary<string, object>> spawnData)
    {
        foreach (Dictionary<string, object> boostItem in spawnData)
        {
            //Call the spawning function
            if (boostItem[""] == null)
                Debug.LogError("Missing Boost Item Data");

            else
            {
                SpawnEmblemParameters(System.Convert.ToString(boostItem[""])); //Spawn Tag
            }

        }
    }


    


}
