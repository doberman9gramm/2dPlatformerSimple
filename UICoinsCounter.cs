using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class UICoinsCounter : MonoBehaviour
{
    private Text _counter;
    private int _coins;

    private void Start()
    {
        _coins = 0;
        _counter = GetComponent<Text>();
    }
    private void OnEnable()
    {
        Coin.PickUpCoin += AddCoin;
    }

    private void OnDisable()
    {
        Coin.PickUpCoin -= AddCoin;
    }

    private void AddCoin()
    {
        _coins++;
        _counter.text = " - " + _coins.ToString();
    }
}
