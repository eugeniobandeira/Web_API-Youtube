using BookAPI.Model;

namespace BookAPI.Repository
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> Get();

        Task<Book> Get(int id);

        Task<Book> Create(Book book);

        Task<Book> Update(Book book);

        Task<Book> Delete(int id);
    }
}
