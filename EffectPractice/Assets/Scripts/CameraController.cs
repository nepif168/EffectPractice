using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

public class CameraController : MonoBehaviour {

    Vector3 initialPosition;
    Quaternion initialRotation;

    private void Awake()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    private void Start()
    {
        // カメラ位置の初期化
        this.UpdateAsObservable().Where(_ => Input.GetKeyDown(KeyCode.Z))
            .Subscribe(_ =>
            {
                transform.position = initialPosition;
                transform.rotation = initialRotation;
            });

        // カメラの移動
        this.UpdateAsObservable().Subscribe(_ =>
        {
            transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * 0.5f);
            if (Input.GetKey(KeyCode.LeftShift)) transform.Translate(Vector3.down * 0.2f, Space.World);
            if (Input.GetKey(KeyCode.Space)) transform.Translate(Vector3.up * 0.2f, Space.World);
        });

        // カメラの回転
        this.UpdateAsObservable().Where(_ => Input.GetMouseButton(1))
            .Subscribe(_ => transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0)));
    }
}
