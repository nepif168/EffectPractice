using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class ButtonUIManager : MonoBehaviour
{
    public Subject<GameObject> SelectedEffect { get;} = new Subject<GameObject>();

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
            var button = Instantiate(effectListButton, content) as Button;
            button.GetComponentInChildren<Text>().text = effect.Value.name;
            button.OnClickAsObservable().Subscribe(_ => SelectedEffect.OnNext(effect.Value));
        });
    }
}
