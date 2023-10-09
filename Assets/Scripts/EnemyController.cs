using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyStats _enemyStats;
    [SerializeField] private SpriteRenderer _turretTank;

    private GameObject _gm;
    private GameManager _gameManager;
    private int _currentPoint =0;

    private float m_health;

    public EnemyStats EnemyStats { get { return _enemyStats; } set { _enemyStats = value; } }
    private Vector2 direction = new Vector2();

    public delegate void Shoot(float damage);
    public Shoot onShoot;
    

    void Start()
    {
        _gm = GameObject.Find("GameManager");
        _gameManager = _gm.GetComponent<GameManager>();

        _turretTank.sprite = _enemyStats.sprite;

        onShoot += OnShooted;
        m_health = _enemyStats.health;
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector2.Distance(transform.position, _gameManager.PathPoints[_currentPoint].position) < 0.03f )
        {
            if(_currentPoint > _gameManager.PathPoints.Length-2)
            {
                Destroy(gameObject);
                SceneManager.LoadScene("End");
            }
            else
            {
            _currentPoint++;
            }
        }


        direction = _gameManager.PathPoints[_currentPoint].position - transform.position;

        gameObject.GetComponent<Rigidbody2D>().velocity = direction.normalized * _enemyStats.velocity;
        transform.up = Vector2.Lerp(transform.up, direction, 3 * Time.deltaTime);

    }

    private void OnShooted(float damage)
    {
        if((m_health - damage) > 0)
        {
            m_health -= damage;
        }
        else
        {
            _gameManager.onKill.Invoke();
            Destroy(gameObject);
        }
    }
}
