using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalWebAPI : MonoBehaviour
{
    public static UniversalWebAPI Instance
    {
        get; private set;
    }

    [Header("Pokemon Section")]
    [SerializeField] private WebAPI pokemonAll;
    [SerializeField] private One_Pokemon pokemonSpecific;

    private void Awake()
    {
        CreateSingleton();
    }

    void CreateSingleton()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void FindSpecificPokemon(int pokemonID)
    {
        StartCoroutine(pokemonSpecific.GetOnePokemon(pokemonID));
    }
}
