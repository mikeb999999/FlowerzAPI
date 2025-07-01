using FlowerzAPI.Flowerz.Models.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace UnitTests.Extensions
{
    public static
        class AssertExtensions
    {
        /// <summary> Validate the expected error </summary>
        public static void AssertError(this IActionResult response, HttpStatusCode statusCode, string message)
        {
            //Cast the result as an object
            var result = response as ObjectResult;

            //Assert - Validate the result
            Assert.Equal(result.StatusCode, (int)statusCode);

            //Assert - Check that an error object was returned
            var error = result.Value as ErrorInfo;
            Assert.NotNull(error);
            Assert.Equal(error.Message, message);
        }
    }
 
}
