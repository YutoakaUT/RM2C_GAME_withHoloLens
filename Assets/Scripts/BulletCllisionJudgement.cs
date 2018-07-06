using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Bulletの衝突判定を管理するスクリプト
/// </summary>

public class BulletCllisionJudgement : MonoBehaviour {

    public AudioSource break_audio; // 効果音
    public ParticleSystem explosion_prefab; // 破裂パーティクル
    public GameObject bullet_child; // 弾

    // Use this for initialization
    void Start()
    {
        bullet_child = transform.Find("Bullet").gameObject;
        Invoke("DelayMethod", 3.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        break_audio.PlayOneShot(break_audio.clip); // 破裂音再生
        Destroy(bullet_child); //　オブジェクトに衝突したらデストロイする
        explosion_prefab.Play(); // パーティクルシステムスタート
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll; //衝突後静止
    }

    void DelayMethod()
    {
        Destroy(this.gameObject); // 自身を消滅
    }
}
