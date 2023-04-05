using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EFCollections.DAL.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly TeamworkSystemContext databaseContext;

        public UserManager<User> UserManager { get; }

        public SignInManager<User> SignInManager { get; }

        public IProjectsRepository ProjectsRepository { get; }

        public IRatingsRepository RatingsRepository { get; }

        public ITeamsRepository TeamsRepository { get; }

        public ITicketsRepository TicketsRepository { get; }

        public async Task SaveChangesAsync()
        {
            await databaseContext.SaveChangesAsync();
        }

        public UnitOfWork(
            TeamworkSystemContext databaseContext,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IProjectsRepository projectsRepository,
            IRatingsRepository ratingsRepository,
            ITeamsRepository teamsRepository,
            ITicketsRepository ticketsRepository)
        {
            this.databaseContext = databaseContext;
            UserManager = userManager;
            SignInManager = signInManager;
            ProjectsRepository = projectsRepository;
            RatingsRepository = ratingsRepository;
            TeamsRepository = teamsRepository;
            TicketsRepository = ticketsRepository;
        }
    }
}
