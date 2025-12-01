using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;


public class Tooltip : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textTitle;
    [SerializeField] TextMeshProUGUI textBody;


    private void Start()
    {
        //gameObject.SetActive(false);
        
    }


    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    public void SetText(string titleText, string bodyText)
    {
        textTitle.text = titleText;
        textBody.text = bodyText;
    }

    private void OnValidate()
    {
        var finded =  FindObjectsByType<Tooltip>(FindObjectsSortMode.None);
        if (finded.Length > 1)
        {
            Debug.LogError("More than one tooltip!");
        }
    }
}
