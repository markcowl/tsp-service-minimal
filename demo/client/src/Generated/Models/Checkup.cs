// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace PetStore.Models
{
    /// <summary> The Checkup. </summary>
    public partial class Checkup
    {
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="Checkup"/>. </summary>
        /// <param name="id"></param>
        /// <param name="vetName"></param>
        /// <param name="notes"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="vetName"/> or <paramref name="notes"/> is null. </exception>
        internal Checkup(int id, string vetName, string notes)
        {
            Argument.AssertNotNull(vetName, nameof(vetName));
            Argument.AssertNotNull(notes, nameof(notes));

            Id = id;
            VetName = vetName;
            Notes = notes;
        }

        /// <summary> Initializes a new instance of <see cref="Checkup"/>. </summary>
        /// <param name="id"></param>
        /// <param name="vetName"></param>
        /// <param name="notes"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal Checkup(int id, string vetName, string notes, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Id = id;
            VetName = vetName;
            Notes = notes;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="Checkup"/> for deserialization. </summary>
        internal Checkup()
        {
        }

        /// <summary> Gets the id. </summary>
        public int Id { get; }
        /// <summary> Gets the vet name. </summary>
        public string VetName { get; }
        /// <summary> Gets the notes. </summary>
        public string Notes { get; }
    }
}
