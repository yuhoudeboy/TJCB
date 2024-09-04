using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TJCBStartWindow : MonoBehaviour
{
    [SerializeField]
    private GameObject m_LoadInitResourceObj;

    [SerializeField]
    private Image m_ProgressBarImg;

    [SerializeField]
    private Text m_ProgressTxt;
    // Start is called before the first frame update

    [SerializeField]
    private Button m_PlatformLoginBt;
    void Start()
    {
        LoadInitResource();
    }


    private void LoadInitResource() 
    {
        m_LoadInitResourceObj.SetActive(true);

        m_PlatformLoginBt.gameObject.SetActive(false);

        m_ProgressBarImg.fillAmount = 0.0f;

        m_ProgressTxt.text = "0.00";

        StartCoroutine(LoadInitResourceSimulation());
    }

    private IEnumerator LoadInitResourceSimulation() 
    {
        float totalTime = 0f;
        while (totalTime < 5f)
        {
            yield return new WaitForSeconds(0.5f);

            totalTime += 0.5f;

            m_ProgressBarImg.fillAmount += 0.1f;

            m_ProgressTxt.text = string.Format
                ("{0:P}", m_ProgressBarImg.fillAmount) +  " %";
        }

        yield return new WaitForSeconds(0.3f);
        LoadInitResourceFinish();

        yield break;

    }

    private void LoadInitResourceFinish() 
    {
        m_LoadInitResourceObj.SetActive(false);

        m_PlatformLoginBt.gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {

    }


}
