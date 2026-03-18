
using UnityEngine;

public class CrystalPickup : MonoBehaviour
{
  [Header("Crystal Type")]
  public string crystalType = "blue_crystal";
  // public string crystalType = "green_crystal";
  // public string crystalType = "yellow_crystal";

  [Header("Attraction Settings")]
  public float attractionRange = 5f;
  public float moveSpeed = 5f;

  private Transform player;

  void Start()
  {
    GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
    if (playerObj != null)
      player = playerObj.transform;
  }
  void Update()
  {
    if (player == null) return;
    float distance = Vector2.Distance(transform.position, player.position);

    if (PlayerUpgrades.Instance != null && PlayerUpgrades.Instance.crystalMagnet && distance < attractionRange)
    {
      transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }
  }
  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Player"))
    {
      CurrencyManager.Instance.AddCurrency(crystalType, 1);
      Destroy(gameObject);
    }
  }
}

// Minimal stub to prevent errors if PlayerUpgrades is missing
public class PlayerUpgrades
{
  public static PlayerUpgrades Instance = new PlayerUpgrades();
  public bool crystalMagnet = false;
}