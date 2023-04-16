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

    [Header("Item Data")]
    [SerializeField] private ItemRequest itemRequest;
    

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
        StartCoroutine(pokemonAll.GetAllPokemon());
        StartCoroutine(itemRequest.RetrieveAllItems());
        //itemRequest.LoadAll();

        //StartCoroutine(itemRequest.RetrieveBattleItem(2, true));
    }

    public void FindSpecificPokemon(int pokemonID)
    {
        StartCoroutine(pokemonSpecific.GetOnePokemon(pokemonID));
    }

    public void FindSpecificBattleItem(int battleId)
    {
        StartCoroutine(itemRequest.RetrieveBattleItem(battleId));
    }

    public void FindSpecificHeld(int heldId)
    {
        StartCoroutine(itemRequest.RetrieveHeldItemm(heldId));
    }
}
