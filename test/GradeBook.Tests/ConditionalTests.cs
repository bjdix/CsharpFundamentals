using System;
using Xunit;

namespace GradeBook.Tests
{
    public class ConditionalTests
    {
        [Fact]
        public void GreaterThan()
        {
            var book = new Book("");
            book.AddGrade(105);
        }
    }
}

