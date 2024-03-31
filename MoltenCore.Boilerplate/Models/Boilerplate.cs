namespace MoltenCore.Boilerplate.Models
{
    public class Boilerplate : BoilerplateBase
    {
        public Boilerplate(string id, string createdByUserId, DateTime createdOn)
        {
            BoilerplateValidator.ValidateId(id);
            BoilerplateValidator.ValidateCreatedByUserId(createdByUserId);

            Id = id;
            CreatedByUserId = createdByUserId;
            CreatedOn = createdOn;
        }

        /// <summary>
        /// Boilerplate ID
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// ID of the user who created Boilerplate
        /// </summary>
        public string CreatedByUserId { get; }

        /// <summary>
        /// Date and time when Boilerplate was created, in UTC
        /// </summary>
        public DateTime CreatedOn { get; }
    }

    /// <summary>
    /// Create Boilerplate
    /// </summary>
    public class BoilerplateCreate : BoilerplateBase
    {
    }

    /// <summary>
    /// Update Boilerplate
    /// </summary>
    public class BoilerplateUpdate : BoilerplateBase
    {
    }

    /// <summary>
    /// Boilerplate base model
    /// </summary>
    public class BoilerplateBase
    {
    }

    internal static class BoilerplateValidator
    {
        public static void ValidateId(string Id)
        {
            if (Id == null) throw new ArgumentNullException(nameof(Id));
        }

        public static void ValidateCreatedByUserId(string CreatedByUserId)
        {
            if (CreatedByUserId == null) throw new ArgumentNullException(nameof(CreatedByUserId));
        }
    }
}
