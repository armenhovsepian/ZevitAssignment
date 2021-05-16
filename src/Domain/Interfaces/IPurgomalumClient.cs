using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPurgomalumClient
    {
        Task<bool> CheckForProfanity(string text);
    }
}