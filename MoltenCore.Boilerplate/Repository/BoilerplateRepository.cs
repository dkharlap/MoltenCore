using Microsoft.EntityFrameworkCore;
using MoltenCore.Boilerplate.Models;
using MoltenCore.Boilerplate.Repository.Interfaces;
using MoltenCore.Interfaces;

namespace MoltenCore.Boilerplate.Repository
{
    public class BoilerplateRepository(IUserContext userContext, BoilerplateDbContext dbContext, BoilerplateDbContext dbReadOnlyContext) : IBoilerplateRepository
    {
        /// <summary>
        /// See <see cref="IBoilerplateRepository.Create"/>
        /// </summary>
        public async Task<string> Create(BoilerplateCreate boilerplate, CancellationToken cancellationToken)
        {
            var dbSet = _dbContext.Boilerplates;
            var entity = new DbModels.Boilerplate(
                Guid.NewGuid().ToString(),
                _userContext.UserId,
                DateTime.UtcNow
            );

            await dbSet.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

        /// <summary>
        /// See <see cref="IBoilerplateRepository.Get"/>
        /// </summary>
        public async Task<Models.Boilerplate> Get(string id, CancellationToken cancellationToken)
        {
            var entity = await _dbReadOnlyContext.Boilerplates.FindAsync([id], cancellationToken) 
                ?? throw new ApplicationExceptionCode(ExceptionCode.NotFound, "Could not find boilerplate with id " + id);
           
            return new Models.Boilerplate(
                entity.Id,
                entity.CreatedByUserId,
                new DateTime(entity.CreatedOn.Ticks, DateTimeKind.Utc)
            );
        }

        /// <summary>
        /// See <see cref="IBoilerplateRepository.Update"/>
        /// </summary>
        public async Task Update(string id, BoilerplateUpdate boilerplate, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Boilerplates.FindAsync([id], cancellationToken)
                ?? throw new ApplicationExceptionCode(ExceptionCode.NotFound, "Could not find boilerplate with id " + id);

            // Add code updating fields by updating them one by one using entity.[Property] = boilerplate.property;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// See <see cref="IBoilerplateRepository.Delete"/>
        /// </summary>
        public async Task Delete(string id, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Boilerplates.FindAsync([id], cancellationToken) 
                ?? throw new ApplicationExceptionCode(ExceptionCode.NotFound, "Could not find boilerplate with id " + id);

            _dbContext.Boilerplates.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Models.Boilerplate>> GetList(CancellationToken cancellationToken)
        {
            return await _dbReadOnlyContext.Boilerplates.Select(
                e => new Models.Boilerplate(e.Id, e.CreatedByUserId, e.CreatedOn)
            ).ToListAsync(cancellationToken: cancellationToken);
        }

        #region Private members
        private readonly BoilerplateDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        private readonly BoilerplateDbContext _dbReadOnlyContext = dbReadOnlyContext ?? throw new ArgumentNullException(nameof(dbReadOnlyContext));
        private readonly IUserContext _userContext = userContext;
        #endregion
    }
}

