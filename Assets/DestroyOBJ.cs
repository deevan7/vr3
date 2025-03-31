using UnityEngine;
using UnityEngine.UI;

public class DestroyOBJ : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        Destroy(gameObject); // Destroys the button after click
    }
}
