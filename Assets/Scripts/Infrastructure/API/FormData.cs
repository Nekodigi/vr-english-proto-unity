using System.Collections;
using UnityEngine.Networking;
using UnityEngine;
using System;


namespace API
{
  public class FormData : MonoBehaviour
  {
    public static IEnumerator Post(string target, (string, string)[] values, System.Action<string> callback)
    {
      WWWForm form = new WWWForm();
      foreach ((string, string) value in values)
      {
        form.AddField(value.Item1, value.Item2);
      }

      using (UnityWebRequest www = UnityWebRequest.Post("https://vr-english-proto-backend-o3mmnjeefa-an.a.run.app/" + target, form))
      {
        yield return www.SendWebRequest();
        if (www.result != UnityWebRequest.Result.Success)
        {
          Debug.Log(www.error);
        }
        else
        {
          callback(www.downloadHandler.text);
        }
      }
    }
  }
}
