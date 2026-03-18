using UnityEngine;

public class ShopManager : MonoBehaviour
{
  public ShopItem[] items;

  void Start()
  {
    int goldGained = CurrencyManager.Instance.ConvertAllCrystalsToGold();
    Debug.Log("Shop opened. Gained gold from crystals: " + goldGained);
  }

  public void BuyItem(int index)
  {
    ShopItem item = items[index];
    bool success = CurrencyManager.Instance.SpendCurrency(item.currencyType, item.price);

    if (success)
    {
      Debug.Log("Bought: " + item.itemName);
      GrantItem(item);
    }
    else
    {
      Debug.Log("Not enough " + item.currencyType);
    }
  }
  void GrantItem(ShopItem item)
  {
    Debug.Log(item.itemName + " added to inventory");
  }
}
