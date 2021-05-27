using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BibliotecaPeriodosAtras;
namespace Teste
{
    [TestClass]
    public class Testes
    {
        [TestMethod]
        public void UmDiaAtras()
        {
            PeriodosAtras dataVelha = new(new DateTime(2021, 05, 25));
            Assert.AreEqual("Um dia atrás", dataVelha.QuantoTempoAtras());
        }
        [TestMethod]
        public void DoisDiasAtras()
        {
            PeriodosAtras dataVelha = new(new DateTime(2021, 05, 24));
            Assert.AreEqual("Dois dias atrás", dataVelha.QuantoTempoAtras());
        }
        [TestMethod]
        public void UmaSemanaAtras()
        {
            PeriodosAtras dataVelha = new(new DateTime(2021, 05, 19));
            Assert.AreEqual("Uma semana atrás", dataVelha.QuantoTempoAtras());
        }
        [TestMethod]
        public void DoisMesesEUmaSemanaAtras()
        {
            PeriodosAtras dataVelha = new(new DateTime(2021, 03, 20));
            Assert.AreEqual("Dois meses e uma semana atrás", dataVelha.QuantoTempoAtras());
        }
        [TestMethod]
        public void DezAnosAtras()
        {
            PeriodosAtras dataVelha = new(new DateTime(2011, 05, 26));
            Assert.AreEqual("Dez anos atrás", dataVelha.QuantoTempoAtras());
        }
        [TestMethod]
        public void TresHorasAtras()
        {
            PeriodosAtras dataVelha = new(new DateTime(2021, 05, 26, 15, 45, 40));
            Assert.AreEqual("Três horas atrás", dataVelha.QuantoTempoAtras());
        }
        [TestMethod]
        public void TresHorasETrintaMinutosAtras()
        {
            PeriodosAtras dataVelha = new(new DateTime(2021, 05, 26, 15, 15, 40));
            Assert.AreEqual("Três horas e trinta minutos atrás", dataVelha.QuantoTempoAtras());
        }
        [TestMethod]
        public void TresHorasETrintaMinutosETrintaSegundosAtras()
        {
            PeriodosAtras dataVelha = new(new DateTime(2021, 05, 26, 15, 15, 15));
            Assert.AreEqual("Três horas e trinta minutos e vinte e cinco segundos atrás", dataVelha.QuantoTempoAtras());
        }
    }
}
