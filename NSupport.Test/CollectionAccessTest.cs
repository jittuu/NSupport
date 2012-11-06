using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using System.Collections;

namespace NSupport.Test {
    public class CollectionAccessTest {
        [Fact]
        public void Test_AddRange_with_null_source() {
            ICollection<int> nullCollection = null;
            Assert.Throws<ArgumentNullException>(() => nullCollection.AddRange(new int[] { 1 }));
        }

        [Fact]
        public void Test_AddRange_with_null_values() {
            var collection = new IntCollection() { 1, 2, 3, 4, 5 };
            collection.AddRange(null);

            Assert.Equal(5, collection.Count);
        }

        [Fact]
        public void Test_AddRange_with_values() {
            var collection = new IntCollection() { 1, 2, 3, 4, 5 };
            collection.AddRange(new int[] { 6, 7 });

            Assert.Equal(7, collection.Count);
        }

        private class IntCollection : ICollection<int> {
            List<int> _values = new List<int>();

            public void Add(int item) {
                _values.Add(item);
            }

            public void Clear() {
                throw new NotImplementedException();
            }

            public bool Contains(int item) {
                throw new NotImplementedException();
            }

            public void CopyTo(int[] array, int arrayIndex) {
                throw new NotImplementedException();
            }

            public int Count {
                get { return _values.Count; }
            }

            public bool IsReadOnly {
                get { throw new NotImplementedException(); }
            }

            public bool Remove(int item) {
                throw new NotImplementedException();
            }

            public IEnumerator<int> GetEnumerator() {
                return _values.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator() {
                return ((IEnumerable)_values).GetEnumerator();
            }
        }
    }
}
