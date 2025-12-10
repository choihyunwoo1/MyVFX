using UnityEngine;
using System.Collections;

namespace Sample
{
    public class DessolveTest : MonoBehaviour
    {
        #region Variables
        public Renderer renderer;

        private Material originMaterial;
        public Material dessolveMaterial;

        public GameObject vfxObejct;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //참조
            originMaterial = renderer.material;

            //디졸브 이펙트 플레이
            StartCoroutine(DestroyEnemy());
        }
        #endregion

        #region Custom Method
        //생성
        IEnumerator SpawnEllen()
        {
            renderer.material = dessolveMaterial;
            renderer.material.SetFloat("_SplitValue", 0f);

            yield return new WaitForSeconds(0.5f);

            float t = 0f;

            while(t < 1.5f)
            {
                t += Time.deltaTime;
                float value = t / 1.5f;
                renderer.material.SetFloat("_SplitValue", value);

                yield return null;
            }

            renderer.material = originMaterial;
        }

        //소멸
        IEnumerator DestroyEnemy()
        {
            yield return new WaitForSeconds(1.5f);

            renderer.material = dessolveMaterial;
            renderer.material.SetFloat("_SplitValue", 1f);

            vfxObejct.SetActive(true);

            float t = 0f;

            while (t < 1.5f)
            {
                t += Time.deltaTime;
                float value = t / 1.5f;
                renderer.material.SetFloat("_SplitValue", 1f - value);

                yield return null;
            }

            Destroy(gameObject);
            //renderer.material = originMaterial;
        }
        #endregion

    }
}