using System;
namespace DynamicsDemo
{
	public class AddCredit : DomainEvent
	{
		public AddCredit(decimal amount)
		{
			Amount = amount;
		}

        public decimal Amount { get; }
    }
}

