using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBuy : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private TextController _textController;
    [SerializeField] private GameObject shopMenu;


    private void Start()
    {
        
    }

    public void newTorret()
    {
        if (gameObject.name == "mk1")
        {
            if ((_gameManager.Coins - 100) >= 0)
            {
                _gameManager.Coins -= 100;
                _gameManager.onBuy.Invoke(1, _gameManager.numeroCasilla);
            }
        }
        else if (gameObject.name == "mk2")
        {
            if ((_gameManager.Coins - 200) >= 0)
            {
                _gameManager.Coins -= 200;
                _gameManager.onBuy.Invoke(2, _gameManager.numeroCasilla);
            }
        }
        else
        {
            if ((_gameManager.Coins - 500) >= 0)
            {
                _gameManager.Coins -= 500;
                _gameManager.onBuy.Invoke(3, _gameManager.numeroCasilla);
            }
        }
        _textController.SetText();

        shopMenu.SetActive(false);
    }
}
