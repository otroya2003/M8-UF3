using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildingController : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private GameObject shopMenu;
    
    private int espacio;

    private void OnMouseDown()
    {
        espacio = int.Parse(gameObject.name);
        _gameManager.onCasilla.Invoke(espacio);
        shopMenu.SetActive(true);
    }

    
}
