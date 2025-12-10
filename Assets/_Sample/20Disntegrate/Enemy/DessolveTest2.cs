using UnityEngine;
using System.Collections;

namespace Sample
{
    public class DessolveTest2 : MonoBehaviour
    {
        #region Variables
        public Renderer renderer;

        private Material[] originMaterials;
        public Material[] dessolveMaterials;

        int length = 0;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //참조
            length = renderer.materials.Length;
            originMaterials = renderer.materials;

            //디졸브 이펙트 플레이
            //StartCoroutine(SpawnEllen());
            StartCoroutine(DestroyEnemy());
        }
        #endregion

        #region Custom Method
        //생성
        IEnumerator SpawnEllen()
        {
            Material[] spawnMaterials = renderer.materials;
            for (int i = 0; i < length; i++)
            {
                spawnMaterials[i] = dessolveMaterials[i];
                spawnMaterials[i].SetFloat("_SplitValue", 0f);
            }
            renderer.materials = spawnMaterials;

            yield return new WaitForSeconds(0.5f);

            float t = 0f;

            while(t < 1.5f)
            {
                t += Time.deltaTime;
                float value = t / 1.5f;
                for (int i = 0; i < length; i++)
                {
                    spawnMaterials[i].SetFloat("_SplitValue", value);
                }
                renderer.materials = spawnMaterials;

                yield return null;
            }

            renderer.materials = originMaterials;            
        }

        //소멸
        IEnumerator DestroyEnemy()
        {
            yield return new WaitForSeconds(1.5f);

            Material[] destroyMaterials = renderer.materials;
            for (int i = 0; i < length; i++)
            {
                destroyMaterials[i] = dessolveMaterials[i];
                destroyMaterials[i].SetFloat("_SplitValue", 1f);
            }
            renderer.materials = destroyMaterials;

            float t = 0f;

            while (t < 1.5f)
            {
                t += Time.deltaTime;
                float value = t / 1.5f;

                for (int i = 0; i < length; i++)
                {   
                    destroyMaterials[i].SetFloat("_SplitValue", 1f - value);
                }
                renderer.materials = destroyMaterials;

                yield return null;
            }

            Destroy(gameObject);
            //renderer.material = originMaterial;
        }
        #endregion

    }
}