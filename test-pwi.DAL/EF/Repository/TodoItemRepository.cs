using test_pwi.DL.DB;
using test_pwi.DL.Services.DAL;

namespace test_pwi.DAL.EF
{
    public class TodoItemRepository : GenericRepository<TodoItem>, ITodoItemRepository
    {
        public TodoItemRepository(TestPwiContext testPwiContext)
        : base(testPwiContext)
        {
        }
    }
}
