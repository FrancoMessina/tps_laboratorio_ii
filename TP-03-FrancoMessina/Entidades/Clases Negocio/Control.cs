using System;
using System.Collections.Generic;
namespace Entidades
{
    
    public class Control : Producto
    {

        private ETipoControl tipo;

        public Control(string marca, string modelo, List<string> listaFallas,ETipoControl tipo) : base(marca, modelo, listaFallas)
        {
            this.tipo = tipo;
        }
        public Control()
        {

        }
        public ETipoControl Tipo { get { return this.tipo; } set { this.tipo = value; } }


        public override float CalcularCosto()
        {
            float precio = 0;
            if (this.Tipo == ETipoControl.TV)
            {
                foreach (string falla in this.ListaFallas)
                {
                    switch (falla)
                    {
                        case "NoEmiteSenial":
                            precio += 600;
                            break;
                        case "NoFuncionaBoton":
                            precio += 400;
                            break;
                        case "PortaPilaSulfatado":
                            precio += 900;
                            break;
                    }
                }
            }
            else
            {
                foreach (string falla in this.ListaFallas)
                {
                    switch (falla)
                    {
                        case "DisplayRoto":
                            precio += 700;
                            break;
                        case "NoEmiteSenial":
                            precio += 600;
                            break;
                        case "BajaSenial":
                            precio += 300;
                            break;
                    }
                }
            }
            return precio;
        }

        public override string ToString()
        {
            return $"Tipo Control: {this.tipo}\t {base.ToString()}"; 
        }
    }
}
