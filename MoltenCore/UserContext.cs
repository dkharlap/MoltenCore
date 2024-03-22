using MoltenCore.Interfaces;

namespace MoltenCore
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
