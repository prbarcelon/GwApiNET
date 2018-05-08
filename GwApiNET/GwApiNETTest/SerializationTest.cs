using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GwApiNET;
using GwApiNET.ResponseObjects;
using NUnit.Framework;

namespace GwApiNETTest
{

    public class SerializationTest
    {
        [Test]
        public void BinarySerializationTest()
        {
            Hashtable table = new Hashtable();

            EntryCollection<EventEntry> entries = new EntryCollection<EventEntry>();
            table.Add("Test", entries);

            byte[] serialized = GwApiNET.BinarySerializer.BinarySerialize(table);

            Hashtable table2 = BinarySerializer.BinaryDeserialize<Hashtable>(serialized);

            Assert.AreEqual(table.Count, table2.Count);
        }
    }
}
