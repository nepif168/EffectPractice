using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class AutoRotation : MonoBehaviour {
    [SerializeField] float rotationSpeed;

    private void Start()
    {
        this.UpdateAsObservable().Subscribe(_ => transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed));
    }
}
