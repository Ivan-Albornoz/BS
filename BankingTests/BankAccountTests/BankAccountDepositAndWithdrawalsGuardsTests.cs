using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankingTests.BankAccountTests
{
    public class BankAccountDepositAndWithdrawalsGuardsTests
    {
        [Fact]
        public void BadBehavior()
        {
            var account = new BankAccount(new Mock<ICanCalculateBonuses>().Object, new Mock<INarcOnWithdrawals>().Object);
            var openingBalancee = account.GetBalance();
            var amountToWithdraw = -100;

            account.Withdraw(amountToWithdraw);

            Assert.Equal(5100, account.GetBalance());
        }

        [Fact]
        public void AmountForWithdrawalIsPositive()
        {
            var account = new BankAccount(new Mock<ICanCalculateBonuses>().Object, new Mock<INarcOnWithdrawals>().Object);
            var openingBalancee = account.GetBalance();
            var amountToWithdraw = -100;

            account.Withdraw(amountToWithdraw);

            Assert.Equal(4900, account.GetBalance());
        }
    }
}
