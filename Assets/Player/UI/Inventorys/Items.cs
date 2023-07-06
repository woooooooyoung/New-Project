using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemTape
{
    Equipement,     // ���
    Consumables,    // �Ҹ�ǰ
    Etc             // ��Ÿ
}
[System.Serializable]
public class Items
{
    public ItemTape ItemTape;   // ������ Ÿ��
    public string itemName;     // ������ �̸�
    public Sprite itemImage;    // �̾��� �̹���
    public List<ItemEffect> efts;

    public bool Use() // ������ ��� �������� ��ȯ
    {
        // ������ ���
        bool isUsed = false;
        foreach (ItemEffect eft in efts)// Use�ż��忡�� �ݺ����� ���� efts�� ExecuteRole�� ����
        {
            isUsed = eft.ExecuteRole();
        }
        return isUsed;
    }
}

