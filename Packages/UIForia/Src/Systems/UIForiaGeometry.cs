using System;
using System.Collections.Generic;
using UIForia.Util;
using UnityEngine;

namespace UIForia.Rendering {

    public class UIForiaGeometry {

        public Color packedColors;
        public Vector4 objectData;
        public StructList<Vector3> positionList;
        public StructList<Vector4> texCoordList0;
        public StructList<Vector4> texCoordList1;
        public StructList<int> triangleList;
        public Texture mainTexture;


        public UIForiaGeometry() {
            this.positionList = new StructList<Vector3>();
            this.texCoordList0 = new StructList<Vector4>();
            this.texCoordList1 = new StructList<Vector4>();
            this.triangleList = new StructList<int>();
        }
        
        public void EnsureAdditionalCapacity(int vertexCount, int triangleCount) {
            positionList.EnsureAdditionalCapacity(vertexCount);
            texCoordList0.EnsureAdditionalCapacity(vertexCount);
            texCoordList1.EnsureAdditionalCapacity(vertexCount);
            triangleList.EnsureAdditionalCapacity(triangleCount);
        }

        public void Clear() {
            mainTexture = null;
            objectData = default;
            packedColors = default;
            positionList.size = 0;
            texCoordList0.size = 0;
            texCoordList1.size = 0;
            triangleList.size = 0;
        }
        
        public void UpdateSizes(int vertexCount, int triangleCount) {
            positionList.size += vertexCount;
            texCoordList0.size += vertexCount;
            texCoordList1.size += vertexCount;
            triangleList.size += triangleCount;
        }

        public void Quad(float width, float height) {
            
            EnsureAdditionalCapacity(4, 6);
            
            Vector3[] positions = positionList.array;
            Vector4[] texCoord0 = texCoordList0.array;
            int[] triangles = triangleList.array;

            int startVert = positionList.size;
            int startTriangle = triangleList.size;

            ref Vector3 p0 = ref positions[startVert + 0];
            ref Vector3 p1 = ref positions[startVert + 1];
            ref Vector3 p2 = ref positions[startVert + 2];
            ref Vector3 p3 = ref positions[startVert + 3];

            ref Vector4 uv0 = ref texCoord0[startVert + 0];
            ref Vector4 uv1 = ref texCoord0[startVert + 1];
            ref Vector4 uv2 = ref texCoord0[startVert + 2];
            ref Vector4 uv3 = ref texCoord0[startVert + 3];        
            
            p0.x = 0;
            p0.y = 0;
            p0.z = 0;

            p1.x = width;
            p1.y = 0;
            p1.z = 0;

            p2.x = width;
            p2.y = -height;
            p2.z = 0;

            p3.x = 0;
            p3.y = -height;
            p3.z = 0;

            uv0.x = 0;
            uv0.y = 1;

            uv1.x = 1;
            uv1.y = 1;

            uv2.x = 1;
            uv2.y = 0;

            uv3.x = 0;
            uv3.y = 0;

            triangles[startTriangle + 0] = startVert + 0;
            triangles[startTriangle + 1] = startVert + 1;
            triangles[startTriangle + 2] = startVert + 2;
            triangles[startTriangle + 3] = startVert + 2;
            triangles[startTriangle + 4] = startVert + 3;
            triangles[startTriangle + 5] = startVert + 0;

            UpdateSizes(4, 6);
        }
        
        public void FillRectUniformBorder_Miter(float width, float height) {
            Vector3[] positions = positionList.array;
            Vector4[] texCoord0 = texCoordList0.array;
            Vector4[] texCoord1 = texCoordList1.array;
            int[] triangles = triangleList.array;

            int startVert = positionList.size;
            int startTriangle = triangleList.size;

            ref Vector3 p0 = ref positions[startVert + 0];
            ref Vector3 p1 = ref positions[startVert + 1];
            ref Vector3 p2 = ref positions[startVert + 2];
            ref Vector3 p3 = ref positions[startVert + 3];

            ref Vector4 uv0 = ref texCoord0[startVert + 0];
            ref Vector4 uv1 = ref texCoord0[startVert + 1];
            ref Vector4 uv2 = ref texCoord0[startVert + 2];
            ref Vector4 uv3 = ref texCoord0[startVert + 3];

            ref Vector4 data0 = ref texCoord1[startVert + 0];
            ref Vector4 data1 = ref texCoord1[startVert + 1];
            ref Vector4 data2 = ref texCoord1[startVert + 2];
            ref Vector4 data3 = ref texCoord1[startVert + 3];

            p0.x = 0;
            p0.y = 0;
            p0.z = 0;

            p1.x = width;
            p1.y = 0;
            p1.z = 0;

            p2.x = width;
            p2.y = -height;
            p2.z = 0;

            p3.x = 0;
            p3.y = -height;
            p3.z = 0;

            uv0.x = 0;
            uv0.y = 1;

            uv1.x = 1;
            uv1.y = 1;

            uv2.x = 1;
            uv2.y = 0;

            uv3.x = 0;
            uv3.y = 0;

            triangles[startTriangle + 0] = startVert + 0;
            triangles[startTriangle + 1] = startVert + 1;
            triangles[startTriangle + 2] = startVert + 2;
            triangles[startTriangle + 3] = startVert + 2;
            triangles[startTriangle + 4] = startVert + 3;
            triangles[startTriangle + 5] = startVert + 0;

            UpdateSizes(4, 6);
        }

        public void EnsureCapacity(int vertexCount, int triangleCount) {
            
            if (positionList.array.Length < vertexCount) {
                Array.Resize(ref positionList.array, vertexCount);
                Array.Resize(ref texCoordList0.array, vertexCount);
                Array.Resize(ref texCoordList1.array, vertexCount);
            }

            if (triangleList.array.Length < triangleCount) {
                Array.Resize(ref triangleList.array, triangleCount);
            }
            
        }

        public static Mesh CreateQuadMesh(float width, float height) {
            
            Vector3[] positions = new Vector3[4];
            Vector4[] texCoord0 = new Vector4[4];
            int[] triangles = new int[6];

            int startVert = 0;
            int startTriangle = 0;

            ref Vector3 p0 = ref positions[0];
            ref Vector3 p1 = ref positions[1];
            ref Vector3 p2 = ref positions[2];
            ref Vector3 p3 = ref positions[3];

            ref Vector4 uv0 = ref texCoord0[0];
            ref Vector4 uv1 = ref texCoord0[1];
            ref Vector4 uv2 = ref texCoord0[2];
            ref Vector4 uv3 = ref texCoord0[3];        
            
            p0.x = 0;
            p0.y = 0;
            p0.z = 0;

            p1.x = width;
            p1.y = 0;
            p1.z = 0;

            p2.x = width;
            p2.y = -height;
            p2.z = 0;

            p3.x = 0;
            p3.y = -height;
            p3.z = 0;

            uv0.x = 0;
            uv0.y = 1;

            uv1.x = 1;
            uv1.y = 1;

            uv2.x = 1;
            uv2.y = 0;

            uv3.x = 0;
            uv3.y = 0;

            triangles[startTriangle + 0] = startVert + 0;
            triangles[startTriangle + 1] = startVert + 1;
            triangles[startTriangle + 2] = startVert + 2;
            triangles[startTriangle + 3] = startVert + 2;
            triangles[startTriangle + 4] = startVert + 3;
            triangles[startTriangle + 5] = startVert + 0;

            Mesh retn = new Mesh();
            retn.vertices = positions;
            retn.SetUVs(0, new List<Vector4>(texCoord0));

            return retn;
        }

    }

}