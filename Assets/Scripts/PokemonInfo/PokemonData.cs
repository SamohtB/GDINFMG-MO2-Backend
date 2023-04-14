using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;

public class PokemonData : MonoBehaviour
{
    [Header("Option")]
    [SerializeField] private TMP_Dropdown attackStyleFilter;
    [SerializeField] private TMP_Dropdown attackTypeFilter;
    [SerializeField] private TMP_Dropdown roleFilter;
    [SerializeField] private TMP_Dropdown complexityFilter;

    [Header("Spawn Pokemon Reference")]
    [SerializeField] private GameObject spawnLocation;
    [SerializeField] private GameObject spawnableImage;

    [Header("Navigation Reference")]
    [SerializeField] private GameObject pokemonDetailedRefrence;


    private List<GameObject> pokemonListSpawn;



    
    // Start is called before the first frame update
    void Start()
    {
        pokemonListSpawn = new List<GameObject>();   
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
        Dictionary<int, string> allPokemon = PokemonImageManager.Instance.RetrieveAllData();
        List<int> allPokemonId = PokemonImageManager.Instance.RetrieveAllId();
        foreach(int pokemonID in allPokemonId)
        {
            SpawnParameters( PokemonImageManager.Instance.RetrievePokemonName(pokemonID));
        }

    }

    private void SpawnParameters(string pokemonName)
    {
        GameObject copy = Instantiate(spawnableImage);

        if (copy.GetComponent<PokemonImageData>() == null)
            Debug.LogError("Missing Pokemon Image Data Component");
        else
            copy.GetComponent<PokemonImageData>().OnRegisterName(pokemonName);

        copy.transform.SetParent(spawnLocation.transform, false);
        pokemonListSpawn.Add(copy);
    }

    public void DeleteAllPokemon()
    {
        foreach(GameObject pokemon in pokemonListSpawn)
        {
            Destroy(pokemon);
        }

        pokemonListSpawn.Clear();
        Debug.Log($"Pokemon Size after deleting all: {pokemonListSpawn.Count}");
    }


}
