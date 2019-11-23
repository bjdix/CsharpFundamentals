using System;
using Xunit;

/* Testing is tyring to prove or verify that
the software written is behaving correctly, 
but it also means testing edge cases and to 
obeserve how software behaves in these edge
cases. */
namespace GradeBook.Tests
{
    public class BookTests
    {
        /* Types, members, and other entities in a
        C# program support modifiers that control certain
        aspects of their behavior. For example, the
        accessibility of a method is controlled using the 
        public, protected, internal, and private modifiers. 
        C# generalizes this capability such that user-defined 
        types of declarative information can be attached to 
        program entities and retrieved at run-time. Programs
        specify this additional declarative information by
        defining and using attributes.  */
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            // arrange
            var book = new InMemoryBook("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // act
           var result = book.GetStatistics();

            // assert
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
            Assert.Equal('B', result.Letter);

        }
    }
}
