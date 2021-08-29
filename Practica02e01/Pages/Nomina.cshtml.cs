using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Practica02e01.Pages
{
    public class NominaModel : PageModel
    {
        //Propiedades
        public List<string> Nombres;
        public List<string> Apellidos;
        public List<string> Cargo;
        public List<double> Salario;

        //Funciones
        public double DescuentoAFP(double salario)
        {
            double descuento;
            double salarioMin;
            double descuentoMax;

            salarioMin = 13482.00;
            descuento = salario * 0.0287;
            descuentoMax = (salarioMin * 20) * 0.0287;

            if (descuento > descuentoMax)
                descuento = descuentoMax;

            return descuento;
        }
        public double DescuentoARS(double salario)
        {
            double descuento;
            double salarioMin;
            double descuentoMax;

            salarioMin = 13482.00;
            descuento = salario * 0.0304;
            descuentoMax = (salarioMin * 10) * 0.0304;

            if (descuento > descuentoMax)
                descuento = descuentoMax;

            return descuento;
        }
        public double DescuentoIRS(double salario)
        {
            double descuento;
            double salarioAnual;
            double RentaNivel0;
            double RentaNivel1;
            double RentaNivel2;

            RentaNivel0 = 416220.00;
            RentaNivel1 = 624329.00;
            RentaNivel2 = 867123.00;
           
            descuento = 0;
            salarioAnual = salario * 12;

            if (salarioAnual <= RentaNivel0)
            {
                descuento = 0;
            }
            else if (RentaNivel0 < salarioAnual && salarioAnual <= RentaNivel1)
            {
                salarioAnual -= RentaNivel0;
                descuento = salarioAnual * 0.15;
            }
            else if (RentaNivel1 < salarioAnual && salarioAnual <= RentaNivel2)
            {
                salarioAnual -= RentaNivel1;
                descuento = 31216.00 + (salarioAnual * 0.2);
            }
            else if (RentaNivel2 < salarioAnual)
            {
                salarioAnual -= RentaNivel2;
                descuento = 79776.00 + (salarioAnual * 0.25);
            }

            descuento /= 12;
            return descuento;
        }
        public double DescuentoTotal(double salario)
        {
            double totalDescuento;
            totalDescuento = DescuentoAFP(salario) + DescuentoARS(salario) + DescuentoIRS(salario);
            return totalDescuento;
        }
        public double SalarioNeto(double salario)
        {
            salario -= DescuentoTotal(salario);
            return salario;
        }

        public void OnGet()
        {
            Nombres = new List<string>()
            {
                "Pedro",
                "Juan",
                "Alberto",
                "Raul",
                "Sergio"
            };

            Apellidos = new List<string>()
            {
                "Ramirez",
                "Sanchez",
                "Aguiloa",
                "Soto",
                "Montilla"
            };

            Cargo = new List<string>()
            {
                "Jefe de Proyecto",
                "Lider de Equipo",
                "Desarrollador",
                "Diseñador Gráfico",
                "Documentador Técnico"
            };

            Salario = new List<double>()
            {
                200000,
                150000,
                100000,
                90000,
                80000
            };
        }
    }
}
