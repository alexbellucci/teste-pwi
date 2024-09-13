using test_pwi.DL.DB;
using test_pwi.DL.Request.TodoItem;
using test_pwi.DL.Services.BLL;
using test_pwi.DL.Services.DAL;

namespace test_pwi.BLL
{
    public class TodoItemService : ITodoItemService
    {
        private readonly ITodoItemRepository _todoItemRepository;

        public TodoItemService(ITodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }

        public async Task<TodoItem> CriarTodoItem(TodoItemRequest todoItemRequest)
        {
            TodoItem todoItem = new TodoItem
            {
                Titulo = todoItemRequest.Titulo,
                Descricao = todoItemRequest.Descricao,
                DataCriacao = todoItemRequest.DataCriacao,
                DataConclusao = todoItemRequest.DataConclusao,
                Concluido = todoItemRequest.Concluido,
            };
            return await _todoItemRepository.Create(todoItem);
        }

        public async Task<TodoItem> BuscarTodoItemAsync(long idTodoItem)
        {
            return await _todoItemRepository.GetById(idTodoItem);
        }

        public async Task<TodoItem> AlterarTodoItem(long idTodoItem, TodoItemRequest todoItemRequest)
        {
            TodoItem todoItem = new TodoItem
            {
                Titulo = todoItemRequest.Titulo,
                Descricao = todoItemRequest.Descricao,
                DataCriacao = todoItemRequest.DataCriacao,
                DataConclusao = todoItemRequest.DataConclusao,
                Concluido = todoItemRequest.Concluido,
            };

            return await _todoItemRepository.Update(idTodoItem, todoItem);
        }

        public async Task DeletarTodoItemAsync(long idTodoItem)
        {
            await _todoItemRepository.Delete(idTodoItem);
        }
    }
}
