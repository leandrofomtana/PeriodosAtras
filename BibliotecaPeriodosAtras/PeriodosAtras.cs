using System;
using System.Collections.Generic;

namespace BibliotecaPeriodosAtras
{
    public class PeriodosAtras
    {
        private DateTime data;
        private int totalDias;
        private Dictionary<int, String> dicionarioNumeros;


        public PeriodosAtras(DateTime data)
        {
            this.data = data;
            DicionarioNumeros = new Dictionary<int, string>();
        }

        public DateTime Data { get => data; set => data = value; }

        public Dictionary<int, string> DicionarioNumeros { get => dicionarioNumeros; set => dicionarioNumeros = value; }
        public int TotalDias { get => totalDias; set => totalDias = value; }

        private void PopulaDicionario()
        {
            DicionarioNumeros.Add(0, "");
            DicionarioNumeros.Add(1, "um");
            DicionarioNumeros.Add(2, "dois");
            DicionarioNumeros.Add(3, "três");
            DicionarioNumeros.Add(4, "quatro");
            DicionarioNumeros.Add(5, "cinco");
            DicionarioNumeros.Add(6, "seis");
            DicionarioNumeros.Add(7, "sete");
            DicionarioNumeros.Add(8, "oito");
            DicionarioNumeros.Add(9, "nove");
            DicionarioNumeros.Add(10, "dez");
            DicionarioNumeros.Add(11, "onze");
            DicionarioNumeros.Add(12, "doze");
            DicionarioNumeros.Add(13, "treze");
            DicionarioNumeros.Add(14, "catorze");
            DicionarioNumeros.Add(15, "quinze");
            DicionarioNumeros.Add(16, "dezesseis");
            DicionarioNumeros.Add(17, "dezessete");
            DicionarioNumeros.Add(18, "dezoito");
            DicionarioNumeros.Add(19, "dezenove ");
            DicionarioNumeros.Add(20, "vinte");
            DicionarioNumeros.Add(30, "trinta");
            DicionarioNumeros.Add(40, "quarenta");
            DicionarioNumeros.Add(50, "cinquenta");
            DicionarioNumeros.Add(60, "sessenta");
            DicionarioNumeros.Add(70, "setenta");
            DicionarioNumeros.Add(80, "oitenta");
            DicionarioNumeros.Add(90, "noventa");

        }
        public string QuantoTempoAtras()
        {
            PopulaDicionario();
            string resultado = "";
            DateTime agora = new(2021, 05, 26, 18,45 ,40);
            TimeSpan DiasPassados = agora - Data;
            if (DiasPassados.Days > 0)
            {
                TotalDias = DiasPassados.Days;
                int anos = AnosPassados();
                int anosBissextos = ChecarAnoBissextos(agora);
                TotalDias -= anosBissextos;
                int meses = MesesPassados();
                int semanas = SemanasPassadas();
                resultado = MontarString(resultado, anos, " ano");
                resultado = MontarString(resultado, meses, " mes");
                resultado = MontarString(resultado, semanas, " semana");
                resultado = MontarString(resultado, TotalDias, " dia");
            }
            else
            {
                int horas = DiasPassados.Hours;
                int minutos = DiasPassados.Minutes;
                int segundos = DiasPassados.Seconds;
                resultado = MontarString(resultado, horas, " hora");
                resultado = MontarString(resultado, minutos, " minuto");
                resultado = MontarString(resultado, segundos, " segundo");
            }
            resultado += " atrás";
            return char.ToUpper(resultado[0]) + resultado[1..];
        }

        private int ChecarAnoBissextos(DateTime agora)
        {
            int anoBissextoMaisProximo = 2020;
            int anosBissextos=0;
            for (int i=agora.Year; i!=Data.Year; i--)
            {
                if (i == anoBissextoMaisProximo)
                {
                    anoBissextoMaisProximo -= 4;
                    anosBissextos++;
                }
            }
            return anosBissextos;
        }

        private string MontarString(string resultado, int numero, string tipo)
        {
            string numeroExtenso = "";
            if (numero<20)
            numeroExtenso = DicionarioNumeros[numero];
            else
            {
                int dezena = numero / 10 * 10;
                int unidade = numero % dezena;
                numeroExtenso += DicionarioNumeros[dezena];
                if (unidade != 0)
                    numeroExtenso += " e " + DicionarioNumeros[unidade];
            }
            if (numero == 1 && tipo == " semana")
                numeroExtenso = "uma";
            else if (numero == 2 && tipo == " semana")
                numeroExtenso = "duas";
            if (tipo != " ano" && resultado != "" && numero !=0)
                resultado += " e ";
            if (numero == 1)
                resultado += numeroExtenso + tipo;
            else if (numero > 1 && tipo != " mes")
                resultado += numeroExtenso + tipo + "s";
            else if (numero > 1 && tipo == " mes")
                resultado += numeroExtenso + tipo + "es";
            return resultado;
        }

        private int SemanasPassadas()
        {
            if (totalDias >= 7)
            {
                int semanas = totalDias / 7;
                totalDias %= 7;
                return semanas;
            }
            return 0;
        }
        private int MesesPassados()
        {
            if (totalDias >= 30)
            {
                int meses = totalDias / 30;
                totalDias %= 30;
                return meses;
            }
            return 0;
        }

        private int AnosPassados()
        {            
            if (totalDias >= 365)
            {
               int anos = totalDias / 365;
               totalDias %= 365;
               return anos;
            }
            return 0;
        }
    }
}
