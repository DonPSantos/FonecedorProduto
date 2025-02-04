﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Validations.Documentos
{
    public class Utils
    {
        public static string ApenasNumeros(string valor)
        {
            var onlyNumber = "";
            foreach (var s in valor)
            {
                if (char.IsDigit(s))
                {
                    onlyNumber += s;
                }
            }
            return onlyNumber.Trim();
        }
    }
}