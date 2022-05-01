using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectItem : MonoBehaviour
{
    int nowEquipItemID;
    public CharacterEquipManager CharacterEquipManager;

    private void Start()
    {
        nowEquipItemID = 0;
    }



    public void OnSelect(int id)
    {
        nowEquipItemID = id;
        CharacterEquipManager.equipItemID = nowEquipItemID;
        OnClickTrans();
        OnClickReturn();
    }

    private void OnClickTrans()
    {

    }

    private void OnClickReturn()
    {

    }
}
