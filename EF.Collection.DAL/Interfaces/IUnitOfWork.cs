using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TeamworkSystem.DataAccessLayer.Entities;
using EFCollections.DAL.Interfaces.Repositories;

namespace EFCollections.DAL.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        /*UserManager<User> UserManager { get; }

        SignInManager<User> SignInManager { get; }

        IProjectsRepository ProjectsRepository { get; }

        IRatingsRepository RatingsRepository { get; }

        ITeamsRepository TeamsRepository { get; }

        ITicketsRepository TicketsRepository { get; }*/

        Task SaveChangesAsync();
    }
}
