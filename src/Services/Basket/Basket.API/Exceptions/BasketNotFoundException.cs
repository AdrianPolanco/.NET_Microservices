using BuildingBlocks.Exceptions;
using System.Runtime.Serialization;

namespace Basket.API.Exceptions
{
    internal class BasketNotFoundException : NotFoundException
    {
        public BasketNotFoundException(string? message) : base("Basket", message)
        {
        }
    }
}