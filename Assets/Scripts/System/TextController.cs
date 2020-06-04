using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : BaseMeshEffect
{
    float time = 0;
    float radius = 1.5f;

    public override void ModifyMesh(UnityEngine.UI.VertexHelper vh)
    {
        if (!IsActive())
            return;

        List<UIVertex> uIVertices = new List<UIVertex>();
        vh.GetUIVertexStream(uIVertices);

        TextMove(ref uIVertices);

        vh.Clear();
        vh.AddUIVertexTriangleStream(uIVertices);

    }

    void TextMove( ref List<UIVertex> uIVertices)
    {
        for (int c = 0; c < uIVertices.Count; c++)
        {
            float rad = Random.Range(0, 360) * Mathf.Deg2Rad;
            Vector3 dir = new Vector3(radius * Mathf.Cos(rad), radius * Mathf.Sin(rad), 0);

            for (int i = 0; i < 6; i++)
            {
                var vert = uIVertices[c + i];
                vert.position = vert.position + dir;
                uIVertices[c + i] = vert;
            }
        }
    }

    void Update()
    {
        time += Time.deltaTime;

        if(time >0.05f)
        {
            time =0;
            base.GetComponent<Graphic>().SetVerticesDirty();
        }

    }
}
