using System;

namespace OOProgramming{

class LineOfCreditAccount : BankAccount
{
    // <ConstructLineOfCredit>
    public LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimit) : base(name, initialBalance, -creditLimit)
    {
    }
    // </ConstructLineOfCredit>

    // <ApplyMonthendInterest>
    public override void PerformMonthEndTransactions()
    {
        if (Balance < 0)
        {
            // Уменьшить баланс чтобы получить начисления
            decimal interest = -Balance * 0.07m;
            MakeWithdrawal(interest, DateTime.Now, "Charge monthly interest");
        }
    }
    // </ApplyMonthendInterest>

    // <AddOverdraftFee>
    protected override Transaction? CheckWithdrawalLimit(bool isOverdrawn) =>
        isOverdrawn
        ? new Transaction(-20, DateTime.Now, "Apply overdraft fee")
        : default;
    // </AddOverdraftFee>
}
}
