using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CorrectPost : MonoBehaviour
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

  public void OnPost(string text)
  {
    StartCoroutine(API.FormData.Post("correct", new (string, string)[] { ("text", text) }, (string res) =>
    {
      textObj.text = res;
    }));
  }
}
