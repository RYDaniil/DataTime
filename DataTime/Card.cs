using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDataTimeLab
{
    struct Card
    {
        public int ID;
        public string Name;
        public DateTime DateBirth;
        public int YearsOld
        {
            get
            {
                return DateTime.Now.Year - DateBirth.Year;
            }
        }
        public char Gender;
        public DateTime DateBegin;
        public int TimeWork
        {
            get
            {
                var month = 0;
                for (int i = 0; i < DateTime.Now.Month; i++)
                {
                    switch (i)
                    {
                        case 1: //January
                        case 3: //Marth
                        case 5: //May
                        case 7: //July
                        case 8: //August
                        case 10: //October
                        case 12: //December
                            month += 31;
                            break;

                        case 2: //February
                            if ((DateBegin.Year % 4) == 0)
                            {
                                month += 29;
                            }
                            else
                            {
                                month += 28;
                            }
                            break;

                        case 4: //April
                        case 6: //June
                        case 9: //September
                        case 11: //November 
                            month += 30;
                            break;
                    }
                }
                for (int i = 0; i < DateBegin.Month; i++)
                {
                    switch (i)
                    {
                        case 1: //January
                        case 3: //Marth
                        case 5: //May
                        case 7: //July
                        case 8: //August
                        case 10: //October
                        case 12: //December
                            month -= 31;
                            break;

                        case 2: //February
                            if ((DateBegin.Year % 4) == 0)
                            {
                                month -= 29;
                            }
                            else
                            {
                                month -= 28;
                            }
                            break;

                        case 4: //April
                        case 6: //June
                        case 9: //September
                        case 11: //November 
                            month -= 30;
                            break;
                    }  
                }
                return (DateTime.Now.Year - DateBegin.Year)*365 + month + DateTime.Now.Day - DateBegin.Day;
            }
        }
        public string Post;
        public int Monie;
    }
}
