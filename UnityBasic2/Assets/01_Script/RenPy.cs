using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RenPy : MonoBehaviour
{
    [SerializeField] Image img_BG; // 배경
    [SerializeField] Image[] img_Character; // 캐릭터

    [SerializeField] TextMeshProUGUI txt_Name; // 캐릭터 이름
    [SerializeField] TextMeshProUGUI txt_NameTitle; // 캐릭터 타이틀
    [SerializeField] TextMeshProUGUI txt_Dialogue; // 대사

    //[SerializeField] Button buttonNext; // 버튼

    int id = 1; // 대사 ID

    private void Start()
    {
        int characterID = SData.GetDialogueData(id).Character; // 대사 테이블의 1번 ID의 캐릭터 ID 컬럼 데이터에서 캐릭터 ID 가져오기
        txt_Name.text = SData.GetCharacterData(characterID).Name; // 캐릭터 테이블에서 캐릭터 ID에 해당하는 이름 데이터 가져오기
        txt_NameTitle.text = SData.GetCharacterData(characterID).Title; // 캐릭터 테이블에서 캐릭터 ID에 해당하는 타이틀 데이터 가져오기
       
        txt_Dialogue.text = SData.GetDialogueData(id).Dialogue; // 대사 데이터 가져오기
    }

    public void OnClickButton()
    {
        id++; // 대사 ID 증가 -> 2번 대사로 변경

        int characterID = SData.GetDialogueData(id).Character; // 대사 테이블의 1번 ID의 캐릭터 ID 컬럼 데이터에서 캐릭터 ID 가져오기
        txt_Name.text = SData.GetCharacterData(characterID).Name; // 캐릭터 테이블에서 캐릭터 ID에 해당하는 이름 데이터 가져오기
        txt_NameTitle.text = SData.GetCharacterData(characterID).Title; // 캐릭터 테이블에서 캐릭터 ID에 해당하는 타이틀 데이터 가져오기

        txt_Dialogue.text = SData.GetDialogueData(id).Dialogue; // 대사 데이터 가져오기

        img_BG.sprite = Resources.Load<Sprite>("Img/CharacterImage/" + SData.GetDialogueData(id).BG);

        for (int i = 0; i < img_Character.Length; i++)
        {
            // Fix: Convert SData.GetDialogueData(id).Position to int before comparison
            if (i != int.Parse(SData.GetDialogueData(id).Position)) // 5
            {
                img_Character[i].gameObject.SetActive(false); // 다른 캐릭터 이미지 비활성화
            }
            else
            {
                img_Character[i].sprite = Resources.Load<Sprite>("Img/CharacterImage/" + SData.GetCharacterData(SData.GetDialogueData(id).Character).Image); // 캐릭터 이미지 로드
                img_Character[i].gameObject.SetActive(true); // 캐릭터 이미지 활성화
            }
        }
    }
}
