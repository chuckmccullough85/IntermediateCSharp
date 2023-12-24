﻿

using Moq;

namespace EFPayroll
{
    public class CompanyTest
    {
        Company company;
        Mock<Payable> m1;
        Mock<Payable> m2;
        Mock<Payable> m3;  

        public CompanyTest()
        {
            company = new("TestCo", "12-34567");
            m1 = new Mock<Payable>();
            m2 = new Mock<Payable>();
            m3 = new Mock<Payable>();
            company.Hire(m1.Object);
            company.Hire(m2.Object);
            company.Hire(m3.Object);  
        }
        [Fact]
        public void TestCompanyHire()
        {
            Assert.Equal(3, company.Resources.Count());
        }
        [Fact]
        public void TestCompanyPay()
        {
            m1.Setup(e => e.Pay()).Returns(5);
            m2.Setup(e => e.Pay()).Returns(10);
            m3.Setup(e => e.Pay()).Returns(1);
            Assert.Equal(16, company.Pay());
        }
    }
}
