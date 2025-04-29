using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRPG : MonoBehaviour
{
    public float maxHealth = 100;
    public float minHealth = 0;
    public float health;

    public Slider healthBar;

    public float attackDamage = 5f;
    public float bulletDamage = 10f;
    public float attackInterval = 1f;

    private float timer;
    private bool isAttackReady = true;

    public GameObject bulletPrefab;

    public Transform bulletSpawn;

    public float bulletForce = 500f;

    public Image attackReadyImage;

    public int ammunition;

    // Start is called before the first frame update
    void Start()
    {
        isAttackReady = true;

        maxHealth = health;
        ammunition = 100;

        healthBar.maxValue = health;
        health = minHealth;
        healthBar.value = health;

    }

    // Update is called once per frame
    void Update()
    {
        if (isAttackReady == false)
        {
            timer += Time.deltaTime;

            if (timer >= attackInterval)
            {
                isAttackReady = true;
                attackReadyImage.gameObject.SetActive(isAttackReady);
                timer = 0f;
            }
        }


        if (Input.GetMouseButtonDown(0))
        {
            if (isAttackReady == true)
            {
                RaycastHit hit;

                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 3f))
                {
                    BaseEnemy enemy = hit.collider.GetComponent<BaseEnemy>();

                    if (hit.collider.tag == "Enemy")
                    {
                        enemy.TakeDamage(10);
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * bulletForce);

            Destroy(bullet, 3f);
        }
        // if (enemy != null)
        {
            //      Attack(enemy);
        }

    }
    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Debug.Log("YOU DIED");
        }
    }
}
    /*public void Attack(BaseEnemy enemy)
    {
        enemy.TakeDamage(attackDamage);
        isAttackReady = false;
        attackReadyImage.gameObject.SetActive(isAttackReady);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemy.TakeDamage(10);
            Debug.Log("damage takne from bullet");
        }
    */
