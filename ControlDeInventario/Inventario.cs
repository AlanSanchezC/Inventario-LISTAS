/*
 *  Creado por Alan Francisco Sánchez Cazarez
 */

using System;

namespace ControlDeInventario
{
    class Inventario
    {
        private Producto inicio, ultimo;

        public Inventario()
        {
            inicio = null;
            ultimo = null;
        }

        public bool agregar(Producto p)
        {
            if (inicio == null)
            {
                inicio = p;
            }
            else
            {
                ultimo.siguiente = p;
            }
            ultimo = p;

            return true;
        }

        private string recorrerInvertido(Producto pr, ref string cad)
        {
            if (pr.siguiente != null)
            {
                recorrerInvertido(pr.siguiente, ref cad);
                return cad += pr.siguiente.ToString() + Environment.NewLine;
            }
            return "";
        }

        public string reporteInvertido()
        {
            string cadena = "";

            if (inicio.siguiente == null)
                return inicio.ToString();
            else
            {
                recorrerInvertido(inicio, ref cadena);
                
                return cadena + inicio.ToString();
            }
        }
        
        public string reporte()
        {
            string cad = "";
            Producto pr = inicio;

            while(pr != null)
            {
                cad += pr.ToString() + Environment.NewLine;
                pr = pr.siguiente;
            }

            return cad;
        }

        public Producto busqueda(string codigo)
        {
            Producto pr = inicio;

            bool encontrado = false;

            while(!encontrado)
            {
                if (pr == null || pr.codigo == codigo)
                    encontrado = true;
                else
                    pr = pr.siguiente;
            }
            return pr;
        }

        public bool insertar(Producto p, int posicion)
        {
            Producto pr = inicio;

            if (posicion == 0)
            {
                p.siguiente = inicio;
                inicio = p;
            }
            else
            {
                int i = 0;
                while (i < posicion - 1)
                {
                    pr = pr.siguiente;
                    i++;
                }
                p.siguiente = pr.siguiente;
                pr.siguiente = p;
            }
            return true; 
        }

        public void eliminar(string codigo)
        {
            Producto pr = inicio;
            bool encontrado = false;

            if (inicio.codigo == codigo)
            {
                inicio = inicio.siguiente;
                encontrado = true;
            }

            while (!encontrado)
            {
                if (pr.siguiente == null)
                    encontrado = true;
                else
                if (pr.siguiente.codigo == codigo)
                {
                    pr.siguiente = pr.siguiente.siguiente;
                    encontrado = true;
                }
                else
                pr = pr.siguiente;
            }
        }
    }
}
