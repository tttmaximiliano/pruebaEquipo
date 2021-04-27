using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EquipoFutbol {
    class Jugador {

        int num;

        string[] jugadorr = new string[15];

        public int registro;
        public string nombre;
        public string posicion;
        public int resistencia;
        public int velocidad;
        public int fuerza;
        public int destreza;
        public int Registro { get; set;}
        public string Posicion { get { return posicion; } }
        public string Nombre { get { return nombre; } }
        public int Resistencia {
            get { return resistencia; }

            set {
                if (value >= 0) {
                    resistencia = value;
                } else {
                    resistencia = value * -1;
                }
            }
        }
        public int Velocidad {
            get { return velocidad; }

            set {
                if (value >= 0 ) {
                    velocidad = value;
                } else {

                    velocidad = value * -1;
                }
            }
        }
        public int Fuerza {
            get { return fuerza; }

            set {
                if (value >= 0) {
                    fuerza = value;
                } else {
                    fuerza = value * -1;
                }
            }
        }
        public int Destreza {
            get { return destreza; }

            set {
                if (value >= 0) {
                    destreza = value;
                } else {
                    destreza = value * -1;
                }
            }
        }
        public Jugador(string Posicion, string Nombre,int Resistencia, int Velocidad, int Fuerza, int Destreza) {
            posicion = Posicion;
            nombre = Nombre;
            resistencia = Resistencia;
            velocidad = Velocidad;
            fuerza = Fuerza;
            destreza = Destreza;

        }
        public Jugador() { 
        
        }     
        public string DatosJugador() {
        return posicionJ(posicion) + "," + nombre + ", Resistencia:" + resistencia + ", Velocidad:" + velocidad + ", Fuerza:" + fuerza + " y Destreza:" + destreza;
        }
        public bool setearResistencia(int val) {
            int total = fuerza + destreza + velocidad + resistencia+val;
            if (resistencia <= 100) {
                if (total > 100) {
                    return false;
                } else {
                    resistencia = val;
                    return true;
                }
            } else {
                Console.WriteLine("El valor no debe superar los 100");
                return false;
            }
        }
        public bool seteaFuerza(int val) {
            int total = fuerza + destreza + velocidad + resistencia + val;
            if (fuerza <= 100) {
                if (total > 100) {
                    return false;
                } else {
                    fuerza = val;
                    return true;
                }
            } else {
                Console.WriteLine("El valor no debe superar los 100");
                return false;
            }
        }

        public bool seteaDestreza(int val) {
            int total = fuerza + destreza + velocidad + resistencia + val;
            if (destreza <= 100) {
                if (total > 100) {
                    return false;
                } else {
                    destreza = val;
                    return true;
                }
            } else {
                Console.WriteLine("El valor no debe superar los 100");
                return false;
            }
        }

        public bool seteaVelocidad(int val) {

            int total = fuerza + destreza + velocidad + resistencia + val;
            if (velocidad <= 100) {
                if (total > 100) {
                    return false;
                } else {
                    velocidad = val;
                    return true;
                }
            } else {
                Console.WriteLine("El valor no debe superar los 100");
                return false;
            }
        }

        private string posicionJ(string p) {
            switch (p) {
                case "1": return "Portero"; break;
                case "2": return "Defensa"; break;
                case "3": return "Medio Campo"; break;
                case "4": return "Delantero"; break;
                default: break;
            }
            return "";
        }
        public bool Salir() {
            Console.Write("Saliendo...");
            Console.ReadKey();
            Environment.Exit(0);
            return true;
        }
    }
}
