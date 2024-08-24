using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Item _itemPrefab;
    [SerializeField] Transform _position;
    [SerializeField] private int _amount;

    public Item ItemPrefab => _itemPrefab;
    public Transform Position => _position;
}