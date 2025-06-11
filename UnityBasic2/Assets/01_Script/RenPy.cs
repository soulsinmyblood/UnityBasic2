using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RenPy : MonoBehaviour
{
    [SerializeField] Image img_BG; // ���
    [SerializeField] Image[] img_Character; // ĳ����

    [SerializeField] TextMeshProUGUI txt_Name; // ĳ���� �̸�
    [SerializeField] TextMeshProUGUI txt_NameTitle; // ĳ���� Ÿ��Ʋ
    [SerializeField] TextMeshProUGUI txt_Dialogue; // ���

    //[SerializeField] Button buttonNext; // ��ư

    int id = 1; // ��� ID

    private void Start()
    {
        int characterID = SData.GetDialogueData(id).Character; // ��� ���̺��� 1�� ID�� ĳ���� ID �÷� �����Ϳ��� ĳ���� ID ��������
        txt_Name.text = SData.GetCharacterData(characterID).Name; // ĳ���� ���̺��� ĳ���� ID�� �ش��ϴ� �̸� ������ ��������
        txt_NameTitle.text = SData.GetCharacterData(characterID).Title; // ĳ���� ���̺��� ĳ���� ID�� �ش��ϴ� Ÿ��Ʋ ������ ��������
       
        txt_Dialogue.text = SData.GetDialogueData(id).Dialogue; // ��� ������ ��������
    }

    public void OnClickButton()
    {
        id++; // ��� ID ���� -> 2�� ���� ����

        int characterID = SData.GetDialogueData(id).Character; // ��� ���̺��� 1�� ID�� ĳ���� ID �÷� �����Ϳ��� ĳ���� ID ��������
        txt_Name.text = SData.GetCharacterData(characterID).Name; // ĳ���� ���̺��� ĳ���� ID�� �ش��ϴ� �̸� ������ ��������
        txt_NameTitle.text = SData.GetCharacterData(characterID).Title; // ĳ���� ���̺��� ĳ���� ID�� �ش��ϴ� Ÿ��Ʋ ������ ��������

        txt_Dialogue.text = SData.GetDialogueData(id).Dialogue; // ��� ������ ��������

        img_BG.sprite = Resources.Load<Sprite>("Img/CharacterImage/" + SData.GetDialogueData(id).BG);

        for (int i = 0; i < img_Character.Length; i++)
        {
            // Fix: Convert SData.GetDialogueData(id).Position to int before comparison
            if (i != int.Parse(SData.GetDialogueData(id).Position)) // 5
            {
                img_Character[i].gameObject.SetActive(false); // �ٸ� ĳ���� �̹��� ��Ȱ��ȭ
            }
            else
            {
                img_Character[i].sprite = Resources.Load<Sprite>("Img/CharacterImage/" + SData.GetCharacterData(SData.GetDialogueData(id).Character).Image); // ĳ���� �̹��� �ε�
                img_Character[i].gameObject.SetActive(true); // ĳ���� �̹��� Ȱ��ȭ
            }
        }
    }
}
