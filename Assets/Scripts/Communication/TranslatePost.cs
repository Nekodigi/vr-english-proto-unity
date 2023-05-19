using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using TMPro;

public class TranslatePost : MonoBehaviour
{
    public TextMeshProUGUI textObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPost(string text){
        StartCoroutine(Post(text));
    }

    public IEnumerator Post(string text){
        
        WWWForm form = new WWWForm();
        form.AddField("langTo", "en");
        form.AddField("text", text);

        using (UnityWebRequest www = UnityWebRequest.Post("https://vr-english-proto-backend-o3mmnjeefa-an.a.run.app/translate", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.result);
                Debug.Log(www.downloadHandler.text);
                textObj.text = www.downloadHandler.text;
            }
        }
    }
}
