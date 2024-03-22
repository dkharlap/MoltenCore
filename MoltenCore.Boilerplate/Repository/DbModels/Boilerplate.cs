using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MoltenCore.Boilerplate.Repository.DbModels
{
    /// <summary>
    /// Boilerplate database model
    /// </summary>
    [Table("Boilerplate")]
    public class Boilerplate
    {
        public Boilerplate(string id, string createdByUserId, DateTime createdOn)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            CreatedByUserId = createdByUserId ?? throw new ArgumentNullException(nameof(createdByUserId));
            CreatedOn = createdOn;
        }

        /// <summary>
        /// Entity primary key
        /// </summary>
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// ID of the user created entity
        /// </summary>
        [Required]
        public string CreatedByUserId { get; set; }

        /// <summary>
        /// Date and time when entity was created
        /// </summary>
        [Required]
        public DateTime CreatedOn { get; set; }
    }
}
