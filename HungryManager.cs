using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungryManager : MonoBehaviour
{
    [SerializeField] private Slider hungrySlider;
    [Tooltip("������� �������� ������")]
    [SerializeField] private int hungryCount = 100;
    [Tooltip("������������ �������� ������")]
    [SerializeField] private int maxHungry = 100;
    [Tooltip("����� ����� ����� ���������� �����")]
    [SerializeField] private float hungryDelay = 15;
    [Tooltip("������� ������ ������ ���������� �� ���")]
    [SerializeField] private int stravePower = 1;

    private void Start()
    {
        hungrySlider.maxValue = maxHungry;
        hungrySlider.value = hungryCount;
        StartCoroutine(Strave());
    }
    public void AddHungry(int value)
    {
        if (hungryCount > 100)
        {
            hungryCount = 100;
        }

        hungryCount += value;
        hungrySlider.value = hungryCount;
    }

    IEnumerator Strave()
    {
        yield return new WaitForSeconds(hungryDelay);
        hungryCount -= stravePower;
        hungrySlider.value = hungryCount;
        StartCoroutine(Strave());
        if (hungryCount < 0)
        {
            hungryCount = 0;
        }
    }
}
