namespace Snippy.Data.UnitOfWork
{
    using Snippy.Data.Repositories;
    using Snippy.Models;

    public interface ISnippyData
    {
        IRepository<User> Users { get; }

        IRepository<Snippet> Snippets { get; }

        IRepository<Language> Languages { get; }

        IRepository<Label> Labels { get; }

        IRepository<Comment> Comments { get; }

        void SaveChanges();
    }
}
