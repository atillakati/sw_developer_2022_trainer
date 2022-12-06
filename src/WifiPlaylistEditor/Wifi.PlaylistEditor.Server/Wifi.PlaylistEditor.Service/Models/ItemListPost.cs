/*
 * API description for Playlist project
 *
 * This is a sample Playlist Server based on the OpenAPI 3.0 specification.  You can find out more about OpenAPI at [https://oai.github.io/Documentation](https://oai.github.io/Documentation).      Playlist server should provide following functionalities: - Upload item to server - Delete item from server - Get data from one item - Get list of all items on server - Create playlists - Modify playlists - Get a list of all existing playlists Further sources for information   - [Multipart Requests](https://swagger.io/docs/specification/describing-request-body/multipart-requests)   - [Upload And Download Multiple Files Using Web API](https://github.com/JayKrishnareddy/UploadandDownloadFiles)
 *
 * OpenAPI spec version: 1.0.0.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Wifi.PlaylistEditor.Service.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class ItemListPost : IEquatable<ItemListPost>
    {
        /// <summary>
        /// Gets or Sets Items
        /// </summary>

        [DataMember(Name = "items")]
        public List<PlaylistItemPost> Items { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ItemListPost {\n");
            sb.Append("  Items: ").Append(Items).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((ItemListPost)obj);
        }

        /// <summary>
        /// Returns true if ItemListPost instances are equal
        /// </summary>
        /// <param name="other">Instance of ItemListPost to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ItemListPost other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return

                    Items == other.Items ||
                    Items != null &&
                    Items.SequenceEqual(other.Items)
                ;
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                if (Items != null)
                    hashCode = hashCode * 59 + Items.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(ItemListPost left, ItemListPost right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ItemListPost left, ItemListPost right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
