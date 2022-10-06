using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class UICoinsCounter : MonoBehaviour
{
    private Text _counter;
    private int _coins = 0;

    private void Awake()
    {
        _counter = GetComponent<Text>();
    }

    private void OnEnable()
    {
        Coin.CoinCollecting += AddCoin;
    }

    private void OnDisable()
    {
        Coin.CoinCollecting -= AddCoin;
    }

    private void AddCoin()
    {
        _coins++;
        _counter.text = " - " + _coins.ToString();
    }
}
