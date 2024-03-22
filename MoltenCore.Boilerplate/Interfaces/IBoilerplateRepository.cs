using Microsoft.EntityFrameworkCore;
using MoltenCore.Boilerplate.Interfaces.Models;

namespace MoltenCore.Boilerplate.Interfaces
{
    public interface IBoilerplateRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Models.Boilerplate> Get(string id, CancellationToken cancellationToken);

        /// <summary>
        /// Get list
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<Models.Boilerplate>> GetList(CancellationToken cancellationToken);

        /// <summary>
        /// Create boilerplate
        /// </summary>
        /// <param name="boilerplate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<string> Create(BoilerplateCreate boilerplate, CancellationToken cancellationToken);

        /// <summary>
        /// Update existing boilerplate
        /// </summary>
        /// <param name="boilerplate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task Update(string id, BoilerplateUpdate boilerplate, CancellationToken cancellationToken);

        /// <summary>
        /// Delete boilerplate
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task Delete(string id, CancellationToken cancellationToken);
    }


    public abstract class sss : DbContext
    {

    }
}
