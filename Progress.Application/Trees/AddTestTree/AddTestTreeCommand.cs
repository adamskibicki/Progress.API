using MediatR;
using Progress.Application.Persistence;

namespace Progress.Application.Trees.AddTestTree
{
    public class AddTestTreeCommand : IRequest<bool>
    {
    }

    public class AddTestTreeCommandHandler : IRequestHandler<AddTestTreeCommand, bool>
    {
        private readonly ApplicationDbContext dbContext;

        public AddTestTreeCommandHandler(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> Handle(AddTestTreeCommand request, CancellationToken cancellationToken)
        {
            var tree = TestDataProvider.GetTree(new TreeNodeRepresentation()
            {
                Children = new TreeNodeRepresentation[]
                {
                    new TreeNodeRepresentation(),
                    new TreeNodeRepresentation(),
                    new TreeNodeRepresentation()
                }
            });

            dbContext.Trees.Add(tree);

            await dbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
