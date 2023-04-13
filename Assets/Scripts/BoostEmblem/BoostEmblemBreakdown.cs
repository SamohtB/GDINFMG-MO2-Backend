using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BoostEmblemBreakdown : MonoBehaviour
{
    [Header("Emblem DetailedInfo")]
    [SerializeField] private Image emblemImage;
    [SerializeField] private TextMeshProUGUI stats1Txt;
    [SerializeField] private TextMeshProUGUI stats2Txt;

    public void OnRegisterName(Dictionary<string, object> HeldItemData)
    {

        if (HeldItemData == null)
            Debug.LogError("No HeldItem Data");
        else
        {
            //Use Singleton Pattern to create find the image,
            string heldItemName = "";

            //Change the image
            emblemImage.sprite = null;

            //Alter the stats
            OnCheckValue(stats1Txt, "", 0f);
            OnCheckValue(stats2Txt, "", 0f);


            //stats1Txt.text = "";
            //stats2Txt.text = "";
        }

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
