namespace DynamicsDemo;

public class Account
{
	public void Apply(DomainEvent @event)
	{
		When((dynamic)@event);
	}

	private void When(AddCredit addCredit)
	{
		Console.WriteLine($"Adding credit, {addCredit.Amount}");
	}

	private void When(WithdrawCredit withdrawCredit)
	{
		Console.WriteLine($"Withdrawing credit, {withdrawCredit.Amount}");
	}
}