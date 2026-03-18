using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int crystals = 0;

    public void AddCrystal(int amount)
    {
        crystals += amount;
        Debug.Log("Crystals: " + crystals);
    }
}