using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform[] _pathPoints;
    [SerializeField] private TextController _textController;

    [SerializeField] private GameObject[] _buildings;
    [SerializeField] private GameObject[] m_torret;

    public delegate void Buy(int torret, int casilla);
    public Buy onBuy;

    public Transform[] PathPoints { get { return _pathPoints; } set { _pathPoints = value; } }

    private int _coins;
    public int Coins { get { return _coins; } set { _coins = value; } }

    public delegate void Kill();
    public Kill onKill;

    public delegate void Casilla(int num);
    public Casilla onCasilla;

    private int _numeroCasilla;
    public int numeroCasilla { get { return _numeroCasilla; } set { _numeroCasilla = value; } }

    void Start()
    {
        _coins = 200;
        onKill += enemyDeath;
        onBuy += newTorret;
        onCasilla += casilla;
        _textController.SetText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enemyDeath()
    {
        _coins += 30;
        _textController.SetText();
    }

    private void newTorret(int torret, int casilla)
    {
        if (torret == 1)
        {
            GameObject obj = Instantiate(m_torret[0]);
            obj.transform.position = _buildings[casilla].transform.position;
        }
        else if (torret == 2)
        {
            GameObject obj = Instantiate(m_torret[1]);
            obj.transform.position = _buildings[casilla].transform.position;
        }
        else
        {
            GameObject obj = Instantiate(m_torret[2]);
            obj.transform.position = _buildings[casilla].transform.position;
        }
    }

    public void casilla(int num)
    {
        numeroCasilla = num;
    }
}
