using Unity.Collections.LowLevel.Unsafe;

namespace UIForia {
    
    // The intention here is to index by an elementId and not to provide an Add interface
    public unsafe struct ElementTable<T> where T : unmanaged {

        [NativeDisableUnsafePtrRestriction]
        public T* array;

        public ElementTable(T* array) {
            this.array = array;
        }

        public ref T this[ElementId id] {
            get => ref array[id.index];
        }

        public int ItemSize {
            get => sizeof(T);
        }

    }
    

}