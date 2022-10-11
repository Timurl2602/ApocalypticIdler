using UnityEngine;

public class ShowShop : MonoBehaviour
{
    [SerializeField] private GameObject _shop;
    private bool isShopOpen;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            isShopOpen = !isShopOpen;
            _shop.SetActive(isShopOpen);
        }
    }
}
