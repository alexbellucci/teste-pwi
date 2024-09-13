using Microsoft.AspNetCore.Mvc;
using test_pwi.DL.DB;
using test_pwi.DL.Request.TodoItem;
using test_pwi.DL.Services.BLL;

namespace test_pwi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoItemController : ControllerBase
    {
        private readonly ITodoItemService _todoItemService;

        public TodoItemController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

        [HttpGet("{todoItemId:long}")]
        public async Task<TodoItem> Obter(long todoItemId)
        {
            return await _todoItemService.BuscarTodoItemAsync(todoItemId);
        }

        [HttpPost]
        public async Task<TodoItem> CriarTodoItemAsync(TodoItemRequest todoItemRequest)
        {
            return await _todoItemService.CriarTodoItem(todoItemRequest);
        }

        [HttpPut("{todoItemId:long}")]
        public async Task<TodoItem> AtualizarTodoItemAsync(long todoItemId, TodoItemRequest todoItemRequest)
        {
            return await _todoItemService.AlterarTodoItem(todoItemId, todoItemRequest);
        }

        [HttpDelete("{todoItemId:long}")]
        public async Task DeletarTodoItem(long todoItemId)
        {
            await _todoItemService.DeletarTodoItemAsync(todoItemId);
        }
    }
}
