using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Text;

public class BoostEmblemBreakdown : MonoBehaviour
{
    [Header("Emblem DetailedInfo")]
    [SerializeField] private Image emblemImage;
    [SerializeField] private TextMeshProUGUI stats1Txt;
    [SerializeField] private TextMeshProUGUI stats2Txt;

    private string name = "";

    public void OnRegisterName(string boostEmblemName)
    {

        if (boostEmblemName == "")
            Debug.LogError("No HeldItem Name");
        else
        {
            //Use Singleton Pattern to create find the image,
             name = boostEmblemName;

            //Change the image
            emblemImage.sprite = EmblemImageManager.Instance.RetrieveSprite(boostEmblemName);
        }

    }

    public void OnUpdateValue(Dictionary<string, object> HeldItemData)
    {
        if (HeldItemData == null)
            Debug.LogError("No HeldItem Item");
        else
        {
            //Alter the stats
            OnCheckValue(stats1Txt, HeldItemData["AttribType"].ToString(), (float)System.Convert.ToDouble(HeldItemData["data"]));
            OnCheckValue(stats2Txt, HeldItemData["AttribType"].ToString(), (float)System.Convert.ToDouble(HeldItemData["data"]));

        }
        //stats1Txt.text = "";
        //stats2Txt.text = "";
    }

    private void OnCheckValue(TextMeshProUGUI dataLabel, string dataType, float data)
    {
        if (data > 0)
            dataLabel.color = Color.green;

        else
            dataLabel.color = Color.red;

        dataLabel.text = dataType + ": " + data.ToString();
    }


    //For Event Trigger Point Click
    public void OnClick()
    {
        //Do SomeSinglePattern that reference the pokemon name
    }

}
