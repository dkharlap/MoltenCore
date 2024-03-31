using MoltenCore.Boilerplate.Models;

namespace MoltenCore.Boilerplate.Domain.Interfaces
{
    public interface IBoilerplateDomain
    {
        /// <summary>
        /// Retrieves boilerplate by provided ID
        /// </summary>
        Task<Models.Boilerplate> Get(string id, CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves boilerplate by provided ID
        /// </summary>
        Task<IEnumerable<Models.Boilerplate>> GetList(CancellationToken cancellationToken);

        /// <summary>
        /// Creates the boilerplate
        /// </summary>
        Task<string> Create(BoilerplateCreate boilerplate, CancellationToken cancellationToken);

        /// <summary>
        /// Updates existing boilerplate
        /// </summary>
        Task Update(string id, BoilerplateUpdate boilerplate, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes the boilerplate
        /// </summary>
        Task Delete(string id, CancellationToken cancellationToken);
    }
}
