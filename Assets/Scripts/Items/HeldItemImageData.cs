using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeldItemImageData : MonoBehaviour
{
    [SerializeField] private string heldItemName;


    public void OnRegisterName(string name)
    {
        heldItemName = name;
    }


    //For Event Trigger Point Click
    public void OnClickHeldDetail()
    {
        //Do WebRequest which is IEnumerator

        //Do SomeSinglePattern that reference the pokemon name
        MainUIBehaviour.instance.OnSwitchHeldItemDetail();
    }
}
