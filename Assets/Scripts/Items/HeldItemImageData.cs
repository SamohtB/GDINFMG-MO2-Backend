using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeldItemImageData : MonoBehaviour
{
    [SerializeField] private string heldItemName;


    public void OnRegisterName(string name)
    {
        heldItemName = name;
        if (this.gameObject.GetComponent<Image>() == null)
            Debug.LogError("No Image Component Found");

        else
        {
            this.gameObject.GetComponent<Image>().sprite = HeldImageManager.Instance.RetrieveSprite(name);
        }
    }


    //For Event Trigger Point Click
    public void OnClickHeldDetail()
    {
        //Do WebRequest which is IEnumerator

        //Do SomeSinglePattern that reference the pokemon name
        MainUIBehaviour.instance.OnSwitchHeldItemDetail();
    }
}
