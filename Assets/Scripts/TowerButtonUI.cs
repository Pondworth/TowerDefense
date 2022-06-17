using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TowerButtonUI : MonoBehaviour
{
    public TowerData tower;
    public TextMeshProUGUI towerNameText;
    public TextMeshProUGUI towerCostText;
    public Image towerIcon;

    private Button button;

    void OnEnable()
    {
        GameManager.instance.onMoneyChanged.AddListener(OnMoneyChanged);
    }

    void OnDisable()
    {
        GameManager.instance.onMoneyChanged.RemoveListener(OnMoneyChanged);
    }

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void Start()
    {
        towerNameText.text = tower.displayName;
        towerCostText.text = $"$ {tower.cost}";
        towerIcon.sprite = tower.icon;
        
        OnMoneyChanged();
    }

    public void OnClick()
    {
        GameManager.instance.towerPlacement.SelectTowerToPlace(tower);
    }

    void OnMoneyChanged()
    {
        button.interactable = GameManager.instance.money >= tower.cost;
    }
}
