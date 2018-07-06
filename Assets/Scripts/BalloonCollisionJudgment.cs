using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BalloonとBalletの衝突判定を管理するスクリプト
/// </summary>

public class BalloonCollisionJudgment : MonoBehaviour {

    public AudioSource break_audio;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            break_audio.PlayOneShot(break_audio.clip); // 破裂音再生
            Destroy(this.gameObject); // Balletタグのついてるオブジェクトに衝突したらデストロイする
        }
    }
}
