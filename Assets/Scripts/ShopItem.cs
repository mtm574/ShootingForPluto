using UnityEngine;

[System.Serializable]
public class ShopItem
{
  [Header("Item Info")]
  public string itemName;

  [TextArea(2, 5)]
  public string description;

  public Sprite icon;

  [Header("Cost")]
  public int price;
  public string currencyType;
}
