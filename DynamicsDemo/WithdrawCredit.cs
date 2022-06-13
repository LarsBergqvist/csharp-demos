using System;
namespace DynamicsDemo
{
	public class WithdrawCredit: DomainEvent
	{
		public WithdrawCredit(decimal amount)
		{
			Amount = amount;
		}

        public decimal Amount { get; }
    }
}

