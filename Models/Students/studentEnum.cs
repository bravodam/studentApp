﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code360_Management.Models.Students
{
    public enum gender
    {
        Male,
        Female
    }

    public enum addmissionType
    {
        Paid,
        Income_Sharing
    }
    public enum maritalStatus
    {
        Single,
        Married,
        Divorced
    }

    public enum nationality
    {
        Afghanistan,
        Albania,
        Algeria,
        Andorra,
        Angola,
        Antigua_Barbuda,
        Argentina,
        Armenia,
        Australia,
        Austria,
        Azerbaijan,
        Bahamas,
        Bahrain,
        Bangladesh,
        Barbados,
        Belarus,
        Belgium,
        Belize,
        Benin,
        Bhutan,
        Bolivia,
        Bosnia_and_Herzegovina,
        Botswana,
        Brazil,
        Brunei,
        Bulgaria,
        Burkina_Faso,
        Burundi,
        Cabo_Verde,
        Cambodia,
        Cameroon,
        Canada,
        Central_African_Republic,
        Chad,
        Chile,
        China,
        Colombia,
        Comoros,
        Congo_Democratic_Republic_of_the,
        Congo_Republic_of_the,
        Costa_Rica,
        Cote_d_Ivoire,
        Croatia,
        Cuba,
        Cyprus,
        Czechia,
        Denmark,
        Djibouti,
        Dominica,
        Dominican_Republic,
        Ecuador,
        Egypt,
        El_Salvador,
        Equatorial_Guinea,
        Eritrea,
        Estonia,
        Eswatini_formerly_Swaziland,
        Ethiopia,

        Fiji,
        Finland,
        France,
        Gabon,
        Gambia,
        Georgia,
        Germany,
        Ghana,
        Greece,
        Grenada,
        Guatemala,
        Guinea,
        Guinea_Bissau,
        Guyana,
        Haiti,
        Honduras,
        Hungary,

        Iceland,
        India,
        Indonesia,
        Iran,
        Iraq,
        Ireland,
        Israel,
        Italy,

        Jamaica,
        Japan,
        Jordan,

        Kazakhstan,
        Kenya,
        Kiribati,
        Kosovo,
        Kuwait,
        Kyrgyzstan,

        Laos,
        Latvia,
        Lebanon,
        Lesotho,
        Liberia,
        Libya,
        Liechtenstein,
        Lithuania,
        Luxembourg,

        Madagascar,
        Malawi,
        Malaysia,
        Maldives,
        Mali,
        Malta,
        Marshall_Islands,
        Mauritania,
        Mauritius,
        Mexico,
        Micronesia,
        Moldova,
        Monaco,
        Mongolia,
        Montenegro,
        Morocco,
        Mozambique,
        Myanmar_formerly_Burma,

        Namibia,
        Nauru,
        Nepal,
        Netherlands,
        New_Zealand,
        Nicaragua,
        Niger,
        Nigeria,
        North_Korea,
        North_Macedonia_formerly_Macedonia,
        Norway,

        Oman,

        Pakistan,
        Palau,
        Palestine,
        Panama,
        Papua_New_Guinea,
        Paraguay,
        Peru,
        Philippines,
        Poland,
        Portugal,
        Qatar,

        Romania,
        Russia,
        Rwanda,

        Saint_Kitts_and_Nevis,
        Saint_Lucia,
        Saint_Vincent_and_the_Grenadines,
        Samoa,
        San_Marino,
        Sao_Tome_and_Principe,
        Saudi_Arabia,
        Senegal,
        Serbia,
        Seychelles,
        Sierra_Leone,
        Singapore,
        Slovakia,
        Slovenia,
        Solomon_Islands,
        Somalia,
        South_Africa,
        South_Korea,
        South_Sudan,
        Spain,
        Sri_Lanka,
        Sudan,
        Suriname,
        Sweden,
        Switzerland,
        Syria,

        Taiwan,
        Tajikistan,
        Tanzania,
        Thailand,
        Timor_Leste,
        Togo,
        Tonga,
        Trinidad_and_Tobago,
        Tunisia,
        Turkey,
        Turkmenistan,
        Tuvalu,

        Uganda,
        Ukraine,
        United_Arab_Emirates_UAE,
        United_Kingdom_UK,
        United_States_of_America_USA,
        Uruguay,
        Uzbekistan,

        Vanuatu,
        Vatican_City_Holy_See,
        Venezuel,
        Vietnam,

        Yemen,

        Zambia,
        Zimbabwe
    }
    public enum studentStatus
    {
        Graduated,
        Left,
        Disqualified,
        Differed,
        Currently_On
    }
    public enum grade
    {
        A_Plus,
        A,
        B,
        C,
        D
    }

    public enum projectStatus
    {
        Completed,
        Incomplete,
        Abandoned
    }

    public enum programName
    {
        dotNet_FullStack,
        FrontEnd
    }

    public enum programDuration
    {
        One_Month,
        Two_Month,
        Three_Month,
        Four_Month,
        Five_Month,
        Six_Month,
        Seven_Month

    }

    public enum courseLevel
    {
        Beginner,
        Intermidiate,
        Advanced
    }

    public enum courseName
    {
        Html,
        Css,
        C_Sharp,
        AspNet,
        Xamarin,
        Js
    }

    public enum batchName
    {
        Batch_A,
        Batch_B,
        Batch_C,
        Batch_D,
        Batch_E,
        Batch_F
    }
}
