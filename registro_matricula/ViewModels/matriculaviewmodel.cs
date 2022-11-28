using registro_matricula.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Xamarin;
using Xamarin.Forms;

namespace registro_matricula.ViewModels
{
    public class matriculaviewmodel : INotifyPropertyChanged
    {
        public matriculaviewmodel()
        {


            CrearMatricula = new Command(() =>
            {
                Matricula m1 = new Matricula()
                {
                    nombre = this.nombre,
                    TipoMatricula = this.TipoMatricula,
                    Fecha_matricula= this.Fecha_matricula,
                    estado_alumno= this.estado_alumno,
                    descuento = this.descuento,
                    recargo = this.recargo,
                    monto_total = this.monto_total
                };

                m1.calculo_descuento();
                m1.calculo_estado();
                m1.calculo_montototal();

                listaMatricula.Add(m1);

                info = m1.toString();

                info = "";
                foreach (Matricula tmp in listaMatricula)
                {

                    info += tmp.toString() + "\r\n";
                }


                //Rutina para guardar la Lista en el telefono
                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "Matriculas.aut");
                Stream archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(archivo, listaMatricula);
                archivo.Close();



            });



            AbrirLista = new Command(() => {

                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "Matriculas.aut");
                Stream archivo = new FileStream(ruta, FileMode.Open, FileAccess.Read, FileShare.None);

                listaMatricula = (ObservableCollection<Matricula>)formatter.Deserialize(archivo);
                archivo.Close();

                info = "";

                foreach (Matricula tmp in listaMatricula)
                {

                    info += tmp.toString() + "\r\n";

                }


            });

            LimpiarLista = new Command(() => {

                listaMatricula = new ObservableCollection<Matricula>();

                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "Matriculas.aut");
                Stream archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(archivo, listaMatricula);
                archivo.Close();

                info = "";

            });

        }


        ObservableCollection<Matricula> listaMatricula = new ObservableCollection<Matricula>();


        string info;

        public string Info
        {
            get => info;

            set
            {

                info = value;
                var args = new PropertyChangedEventArgs(nameof(Info));
                PropertyChanged?.Invoke(this, args);
            }
        }

        string nombre;

        public string Nombre
        {
            get => nombre;

            set
            {

                nombre = value;
                var args = new PropertyChangedEventArgs(nameof(Nombre));
                PropertyChanged?.Invoke(this, args);
            }
        }

        string TipoMatricula;

        public string tipomatricula
        {
            get => TipoMatricula;

            set
            {

                TipoMatricula = value;
                var args = new PropertyChangedEventArgs(nameof(tipomatricula));
                PropertyChanged?.Invoke(this, args);
            }
        }

        string Fecha_matricula;

        public string fecha_matricula
        {
            get => Fecha_matricula;

            set
            {

                Fecha_matricula = value;
                var args = new PropertyChangedEventArgs(nameof(fecha_matricula));
                PropertyChanged?.Invoke(this, args);
            }
        }

        string estado_alumno;

        public string Estado_alumno
        {
            get => estado_alumno;

            set
            {

                estado_alumno = value;
                var args = new PropertyChangedEventArgs(nameof(Estado_alumno));
                PropertyChanged?.Invoke(this, args);
            }
        }

        double recargo;

        public double Recargo
        {
            get => recargo;

            set
            {
                recargo = value;
                var args = new PropertyChangedEventArgs(nameof(Recargo));
                PropertyChanged?.Invoke(this, args);
            }
        }

        double descuento;

        public double Descuento
        {
            get => descuento;

            set
            {
                descuento = value;
                var args = new PropertyChangedEventArgs(nameof(Descuento));
                PropertyChanged?.Invoke(this, args);
            }
        }

        double monto_total;

        public double Monto_total
        {
            get => monto_total;

            set
            {
                descuento = value;
                var args = new PropertyChangedEventArgs(nameof(Monto_total));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public Command CrearMatricula { get; }

        public Command AbrirLista { get; }

        public Command LimpiarLista { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
