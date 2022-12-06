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
    public partial class Playlist : IEquatable<Playlist>
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [Required]

        [DataMember(Name = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [Required]

        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Duration
        /// </summary>
        [Required]

        [DataMember(Name = "duration")]
        public long? Duration { get; set; }

        /// <summary>
        /// Gets or Sets Autor
        /// </summary>
        [Required]

        [DataMember(Name = "autor")]
        public string Autor { get; set; }

        /// <summary>
        /// Gets or Sets DateOfCreation
        /// </summary>
        [Required]

        [DataMember(Name = "dateOfCreation")]
        public DateTime? DateOfCreation { get; set; }

        /// <summary>
        /// Gets or Sets Items
        /// </summary>
        [Required]

        [DataMember(Name = "items")]
        public List<PlaylistItem> Items { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Playlist {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Duration: ").Append(Duration).Append("\n");
            sb.Append("  Autor: ").Append(Autor).Append("\n");
            sb.Append("  DateOfCreation: ").Append(DateOfCreation).Append("\n");
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
            return obj.GetType() == GetType() && Equals((Playlist)obj);
        }

        /// <summary>
        /// Returns true if Playlist instances are equal
        /// </summary>
        /// <param name="other">Instance of Playlist to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Playlist other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Id == other.Id ||
                    Id != null &&
                    Id.Equals(other.Id)
                ) &&
                (
                    Name == other.Name ||
                    Name != null &&
                    Name.Equals(other.Name)
                ) &&
                (
                    Duration == other.Duration ||
                    Duration != null &&
                    Duration.Equals(other.Duration)
                ) &&
                (
                    Autor == other.Autor ||
                    Autor != null &&
                    Autor.Equals(other.Autor)
                ) &&
                (
                    DateOfCreation == other.DateOfCreation ||
                    DateOfCreation != null &&
                    DateOfCreation.Equals(other.DateOfCreation)
                ) &&
                (
                    Items == other.Items ||
                    Items != null &&
                    Items.SequenceEqual(other.Items)
                );
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
                if (Id != null)
                    hashCode = hashCode * 59 + Id.GetHashCode();
                if (Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                if (Duration != null)
                    hashCode = hashCode * 59 + Duration.GetHashCode();
                if (Autor != null)
                    hashCode = hashCode * 59 + Autor.GetHashCode();
                if (DateOfCreation != null)
                    hashCode = hashCode * 59 + DateOfCreation.GetHashCode();
                if (Items != null)
                    hashCode = hashCode * 59 + Items.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(Playlist left, Playlist right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Playlist left, Playlist right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
