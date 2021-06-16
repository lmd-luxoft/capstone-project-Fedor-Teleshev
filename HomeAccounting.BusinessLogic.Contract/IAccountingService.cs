using HomeAccounting.BusinessLogic.Contract.Dto;

namespace HomeAccounting.BusinessLogic.Contract
{
    public interface IAccountingService
    {
        string CreateSimpleAccount(AccountDto account);
        string CreateCash(CashDto account);
        string CreateDeposit(DepositDto account);
        string CreateProperty(PropertyDto account);
    }
}
