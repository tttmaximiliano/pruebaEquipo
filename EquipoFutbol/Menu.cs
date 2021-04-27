using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipoFutbol {
    class Menu {
        static void Main(string[] args) {

            Jugador[] equipo = new Jugador[15];
            Jugador[] equipoAux = new Jugador[15];

            Jugador jug = new Jugador();

            int x = 12;

            string opcion = "";

            while (true) {

                Console.Clear();
                Console.WriteLine("\n MENU EQUIPO FUTBOL SITO MAN BOY \n");
                Console.WriteLine("1 = Agregar jugador");
                Console.WriteLine("2 = Eliminar jugador");
                Console.WriteLine("3 = Buscar jugador");
                Console.WriteLine("4 = Mostrar equipo");
                Console.WriteLine("5 = Cambiar de titular a suplente");
                Console.WriteLine("6 = Salir");

                Console.Write("\n Elija una opción : ");

                opcion = Console.ReadLine();

                Console.ReadKey();

                switch (opcion) {
                    
                    case "1":
                        Jugador jugador = new Jugador();

                        bool existe = false;
                        bool existeP = false;

                        Console.Clear();
                        Console.WriteLine("\n Agregar Jugador \n");
                        Console.WriteLine("Posiciones: 1=Portero, 2=Defensa, 3=Medio Campo, 4=Delantero\n");
                        Console.Write("Posicion: ");
                        jugador.posicion = Console.ReadLine();                       
                        Console.Write("Nombre jugador: ");
                        jugador.nombre = Console.ReadLine();
                        Console.Write("Resistencia: ");

                        //velidamos si supera el valor maximo
                        if (!jugador.setearResistencia(Int32.Parse(Console.ReadLine()))) {
                            Console.Write("El valor Supera el máximo permitido (total 100)");
                            Console.ReadKey();
                            break;
                        }
                        Console.Write("Velocidad: ");
                        if (!jugador.seteaVelocidad(Int32.Parse(Console.ReadLine()))) {
                            Console.Write("El valor Supera el máximo permitido (total 100)");
                            Console.ReadKey();
                            break;
                        }
                        
                        Console.Write("Fuerza: ");
                        if (!jugador.seteaFuerza(Int32.Parse(Console.ReadLine()))) {
                            Console.Write("El valor Supera el máximo permitido (total 100)");
                            Console.ReadKey();
                            break;
                        }
                        Console.Write("Destreza: ");
                        if (!jugador.seteaDestreza(Int32.Parse(Console.ReadLine()))) {
                            Console.Write("El valor Supera el máximo permitido (total 100)");
                            Console.ReadKey();
                            break;
                        }
                        if (jugador.posicion.Equals("1")) {

                            for (int i = 0; i < 15; i++) {
                                if (equipo[i] != null) {
                                    if (equipo[i].posicion == "1") {
                                        existeP = true;
                                        break;
                                    }
                                }
                            }
                            if (existeP) {
                                equipo[x] = jugador;
                                
                                

                                Console.Write("El Portero se agrego a Suplente ya que existe un Portero Titular ");
                                Console.ReadKey();
                                break;
                            }
                        }                   
                        
                        for (int i = 0; i < 15; i++) {
                             if (equipo[i] != null) {
                                 if (equipo[i].Equals(jugador)) {
                                     existe = true;
                                      break;
                                 }
                             }
                        }
                            if (existe) {
                                Console.WriteLine("\n El jugador ya Existe!");
                                Console.ReadKey();
                                break;

                            } else {
                                //utilizamos dos for para que el jugador siempre quede en la posicion [0]
                                for (int i = 0; i < 14; i++) {
                                    equipoAux[i] = equipo[i];
                                }
                                for (int i = 0; i < 13; i++) {
                                    if (equipoAux[i] != null) {
                                        equipo[i + 1] = equipoAux[i];
                                    }
                                }
                                
                                 equipo[0] = jugador;
                                 equipo[x] = equipo[x - 1];

                            Console.WriteLine("\n Jugador agregado: " + equipo[0].DatosJugador());
                            }

                        Console.ReadKey();
                        break;

                    case "2":
                        //listamos arreglo de titulares
                        Console.WriteLine("\n Jugadores Titulares");
                        for (int i = 0; i < 10; i++) {
                            if (equipo[i] != null) {

                                Console.WriteLine("(" + i + ")" + equipo[i].DatosJugador());
                               
                            }
                        }
                        //listamos arreglo de suplentes
                        Console.WriteLine("\n Jugadores Suplentes");
                        for (int i = 11; i < 14; i++) {
                            if (equipo[i] != null) {

                                Console.WriteLine("(" + i + ")" + equipo[i].DatosJugador());
                                
                            }
                        }
                        Console.Write("\n Ingrese Jugador: ");
                        int index = Int32.Parse(Console.ReadLine());
                        if (equipo[index] == null) {
                            Console.Write("Jugador no existe");
                            Console.ReadKey();
                            break;
                        } else {


                            Console.WriteLine("\n" + equipo[index].DatosJugador());
                            Console.WriteLine("\n Seguro que desea eliminar al jugador del equipo?\n");

                            Console.WriteLine("1 = Si");
                            Console.WriteLine("2 = No");
                            string delete = Console.ReadLine();
                            switch (delete) {
                                case "1":
                                    int cont = 0;

                                    for (int i = 0; i < 14; i++) {
                                        if (equipo[i] != null) {
                                            if (equipo[i].posicion.Equals("1")) {
                                                cont++;
                                            }
                                        }                                  
                                    }
                                    if (equipo[index].posicion.Equals("1")) {
                                        if (cont <= 1) {
                                            Console.Write("No se puede eliminar ya que es el unico arquero");
                                            Console.ReadKey();
                                        } else {
                                            //eliminamos jugador del arreglo 
                                            //restamos 1 a todos los jugadores siguientes para ordenar y completar arreglo
                                            equipo[index] = null;

                                            for (int i = index + 1; i < 14; i++) {
                                                equipo[i - 1] = equipo[i];
                                            }
                                            Console.WriteLine("Jugador eliminado");
                                        }
                                    } else {
                                        //eliminamos jugador del arreglo 
                                        //restamos 1 a todos los jugadores siguientes para ordenar y completar arreglo
                                        equipo[index] = null;

                                        for (int i = index + 1; i < 14; i++) {
                                            equipo[i - 1] = equipo[i];
                                        }
                                        Console.WriteLine("Jugador eliminado");
                                    }
                                    Console.ReadKey();
                                    break;

                                case "2": break;
                                default: break;
                            }
                        }
                        Console.ReadKey();
                        break;

                    case "3":
                        Console.WriteLine("\n Ingrese registro o nombre de jugador\n");

                        string busqueda = Console.ReadLine();
                        int n;
                        bool result = Int32.TryParse(busqueda, out n);

                        if (result) {
                            if (equipo[Int32.Parse(busqueda)] != null) {
                                Console.WriteLine("(" + Int32.Parse(busqueda) + ")" + equipo[Int32.Parse(busqueda)].DatosJugador());
                            } else {
                                Console.Write("Jugador no existe");
                                Console.ReadKey();
                                break;
                            }
                        } else {
                            int cont = 0;
                            for (int i = 0; i < 10; i++) {
                                if (equipo[i] != null) {
                                    if (equipo[i].nombre.Contains(busqueda)) {
                                        Console.WriteLine("(" + i + ")" + equipo[i].DatosJugador());
                                        cont++;
                                    }
                                }
                            }
                            if (cont == 0) {
                                Console.Write("No se encontraron coincidencias");
                                Console.ReadKey();
                            }
                        }
                        Console.ReadKey();
                        break;

                    case "4":
                        Console.WriteLine("\n Seleccione equipo titular o suplente\n");

                        Console.WriteLine("1 = Equipo Titular");
                        Console.WriteLine("2 = Equipo Suplente");

                        string seleccion = Console.ReadLine();

                        Console.ReadKey();

                        switch (seleccion) {
                            case "1":
                                //portero, luego defensas, medio campo y delanteros.
                                for (int i = 0; i < 10; i++) {
                                    if (equipo[i]!=null) {
                                        if (equipo[i].posicion.Equals("1")) {
                                            Console.WriteLine("(" + i + ")" + equipo[i].DatosJugador());
                                        }
                                    }                                                                      
                                }
                                for (int i = 0; i < 10; i++) {
                                    if (equipo[i] != null) {
                                        if (equipo[i].posicion.Equals("2")) {
                                            Console.WriteLine("(" + i + ")" + equipo[i].DatosJugador());
                                        }
                                    }
                                }
                                for (int i = 0; i < 10; i++) {
                                    if (equipo[i] != null) {
                                        if (equipo[i].posicion.Equals("3")) {
                                            Console.WriteLine("(" + i + ")" + equipo[i].DatosJugador());
                                        }
                                    }
                                }
                                for (int i = 0; i < 10; i++) {
                                    if (equipo[i] != null) {
                                        if (equipo[i].posicion.Equals("4")) {
                                            Console.WriteLine("(" + i + ")" + equipo[i].DatosJugador());
                                        }
                                    }
                                }

                                break;
                            case "2":

                                for (int i = 11; i < 14; i++) {
                                    if (equipo[i] != null) {
                                        Console.WriteLine("(" + i + ")" + equipo[i].DatosJugador());
                                    }
                                }    
                                break;

                            default: break;
                        }

                        Console.ReadKey();

                        break;

                    case "5":
                        //portero, luego defensas, medio campo y delanteros.
                        Console.WriteLine("\n Jugadores Titular");
                        for (int i = 0; i < 10; i++) {
                            if (equipo[i] != null) {
                                if (equipo[i].posicion.Equals("1")) {
                                    Console.WriteLine("(" + i + ")" + equipo[i].DatosJugador());
                                }
                            }
                        }
                        for (int i = 0; i < 10; i++) {
                            if (equipo[i] != null) {
                                if (equipo[i].posicion.Equals("2")) {
                                    Console.WriteLine("(" + i + ")" + equipo[i].DatosJugador());
                                }
                            }
                        }
                        for (int i = 0; i < 10; i++) {
                            if (equipo[i] != null) {
                                if (equipo[i].posicion.Equals("3")) {
                                    Console.WriteLine("(" + i + ")" + equipo[i].DatosJugador());
                                }
                            }
                        }
                        for (int i = 0; i < 10; i++) {
                            if (equipo[i] != null) {
                                if (equipo[i].posicion.Equals("4")) {
                                    Console.WriteLine("(" + i + ")" + equipo[i].DatosJugador());
                                }
                            }
                        }
                        Console.WriteLine("\n Jugadores Suplentes");
                        for (int i = 11; i < 14; i++) {
                            if (equipo[i] != null) {
                                Console.WriteLine("(" + i + ")" + equipo[i].DatosJugador());
                            }
                        }

                        Console.WriteLine("\n Seleccione indice de jugador titular\n");


                        string sel = Console.ReadLine();
                        
                            int nm;
                        bool res = Int32.TryParse(sel, out nm);
                        Jugador j1 = null;
                        Jugador j2 = null;

                        if (res) {
                            if (equipo[Int32.Parse(sel)] == null) {
                                Console.Write("Jugador no existe");
                                Console.ReadKey();
                                break;
                            } else {
                                //validamos si el jugador es titular
                                if (Int32.Parse(sel) >= 0 && Int32.Parse(sel) <= 10) {
                                    j1 = equipo[Int32.Parse(sel)];

                                    Console.WriteLine("\n Seleccione indice de jugador Suplente\n");

                                    string sel2 = Console.ReadLine();

                                    int nm2;
                                    bool res2 = Int32.TryParse(sel2, out nm2);

                                    if (res2) {
                                        if (equipo[Int32.Parse(sel2)] == null) {
                                            Console.Write("Jugador no existe");
                                            Console.ReadKey();
                                            break;
                                        } else {
                                            //validamos si los datos son de jugador suplente 
                                            if (Int32.Parse(sel2) >= 11 && Int32.Parse(sel2) <= 14) {
                                                j2 = equipo[Int32.Parse(sel2)];


                                                j2.posicion = j1.posicion;

                                                equipo[Int32.Parse(sel)] = j2;
                                                equipo[Int32.Parse(sel2)] = j1;
                                                   

                                                    Console.Write("Jugador Cambiados");
                                                    Console.ReadKey();
                                                
                                                
                                            } else {
                                                Console.Write("Jugador seleccionado no es Suplente");
                                                Console.ReadKey();
                                                break;
                                            }
                                        }
                                    }

                                } else {
                                    Console.Write("Jugador seleccionado no es titular");
                                    Console.ReadKey();
                                    break;
                                }                             
                            }
                        }
                        Console.ReadKey();
                        break;

                    case "6":
                        jug.Salir();
                      
                        break;

                    default:

                        break;
                }
            }
        }

        
    }
}
