using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Todo.Data.Entities;
using Todo.EntityModelMappers.TodoItems;
using Todo.EntityModelMappers.TodoLists;
using Todo.Models.TodoItems;
using Xunit;

namespace Todo.Tests
{
    public class TodoListDetailViewmodelFactoryTests
    {
        private readonly TodoList srcTodoItem;

        public TodoListDetailViewmodelFactoryTests()
        {
            var todoList = new TestTodoListBuilder(new IdentityUser("alice@example.com"), "shopping")
                    .WithItem("bread", Importance.Medium)
                    .WithItem("milk", Importance.Low)
                    .WithItem("egg", Importance.High)
                    .Build();

            srcTodoItem = todoList;
        }

        [Fact]
        public void Create_TodoListMappedByImportance()
        {
            var viewmodel = TodoListDetailViewmodelFactory.Create(srcTodoItem);
            var items = viewmodel.Items.ToList();
            Assert.Equal(Importance.High, items[0].Importance);
            Assert.Equal(Importance.Medium, items[1].Importance);
            Assert.Equal(Importance.Low, items[2].Importance);
        }
    }
}
