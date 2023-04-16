using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Text;

public class Item_Data_Full {

    public List<List<BItemOverview>> battleitems;
    //public List<List<ColumnDefinition>> ?colDef1;
    public List<List<HItemOverview>> helditems;
    //public List<List<ColumnDefinition>> ?colDef2;
}


public class BItem
{
    public List<BItemOverview> bItem;
    public List<ColumnDefinition> colDef;
}

public class BItemOverview
{
    public int battleid;
    public SpriteData sprite = null;
    public string name;
}

public class HItem
{
    public List<HItemOverview> hItem;
    public List<ColumnDefinition> colDef;
}

public class HItemOverview
{
    public int heldid;
    public SpriteData sprite = null;
    public string name;
}


//Battle Item Specifics
public class Battle_Item_Full{
    public List<List<Battle_Item_Specific>> battleitem; 
}


public class Battle_Item_Specific
{
    public int battleid;
    public string name;
    public SpriteData? sprite;
    public float cooldown;
    public string description;
}

//Held Item Specifics
public class Held_Item_Full
{
  public  List<List<Held_Item_Specific>> helditem;
}

public class Held_Item_Specific
{
    public int heldid;
    public string name;
    public SpriteData? sprite;
    public string tierattributeType;
    public float tier1val;
    public float tier10val;
    public float tier20val;
    public string attrib1type;
    public float attrib1val;
    public string? attrib2type;
    public float? attrib2val;
    public string description;

}


public class ItemRequest : MonoBehaviour
{
    [SerializeField] private BattleItemDetailedInfo battleDetailedInfo;
    [SerializeField] private HeldItemDetailedInfo heldDetailedInfo;
    [SerializeField] private ItemData itemData;

    public string BaseURL
    {
        get
        {
            //return "https://gdinfmg-pokemon-db.onrender.com";
            return "localhost:3000";
        }
    }

    private void Start()
    {
        StartCoroutine(RetrieveBattleItem(5));
        //StartCoroutine(RetrieveHeldItemm(2));
    }

    public void LoadAll()
    {
        //for (int i = 0; i < 1; i++)
        //{
        //    StartCoroutine(RetrieveBattleItem(i + 1, false));
        //}
    }

    //Pre-Loading
    public IEnumerator RetrieveAllItems()
    {
        // Debug.Log("name: " + val.ToString());
        Dictionary<string, object> charaterData = new Dictionary<string, object>();
        //Dictionary<string, Dictionary<string, object>> battleData;
        using (UnityWebRequest request = new UnityWebRequest(BaseURL + $"/Items", "GET"))
        {
            //Debug.Log((BaseURL + $"/{level.ToString()}"));
            request.downloadHandler = new DownloadHandlerBuffer();

            Debug.Log("Sending got request.....");
            Debug.Log($"Request Link: {request.url}");
            yield return request.SendWebRequest();

            Debug.Log($"Get all players response code: {request.responseCode}");

            //Check if have errors;
            if (string.IsNullOrEmpty(request.error))
            {
                Debug.Log($"Message: {request.downloadHandler.text}");

                 //Query_List = new Item_Data_Full();
                Item_Data_Full Query_List = JsonConvert.
                    DeserializeObject<Item_Data_Full> (request.downloadHandler.text);

                //Debug.Log($"name: {Query_List.battleitems[0][0].name}");
                //Debug.Log($"id: {Query_List.battleitems[0][0].battleid}");

                foreach (BItemOverview bItem in Query_List.battleitems[0])
                {
                    BattleImageManager.Instance.RegisterDictionary(bItem.battleid, bItem.name);
                }
                foreach (HItemOverview hItem in Query_List.helditems[0])
                {
                    HeldImageManager.Instance.RegisterDictionary(hItem.heldid, hItem.name);
                }

                itemData.SpawnBattleItems();
                itemData.SpawnHeldItems();
            }

            //If No Data Found
            else
            {
                Debug.LogWarning("Empty");
            }

            //Debug.LogWarning("done Processing");

        }

        //throw new NotImplementedException();
        yield return null;
    }


    public IEnumerator RetrieveBattleItem(int id)
    {
        // Debug.Log("name: " + val.ToString());
        //Dictionary<string, object> charaterData = new Dictionary<string, object>();
        Dictionary<string, Dictionary<string, object>> battleData;
        using (UnityWebRequest request = new UnityWebRequest(BaseURL + $"/Items/Battle/{id.ToString()}", "GET"))
        {
            //Debug.Log((BaseURL + $"/{level.ToString()}"));
            request.downloadHandler = new DownloadHandlerBuffer();

            Debug.Log("Sending got request.....");
            Debug.Log($"Request Link: {request.url}");
            yield return new WaitForSeconds(0.4f);
            yield return request.SendWebRequest();

            Debug.Log($"Get all players response code: {request.responseCode}");

            //Check if have errors;
            if (string.IsNullOrEmpty(request.error))
            {
                //Debug.Log($"Message: {request.downloadHandler.text}");

                Battle_Item_Full Query_List = JsonConvert.
                   DeserializeObject<Battle_Item_Full>(request.downloadHandler.text);

                battleDetailedInfo.AlterDescriptiveData(Query_List.battleitem[0][0]);
               
            }


            //If No Data Found
            else
            {
                Debug.LogWarning("Empty");
            }

            //Debug.LogWarning("done Processing");

        }
    }

    public IEnumerator RetrieveHeldItemm (int id)
    {
        // Debug.Log("name: " + val.ToString());
        //Dictionary<string, object> charaterData = new Dictionary<string, object>();
        Dictionary<string, Dictionary<string, object>> battleData;
        using (UnityWebRequest request = new UnityWebRequest(BaseURL + $"/Items/Held/{id.ToString()}", "GET"))
        {
            //Debug.Log((BaseURL + $"/{level.ToString()}"));
            request.downloadHandler = new DownloadHandlerBuffer();

            //Debug.Log("Sending got request.....");
            //Debug.Log($"Request Link: {request.url}");
            yield return request.SendWebRequest();

            //Debug.Log($"Get all players response code: {request.responseCode}");

            //Check if have errors;
            if (string.IsNullOrEmpty(request.error))
            {
                //Debug.Log($"Message: {request.downloadHandler.text}");

                Held_Item_Full Query_List = JsonConvert.
                   DeserializeObject<Held_Item_Full>(request.downloadHandler.text);

                heldDetailedInfo.AlterDescriptiveData(Query_List.helditem[0][0]);

            }

            //If No Data Found
            else
            {
                Debug.LogWarning("Empty");
            }

            //Debug.LogWarning("done Processing");

        }
    }


}
