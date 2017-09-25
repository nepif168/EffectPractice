using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class EffectLoader : MonoBehaviour {

    public ReactiveCollection<GameObject> Effects { get; private set; } = new ReactiveCollection<GameObject>();

    private void Start()
    {
        foreach (var effect in Resources.LoadAll("Effects", typeof(GameObject)))
            Effects.Add(effect as GameObject);
    }

}
