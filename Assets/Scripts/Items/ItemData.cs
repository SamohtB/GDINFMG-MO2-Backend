using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Text;


public class ItemData : MonoBehaviour
{
    [Header("Option")]
    [SerializeField] private TMP_Dropdown heldItemFilter;

    [Header("Spawn Pokemon Reference")]
    [SerializeField] private GameObject spawnHeldLocation;
    [SerializeField] private GameObject spawnBattleLocation;
    [SerializeField] private GameObject spawnableHeldImage;
    [SerializeField] private GameObject spawnableBattleImage;

    [Header("Navigation Reference")]
    [SerializeField] private GameObject heldDetailedRefrence;
    [SerializeField] private GameObject battleDetailedRefrence;

    private List<GameObject> heldItemHolder;
    private List<GameObject> battleItemHolder;

    // Start is called before the first frame update
    void Start()
    {
        heldItemHolder = new List<GameObject>();
        battleItemHolder = new List<GameObject>();

        //Spawn Everything during run time;

        SpawnDefault();
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
        //Call Held Item
        //Call

    }

    private void SpawnHeldParameters(string pokemonName)
    {
        GameObject copy = Instantiate(spawnableHeldImage);

        if (copy.GetComponent<HeldItemImageData>() == null)
            Debug.LogError("Missing Held Item Data Component");
        else
            copy.GetComponent<HeldItemImageData>().OnRegisterName(pokemonName);

        copy.transform.SetParent(spawnHeldLocation.transform, false);
        heldItemHolder.Add(copy);
    }

    private void SpawnBattleParameters(string pokemonName)
    {
        GameObject copy = Instantiate(spawnableBattleImage);

        if (copy.GetComponent<BattleItemImageData>() == null)
            Debug.LogError("Missing  Battle Item Data Component");
        else
            copy.GetComponent<BattleItemImageData>().OnRegisterName(pokemonName);

        copy.transform.SetParent(spawnHeldLocation.transform, false);
        heldItemHolder.Add(copy);
    }



    public void DeleteAllHeldItem()
    {
        foreach (GameObject pokemon in heldItemHolder)
        {
            Destroy(pokemon);
        }

        heldItemHolder.Clear();
        Debug.Log($"Pokemon Size after deleting all: {heldItemHolder.Count}");
    }

    //Spawn Specifics
    
    public void SpawnHeldItems(List<Dictionary<string, object>> spawnData)
    {
        
        foreach (Dictionary<string, object> heldItem in spawnData) 
        {
            //Call the spawning function
            if (heldItem[""] == null)
                Debug.LogError("Missing Held Item Data");

            else
            {
                SpawnHeldParameters(System.Convert.ToString(heldItem[""])); //Spawn Tag
            }

           
        }
    }

    public void SpawnBattleItems(List<Dictionary<string, object>> spawnData)
    {

        foreach (Dictionary<string, object> battleItem in spawnData)
        {
            //Call the spawning function
            if (battleItem[""] == null)
                Debug.LogError("Missing Held Item Data");

            else
            {
                SpawnBattleParameters(System.Convert.ToString(battleItem[""])); //Spawn Tag
            }
        }
    }
}
