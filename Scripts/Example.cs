using UnityEngine;

public class Example : MonoBehaviour
{
    [SerializeField]
    private Money _itemPrice;

    [SerializeField]
    private Money _availableMoney;


    void Start()
    {
        if (_itemPrice <= _availableMoney)
        {
            _availableMoney -= _itemPrice;

            var (gold, silver, copper) = _availableMoney.GetCoins();
            Debug.Log($"You bought this item. You have {gold} gold, {silver} silver and {copper} copper left.");
        }
        else
        {
            Debug.Log("You don't have enough money");
        }
    }

}
