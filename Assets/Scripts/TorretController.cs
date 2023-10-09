using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TorretController : MonoBehaviour
{

    private bool isShooting;
    [SerializeField] private float rotSpeed;
    private Animator m_animator;
    private CircleCollider2D m_circleCollider;

    [SerializeField] private TorretStats _torretStats;
    public TorretStats TorretStats { get { return _torretStats; } set { _torretStats = value; } }


    void Awake()
    {
        m_animator = GetComponent<Animator>();
        m_circleCollider = GetComponent<CircleCollider2D>();
    }
    private void Start()
    {
        
        isShooting = false;

        m_circleCollider.radius = _torretStats.range;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isShooting = true;
        if(collision.gameObject.GetComponent<EnemyController>() != null)
            StartCoroutine(ShootCoroutine(collision.gameObject.GetComponent<EnemyController>()));
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy") {
             
            Vector2 targetDirection = collision.transform.position - transform.position;
            transform.up = Vector2.Lerp(transform.up, targetDirection, rotSpeed * Time.deltaTime);

            m_animator.SetBool("IsPlaying", true);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        m_animator.SetBool("IsPlaying", false);
        isShooting = false;
    }

    IEnumerator ShootCoroutine(EnemyController ec)
    {
        while (isShooting)
        {
            if(ec != null)
                ec.onShoot.Invoke(_torretStats.damage);
            yield return new WaitForSeconds(_torretStats.fireRate);
        }
    }
}
