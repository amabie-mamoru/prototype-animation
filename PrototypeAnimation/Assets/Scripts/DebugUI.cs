using UnityEngine;
using UnityEngine.UIElements;

public class DebugUI : MonoBehaviour
{
    [SerializeField] private UIDocument uiDocument;
    // Canvas を直接参照すると Screen Space - Overlay の場合 Anchor が左下固定のため
    // 追加するオブジェクトも全てアンカーを左下にしないといけなくなる
    // それをあえて避けるために Canvas アンカーを左下とする Root となる GameObject を定義することで
    // 追加される GameObject の Anchor をデフォルト(中央)で定義しやすくするための工夫
    [SerializeField] private GameObject spriteRoot;
    private void Awake()
    {
        var rootVisualElement = uiDocument.rootVisualElement;
        var exclamationMarkBtn = rootVisualElement.Query<Button>("exclamation-mark").First();
        exclamationMarkBtn.clicked += OnExclamationMarkBtnClicked;
    }

    public void OnExclamationMarkBtnClicked()
    {
        var prefab = Resources.Load<GameObject>("Prefabs/ExclamationMark");
        var gameObj = Instantiate(prefab);
        //var gameObj = new GameObject("Mark");
        //var spriteRenderer = gameObj.AddComponent<SpriteRenderer>();
        //spriteRenderer.sprite = mark;
        var mark = gameObj.GetComponent<SpriteRenderer>();
        gameObj.transform.localScale = new Vector3(10, 10, 1); // TODO: localScale はたぶん UI の解像度に合わせて変更する処理が必要
        gameObj.transform.position = new Vector3(gameObj.transform.position.x - mark.bounds.size.x / 2, gameObj.transform.position.y + mark.bounds.size.y / 2, 0);
        gameObj.transform.SetParent(spriteRoot.transform);
    }
}
