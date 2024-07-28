using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageTransparencyCycle : MonoBehaviour
{

    private Image targetImage; // ������ �� ��������� Image
    public float cycleDuration = 3f; // ������������ �����

    private void Start()
    {
        targetImage = GetComponent<Image>();    

        if (targetImage == null)
        {
            Debug.LogError("Target Image is not set.");
            return;
        }

        // ��������� �������� ��� ��������� ������������
        StartCoroutine(FadeCycle());
    }

    private IEnumerator FadeCycle()
    {
        while (true)
        {
            // ��������� ������������ �� 0 �� 1
            yield return StartCoroutine(Fade(0f, 0.7f, cycleDuration));

            // ��������� ������������ �� 1 �� 0
            yield return StartCoroutine(Fade(0.7f, 0f, cycleDuration));
        }
    }

    private IEnumerator Fade(float startAlpha, float endAlpha, float duration)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsed / duration);
            SetAlpha(alpha);
            yield return null;
        }

        // ���������, ��� �������� �������� �����-������ ����������� �����
        SetAlpha(endAlpha);
    }

    private void SetAlpha(float alpha)
    {
        Color color = targetImage.color;
        color.a = alpha;
        targetImage.color = color;
    }

}
