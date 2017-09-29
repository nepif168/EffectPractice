using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class EffectCreater : MonoBehaviour {

    [SerializeField]
    ButtonUIManager buttonUIManager;

    [SerializeField]
    Transform parent;

    private void Start()
    {
        buttonUIManager.SelectedEffect.Subscribe(effect =>
        {
            if (parent.childCount != 0)
                Destroy(parent.GetChild(0).gameObject);
            Instantiate(effect, effect.transform.position.normalized, effect.transform.rotation, parent);
        });
    }

}
