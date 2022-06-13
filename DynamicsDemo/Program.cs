using DynamicsDemo;

var addCredit = new AddCredit(2.345M);
var withdrawCredit = new WithdrawCredit(3.4556M);
var account = new Account();
account.Apply(addCredit);
account.Apply(withdrawCredit);
