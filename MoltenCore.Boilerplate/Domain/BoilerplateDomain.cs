using MoltenCore.Boilerplate.Domain.Interfaces;
using MoltenCore.Boilerplate.Models;
using MoltenCore.Boilerplate.Repository.Interfaces;
using System.Threading;

namespace MoltenCore.Boilerplate.Domain
{
    public class BoilerplateDomain : IBoilerplateDomain
    {
        public BoilerplateDomain(IBoilerplateRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task<Models.Boilerplate> Get(string id, CancellationToken cancellationToken)
        {
            return _repository.Get(id, cancellationToken);
        }

        public Task<IEnumerable<Models.Boilerplate>> GetList(CancellationToken cancellationToken)
        {
            return _repository.GetList(cancellationToken);
        }

        public Task<string> Create(BoilerplateCreate boilerplate, CancellationToken cancellationToken)
        {
            return _repository.Create(boilerplate, cancellationToken);
        }

        public Task Delete(string id, CancellationToken cancellationToken)
        {
            return _repository.Delete(id, cancellationToken);
        }

        public Task Update(string id, BoilerplateUpdate boilerplate, CancellationToken cancellationToken)
        {
            return _repository.Update(id, boilerplate, cancellationToken);
        }

        private readonly IBoilerplateRepository _repository;
    }
}
