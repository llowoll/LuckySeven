using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletMoving : MonoBehaviour
{
    private float bulletSpeed = 15f;  // 탄환의 속도(무기 선택에 따라 바뀌게 만들어야 합니다)
    private float destroyTime = 5f;  // 탄환 유지 시간("")
    private float damage = 1f;  // 탄환의 위력("")

    private float direction; // 플레이어의 방향(탄환 발사 방향)

    private Vector2 bulletVelocity = new Vector2(0, 0);

    private Rigidbody2D rigid;

    private GameObject player;
    private Animator animator;

    void Start()
    {
        player = GameObject.Find("Player");
        animator = player.GetComponent<Animator>();

        rigid = GetComponent<Rigidbody2D>();

        direction = animator.GetFloat("Dir");

        if (direction == 1f)
        {
            bulletVelocity = new Vector2(bulletSpeed, 0);
        }
        else if(direction == -1f)
        {
            bulletVelocity = new Vector2(-bulletSpeed, 0);
        }

        rigid.AddForce(bulletVelocity, ForceMode2D.Impulse);

        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
