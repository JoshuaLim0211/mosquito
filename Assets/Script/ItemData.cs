using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemCategory
{
    gun,
    sword,
    spray
}

public class ItemData : MonoBehaviour
{
    ItemCategory itemCategory;

    public int id;
    public string name;
    public string information;



}
