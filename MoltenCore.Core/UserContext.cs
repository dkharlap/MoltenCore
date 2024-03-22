using MoltenCore.Core.Interfaces;

namespace MoltenCore.Core
{
    public class UserContext : IUserContext
    {
        public string UserId { get; }
        public UserContext(string userId)
        {
            UserId = userId;
        }
    }
}