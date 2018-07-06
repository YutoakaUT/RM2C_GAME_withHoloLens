using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class FireBullet : MonoBehaviour, IInputClickHandler{
    // bullet prefab
    public GameObject bullet;
    // 発射地点
    public Transform muzzle;
    // 弾のスピード
    public float bulletSpeed = 1000;
    // 発射音
    public AudioSource fire_audio;

	// Use this for initialization
	void Start () {
        //AirTapを検出したとき、OnInputClickedが呼ばれる。
        InputManager.Instance.PushFallbackInputHandler(gameObject);
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        // 弾丸の複製
        GameObject bullets = GameObject.Instantiate(bullet) as GameObject;
        Vector3 force;
        force = this.gameObject.transform.forward * bulletSpeed;
        // Rigidbodyに力を加えて発射
        bullets.GetComponent<Rigidbody>().AddForce(force);
        // 弾丸の位置を調整
        bullets.transform.position = muzzle.position;
        // 発射音再生
        fire_audio.PlayOneShot(fire_audio.clip);
    }

    // Update is called once per frame
    void Update () {

    }

}
