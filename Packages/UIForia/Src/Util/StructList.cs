using System;
using Vertigo;

namespace UIForia.Util {

    public class StructList<T> where T : struct {

        public T[] array;
        public int size;

        public T[] Array => array;

        public StructList(int capacity = 8) {
            this.size = 0;
            this.array = new T[capacity];
        }

        public int Count {
            get { return size; }
            set { size = value; }
        }

        public void Add(in T item) {
            if (size + 1 > array.Length) {
                System.Array.Resize(ref array, (size + 1) * 2);
            }

            array[size] = item;
            size++;
        }

        public void AddUnsafe(in T item) {
            array[size++] = item;
        }

        public void AddRange(T[] collection) {
            if (size + collection.Length >= array.Length) {
                System.Array.Resize(ref array, size + collection.Length * 2);
            }

            System.Array.Copy(collection, 0, array, size, collection.Length);
            size += collection.Length;
        }

        public void AddRange(T[] collection, int start, int count) {
            if (size + count >= array.Length) {
                System.Array.Resize(ref array, size + count * 2);
            }

            System.Array.Copy(collection, start, array, size, count);
            size += count;
        }

        public void AddRange(StructList<T> collection) {
            if (size + collection.size >= array.Length) {
                System.Array.Resize(ref array, size + collection.size * 2);
            }

            System.Array.Copy(collection.array, 0, array, size, collection.size);
            size += collection.size;
        }

        public void AddRange(StructList<T> collection, int start, int count) {
            if (size + collection.size >= array.Length) {
                System.Array.Resize(ref array, size + count * 2);
            }

            System.Array.Copy(collection.array, start, array, size, count);
            size += count;
        }

        public void EnsureCapacity(int capacity) {
            if (array.Length < capacity) {
                System.Array.Resize(ref array, capacity * 2);
            }
        }

        public void EnsureAdditionalCapacity(int capacity) {
            if (array.Length < size + capacity) {
                System.Array.Resize(ref array, (size + capacity) * 2);
            }
        }

        public void QuickClear() {
            size = 0;
        }

        public void Clear() {
            size = 0;
            System.Array.Clear(array, 0, array.Length);
        }

        public T this[int idx] {
            get => array[idx];
            set => array[idx] = value;
        }

        public void SetFromRange(T[] source, int start, int count) {
            if (array.Length <= count) {
                System.Array.Resize(ref array, count * 2);
            }

            System.Array.Copy(source, start, array, 0, count);
            size = count;
        }

        public void ShiftRight(int startIndex, int count) {
            if (count <= 0) return;
            if (startIndex < 0) startIndex = 0;
            EnsureCapacity(startIndex + count + count); // I think this is too big
            System.Array.Copy(array, startIndex, array, startIndex + count, count);
            System.Array.Clear(array, startIndex, count);
            size += count;
        }

        public void ShiftLeft(int startIndex, int count) {
            if (count <= 0) return;
            if (startIndex < 0) startIndex = 0;
            System.Array.Copy(array, startIndex, array, startIndex - count, size - startIndex);
            System.Array.Clear(array, size - count, count);
            size -= count;
        }

        private static readonly LightList<StructList<T>> s_Pool = new LightList<StructList<T>>();

        public static StructList<T> Get() {
            StructList<T> retn = s_Pool.Count > 0 ? s_Pool.RemoveLast() : new StructList<T>();
            retn.isInPool = false;
            return retn;
        }

        private bool isInPool;

        public static void Release(ref StructList<T> toPool) {
            toPool.Clear();
            if (toPool.isInPool) return;
            toPool.isInPool = true;
            s_Pool.Add(toPool);
        }

        public void Insert(int index, in T item) {
            if (size + 1 >= array.Length) {
                ArrayPool<T>.Resize(ref array, (size + 1) * 2);
            }

            size++;
            if (index < 0 || index > array.Length) {
                throw new IndexOutOfRangeException();
            }

            System.Array.Copy(array, index, array, index + 1, size - index);
            array[index] = item;
        }

    }

}