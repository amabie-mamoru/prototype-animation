using UnityEngine;

/// <summary>
/// 使い捨てのエフェクト
/// </summary>
public class DisposableFadeOutEffect : MonoBehaviour
{
	private float mLength;
	private float mCur;

	[SerializeField] private float fadeSpeed = 10f;
	private SpriteRenderer spriteRenderer;
	private float fadeNormalizedTime;

	void Awake()
	{
		Animator animOne = GetComponent<Animator>();
		AnimatorStateInfo infAnim = animOne.GetCurrentAnimatorStateInfo(0);
		mLength = infAnim.length;
		mCur = 0;

		spriteRenderer = GetComponent<SpriteRenderer>();
		fadeNormalizedTime = 1;
	}

	// Update is called once per frame
	void Update()
	{
		mCur += Time.deltaTime;
		if (mCur > mLength)
		{
			FadeOut();
		}
	}

	void FadeOut()
    {
		fadeNormalizedTime -= Time.deltaTime * fadeSpeed;
		if (fadeNormalizedTime <= 0)
		{
			GameObject.Destroy(gameObject);
			return;
		}
		spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, fadeNormalizedTime);
    }
}