using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemberRegistration.Business.Abstract;
using MemberRegistration.Business.DependencyResolvers.Ninject;
using MemberRegistration.Entities.Concrete;

namespace MemberRegistration.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var memberService = InstanceFactory.GetInstance<IMemberService>();
            memberService.Add(new Member
            {
                FirstName = "ZEYNEP",
                LastName = "MİRZOOĞLU",
                DateOfBirth = new DateTime(1990, 2, 4),
                Email = "zeynepmirzooglu@gmail.com",
                TcNo = "43333770134"
            });
            //memberService.Add(new Member
            //{
            //    FirstName = "ABDÜLGANİ",LastName = "MİRZOOĞLU",DateOfBirth = new DateTime(1983,8,23),TcNo = "43381768572",Email = "ganimirzooglu@yahoo.com"
            //});
            Console.WriteLine("Eklendi.");
            Console.ReadLine();
        }
    }
}
