using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class ButtonUIManager : MonoBehaviour
{
    [SerializeField]
    EffectLoader effectLoader;

    [SerializeField]
    Button effectListButton;

    [SerializeField]
    Transform content;

    private void Awake()
    {
        effectLoader.Effects.ObserveAdd().Subscribe(effect =>
        {
            Instantiate(effectListButton, content).GetComponentInChildren<Text>().text = effect.Value.name;
        });
    }
}
