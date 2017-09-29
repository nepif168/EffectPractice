using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    
    // ReactivePropertyの宣言と初期化
    [SerializeField] IntReactiveProperty currentHP;

    // HPのテキスト
    [SerializeField] Text hpText;

    // 押したらダメージを与えるボタン
    [SerializeField] Button damageButton;

    // BoolのReactivePropery(最初は死んでないのでfalse)
    ReactiveProperty<bool> isDead;
    
    private void Start()
    {
        // HPが0以下になったら通知
        isDead = currentHP.Select(hp => hp <= 0).ToReactiveProperty();

        // HPの変更があったらhpTextを(現在のHPに)変更する
        currentHP.Where(_=> !isDead.Value).Subscribe(hp => hpText.text = hp.ToString());

        // ボタンをおしたらHPが1減るようにする
        damageButton.OnClickAsObservable().Subscribe(_ => currentHP.Value -= 1);

        // 死んだら死んだと表示する
        isDead.Where(d => d).Subscribe(_ => hpText.text = "死んだ");
        
    }
}

public class ReadOnlyReactiveProperty
{
    IntReactiveProperty currenHP;
    IReadOnlyReactiveProperty<int> CurrentHP => currenHP;

    public Subject<Unit> Push { get; } = new Subject<Unit>(); 
}