using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance;

    private Dictionary<string, int> currencies = new Dictionary<string, int>();
     private Dictionary<string, int> crystalValues = new Dictionary<string, int>();

     void Awake()
     {
         if (Instance == null)
         {
            Instance = this;
            DontDestroyOnLoad(gameObject);
         }
         else
         {
           Destroy(gameObject);
         }

         currencies["gold"] = 0;
         currencies["blue_crystal"] = 0;
         currencies["green_crystal"] = 0;
         currencies["yellow_crystal"] = 0;

         crystalValues["blue_crystal"] = 5;
         crystalValues["green_crystal"] = 20;
         crystalValues["yellow_crystal"] = 50;
      }

      public int GetCurrency(string type)
      {
        if (currencies.ContainsKey(type))
            return currencies[type];

        return 0;
      }

      public void AddCurrency(string type, int amount)
      {
        if (!currencies.ContainsKey(type))
            currencies[type] = 0;

        currencies[type] += amount;
      }

      public bool SpendCurrency(string type, int amount)
      {
        if (GetCurrency(type) >= amount)
        {
          currencies[type] -= amount;
          return true;
        }
        return false;
      }

      public int ConvertAllCrystalsToGold()
      {
        int totalGold = 0;

        foreach (var crystal in crystalValues)
        {
          string type = crystal.Key;
          int value = crystal.Value;
          int amount = GetCurrency(type);

          if (amount > 0)
          {
            int gold = amount * value;
            totalGold += gold;
            currencies[type] = 0;
          }
        }
        currencies["gold"] += totalGold;
        Debug.Log("Converted all crystals into " + totalGold + " gold");
        return totalGold;
      }
}
