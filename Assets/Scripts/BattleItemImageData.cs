using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleItemImageData : MonoBehaviour
{
    [SerializeField] private string battleItemName;


    public void OnRegisterName(string name)
    {
        battleItemName = name;
    }


    //For Event Trigger Point Click
    public void OnClick()
    {
        //Do SomeSinglePattern that reference the pokemon name
    }
}