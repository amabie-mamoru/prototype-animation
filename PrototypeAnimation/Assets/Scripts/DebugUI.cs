using UnityEngine;
using UnityEngine.UIElements;

public class DebugUI : MonoBehaviour
{
    [SerializeField] private UIDocument uiDocument;
    [SerializeField] private Canvas spriteCanvas;

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
        gameObj.transform.SetParent(spriteCanvas.transform);
    }
}
