using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostEmblemImageData : MonoBehaviour
{
    [SerializeField] private string boostEmblemName;


    public void OnRegisterName(string name)
    {
        boostEmblemName = name;
        if (this.gameObject.GetComponent<Image>() == null)
            Debug.LogError("No Image Component Found");

        else
        {
            this.gameObject.GetComponent<Image>().sprite = EmblemImageManager.Instance.RetrieveSprite(name);
        }
    }


    //For Event Trigger Point Click
    public void OnSelectItemData()
    {
        //Activate the Web Request for three kinds of image

    }


}
