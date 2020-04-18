using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Challenge14_CorrectChange
{
    class ChangeCalculator
    {
        private List<Money> _moneyList;

        public ChangeCalculator(List<Money> moneyList)
        {
            _moneyList = moneyList.OrderByDescending(o => o.Value).ToList();
        }

        public List<(Money Money, uint Amount)>  GetChange(decimal owed, decimal paid, decimal maxChangeSize = decimal.MaxValue)
        {
            if (owed > paid)
                throw new ArgumentOutOfRangeException("Amount paid can not be lower than amount owed!");

            var changeList = new List<(Money, uint)>();

            decimal changedOwed = paid - owed;
            foreach(var money in _moneyList)
            {
                if (money.Value > maxChangeSize)
                    continue;

                if (money.Value < changedOwed)
                {
                    decimal amountOfMoney = Math.Floor(changedOwed / money.Value);

                    changeList.Add((money, Convert.ToUInt32(amountOfMoney)));

                    changedOwed -= (money.Value * amountOfMoney);
                }
            }

            if (changedOwed > 0)
            {
                Console.WriteLine($"Unaccounted for change value of {changedOwed}!");
            }


            return changeList;
        }
    }
}
