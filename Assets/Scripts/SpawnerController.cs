using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] private GameObject[] m_enemy;

    public float intervaloIncremento = 20;
    private float tiempoPasado;
    private int dificultad = 1;

    void Start()
    {

        StartCoroutine(SpawnerCoroutine());
    }

    private void Update()
    {
        tiempoPasado += Time.deltaTime;

        if (tiempoPasado >= intervaloIncremento)
        {
            AumentarDificultad();
            tiempoPasado = 0f; 
        }
    }

    private void AumentarDificultad()
    {
        dificultad++;
    }

    IEnumerator SpawnerCoroutine()
    {
        while (true)
        {
            if (dificultad <= 5)
            {
                GameObject enemy = Instantiate(m_enemy[0]);
                enemy.transform.position = transform.position;
            }
            else if(dificultad>5 && dificultad <= 12)
            {
                GameObject enemy = Instantiate(m_enemy[0]);
                GameObject enemy2 = Instantiate(m_enemy[1]);
                enemy.transform.position = transform.position;
                enemy2.transform.position = transform.position;
            }
            else
            {
                GameObject enemy = Instantiate(m_enemy[0]);
                GameObject enemy2 = Instantiate(m_enemy[1]);
                GameObject enemy3 = Instantiate(m_enemy[2]);
                enemy.transform.position = transform.position;
                enemy2.transform.position = transform.position;
                enemy3.transform.position = transform.position;
            }
            
            if((10 - dificultad) < 1)
            {
                yield return new WaitForSeconds(0.9f);
            }
            else
            {
            yield return new WaitForSeconds(10-dificultad);
            }
        }
    }
}
