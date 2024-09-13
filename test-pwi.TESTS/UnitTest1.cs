using Moq;
using System.Threading.Tasks;
using test_pwi.BLL;
using test_pwi.DL.DB;
using test_pwi.DL.Request.TodoItem;
using test_pwi.DL.Services.DAL;
using Xunit;
namespace test_pwi.TESTS
{
    public class TodoItemServiceTests
    {
        private readonly Mock<ITodoItemRepository> _mockRepo;
        private readonly TodoItemService _service;
        public TodoItemServiceTests()
        {
            _mockRepo = new Mock<ITodoItemRepository>();
            _service = new TodoItemService(_mockRepo.Object);
        }
        [Fact]
        public async Task CriarTodoItem_ShouldReturnCreatedTodoItem()
        {
            // Arrange
            var todoItemRequest = new TodoItemRequest
            {
                Titulo = "Test Title",
                Descricao = "Test Description",
                DataCriacao = DateTime.Now,
                DataConclusao = DateTime.Now.AddDays(1),
                Concluido = false
            };
            var expectedTodoItem = new TodoItem
            {
                Titulo = "Test Title",
                Descricao = "Test Description",
                DataCriacao = todoItemRequest.DataCriacao,
                DataConclusao = todoItemRequest.DataConclusao,
                Concluido = todoItemRequest.Concluido
            };
            _mockRepo.Setup(repo => repo.Create(It.IsAny<TodoItem>())).ReturnsAsync(expectedTodoItem);
            // Act
            var result = await _service.CriarTodoItem(todoItemRequest);
            // Assert
            Assert.Equal(expectedTodoItem.Titulo, result.Titulo);
            Assert.Equal(expectedTodoItem.Descricao, result.Descricao);
            Assert.Equal(expectedTodoItem.DataCriacao, result.DataCriacao);
            Assert.Equal(expectedTodoItem.DataConclusao, result.DataConclusao);
            Assert.Equal(expectedTodoItem.Concluido, result.Concluido);
        }
        [Fact]
        public async Task BuscarTodoItemAsync_ShouldReturnTodoItem()
        {
            // Arrange
            var idTodoItem = 1;
            var expectedTodoItem = new TodoItem { Id = idTodoItem, Titulo = "Test Title" };
            _mockRepo.Setup(repo => repo.GetById(idTodoItem)).ReturnsAsync(expectedTodoItem);
            // Act
            var result = await _service.BuscarTodoItemAsync(idTodoItem);
            // Assert
            Assert.Equal(expectedTodoItem.Id, result.Id);
            Assert.Equal(expectedTodoItem.Titulo, result.Titulo);
        }
        [Fact]
        public async Task AlterarTodoItem_ShouldReturnUpdatedTodoItem()
        {
            // Arrange
            var idTodoItem = 1;
            var todoItemRequest = new TodoItemRequest
            {
                Titulo = "Updated Title",
                Descricao = "Updated Description",
                DataCriacao = DateTime.Now,
                DataConclusao = DateTime.Now.AddDays(1),
                Concluido = true
            };
            var expectedTodoItem = new TodoItem
            {
                Titulo = "Updated Title",
                Descricao = "Updated Description",
                DataCriacao = todoItemRequest.DataCriacao,
                DataConclusao = todoItemRequest.DataConclusao,
                Concluido = todoItemRequest.Concluido
            };
            _mockRepo.Setup(repo => repo.Update(idTodoItem, It.IsAny<TodoItem>())).ReturnsAsync(expectedTodoItem);
            // Act
            var result = await _service.AlterarTodoItem(idTodoItem, todoItemRequest);
            // Assert
            Assert.Equal(expectedTodoItem.Titulo, result.Titulo);
            Assert.Equal(expectedTodoItem.Descricao, result.Descricao);
            Assert.Equal(expectedTodoItem.DataCriacao, result.DataCriacao);
            Assert.Equal(expectedTodoItem.DataConclusao, result.DataConclusao);
            Assert.Equal(expectedTodoItem.Concluido, result.Concluido);
        }
        [Fact]
        public async Task DeletarTodoItemAsync_ShouldCallDeleteMethod()
        {
            // Arrange
            var idTodoItem = 1;
            _mockRepo.Setup(repo => repo.Delete(idTodoItem)).Returns(Task.CompletedTask);
            // Act
            await _service.DeletarTodoItemAsync(idTodoItem);
            // Assert
            _mockRepo.Verify(repo => repo.Delete(idTodoItem), Times.Once);
        }
    }
}
