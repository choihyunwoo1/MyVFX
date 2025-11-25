using UnityEngine;
using UnityEngine.VFX;
using System.Collections;

namespace MyVfx
{
    public class LevelUp : MonoBehaviour
    {
        #region Varialbes
        //참조
        Animator animator;

        bool isLevelUp = false; //레벨업 이펙트 플레이 체크

        public VisualEffect levelUp; //레벨업 VFX 이펙트
        public Renderer bodyRenderer; //메터리얼을 관리하는 렌더러
        public Material blowMaterial; //바꿀 메터리얼
        Material originMaterial; //원래 메터리얼
        string paramLevelUp = "Levelup";
        #endregion

        #region Unity Event Method
        private void Awake()
        {
            //참조
             animator = GetComponent<Animator>();
        }
        private void Start()
        {
            //초기화
            isLevelUp = false;
            originMaterial = bodyRenderer.material; 
            
        }
        private void Update()
        {
            //마우스 우클릭하면 레벨업 치팅
            if (Input.GetMouseButtonDown(1)&& isLevelUp == false)
            {
                StartCoroutine(LevelupEffect());    
            }
        }
        #endregion

        #region Custom Method
        IEnumerator LevelupEffect()
        { 
            isLevelUp =true;

            //레벨업 애니 및 vfx이펙트 시작
            animator.SetTrigger(paramLevelUp);
            levelUp.gameObject.SetActive(true);

            yield return new WaitForSeconds(0.2f);

            //메터리얼 바꿔치기
            bodyRenderer.material = blowMaterial;
            yield return new WaitForSeconds(0.8f);

            bodyRenderer.material = originMaterial;
            yield return new WaitForSeconds(2f);

            //레벨업 이펙트 초기화
            levelUp.gameObject.SetActive(false);
            isLevelUp =false;
        }
        #endregion
    }
}