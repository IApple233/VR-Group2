using UnityEngine.UI;
using UnityEngine;

public class ChangeText : MonoBehaviour
{
    public Text new_text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SendMess.isCond == true)
        {
            new_text = gameObject.GetComponent<Text>();
            new_text.text = "520030910364";
                }
    }
}
