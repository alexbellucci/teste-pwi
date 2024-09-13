using test_pwi.DL.DB;
using test_pwi.DL.Request.TodoItem;

namespace test_pwi.DL.Services.BLL
{
    public interface ITodoItemService
    {
        Task<TodoItem> CriarTodoItem(TodoItemRequest TodoItemRequest);

        Task<TodoItem> BuscarTodoItemAsync(long idTodoItem);

        Task<TodoItem> AlterarTodoItem(long idTodoItem, TodoItemRequest TodoItemRequest);

        Task DeletarTodoItemAsync(long idTodoItem);

    }
}
