using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleItemImageData : MonoBehaviour
{
    [SerializeField] private string battleItemName;


    public void OnRegisterName(string name)
    {
        battleItemName = name;
        if (this.gameObject.GetComponent<Image>() == null)
            Debug.LogError("No Image Component Found");

        else
        {
            this.gameObject.GetComponent<Image>().sprite = BattleImageManager.Instance.RetrieveSprite(name);
        }
                
    }


    //For Event Trigger Point Click
    public void OnClickBattleDetail()
    {

        //Do Web Request

        //Do SomeSinglePattern that reference the pokemon name
        MainUIBehaviour.instance.OnSwitchBattleItemDetail();
    }
}
