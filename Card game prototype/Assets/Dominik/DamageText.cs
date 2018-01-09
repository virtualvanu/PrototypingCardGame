using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{

    [HideInInspector]
    public TextMeshProUGUI text;
    [HideInInspector]
    public bool damage;

    public float fadeStep;
    public float falldownStep;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime * fadeStep));

        if (damage)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - (Time.deltaTime * falldownStep));
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + (Time.deltaTime * falldownStep));
        }

        if (text.color.a < 0.1f)
        {
            Destroy(gameObject);
        }
    }
}
