using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemberRegistration.Business.KpsServiceReference;
using MemberRegistration.Entities.Concrete;

namespace MemberRegistration.Business.ServiceAdapters
{
    public class KpsServiceAdapter:IKpsService
    {
        //public bool ValidateUser(Member member)
        //{
        //    KpsServiceReference.KPSPublicSoapClient client = new KPSPublicSoapClient();
        //    return client.TCKimlikNoDogrula(Convert.ToInt64(member.TcNo), member.FirstName,
        //        member.LastName, member.DateOfBirth.Year);
        //}
        public bool ValidateUser(Member member)
        {
            if (CheckTcNo(member.TcNo) == 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int CheckTcNo(string tcNo)
        {
            int checkAlgoritm = 0, sumEven = 0, sumOdd = 0, sumNumbers = 0, number10 = 0, number11 = 0;

            if (tcNo.Length == 11) checkAlgoritm = 1;

            foreach (char chr in tcNo) { if (Char.IsNumber(chr)) checkAlgoritm = 2; }

            if (tcNo.Substring(0, 1) != "0") checkAlgoritm = 3;

            int[] arrTC = System.Text.RegularExpressions.Regex.Replace(tcNo, "[^0-9]", "").Select(x => (int)Char.GetNumericValue(x)).ToArray();

            for (int i = 0; i < tcNo.Length; i++)
            {
                sumNumbers += Convert.ToInt32(arrTC[i]);
                //Çift sayıları bulmak ve toplamak için yazılan kod bloğu :
                if (((i + 1) % 2) == 0)
                {
                    if (i + 1 != 10) sumOdd += Convert.ToInt32(arrTC[i]);
                    else number10 = Convert.ToInt32(arrTC[i]);
                }
                else
                {
                    //Tek sayıları bulmak ve toplamlarını elde etmek için yazılan kod bloğu:
                    if (i + 1 != 11) sumEven += Convert.ToInt32(arrTC[i]);
                    else
                    {
                        number11 = Convert.ToInt32(arrTC[i]);
                        sumNumbers = sumNumbers - number11;
                    }
                }
            }

            int sumEven1 = (sumEven * 7) - sumOdd;
            int sumEvenMod = sumEven1 % 10;
            if (number10 == sumEvenMod) checkAlgoritm = 4;

            int sumOddMod = sumNumbers % 10;
            if (number11 == sumOddMod) checkAlgoritm = 5;

            return checkAlgoritm;
        }

    }
}
