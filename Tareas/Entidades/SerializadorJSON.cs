using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Entidades
{
    public static class SerializadorJSON<T> where T : class
    {
        private const string extension = ".json";

        private static string rutaDirectorioBase;
        private static char caracterSeparadorDeDirectorios;

        static SerializadorJSON()
        {
            SerializadorJSON<T>.caracterSeparadorDeDirectorios = Path.DirectorySeparatorChar;
            SerializadorJSON<T>.rutaDirectorioBase = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Tareas/");
        }

        /// <summary>
        /// Obtiene la ruta completa del archivo, al combinar la ruta relativa con la ruta Base del proyecto.
        /// </summary>
        /// <param name="rutaRelativa">Ruta relativa del archivo.</param>
        /// <returns>La ruta completa del archivo.</returns>
        /// <exception cref="ArgumentNullException">Ruta NULL</exception>
        private static string ObtenerRutaCompletaArchivo(string rutaRelativa)
        {
            string rutaCompletaDeArchivo;

            if (!string.IsNullOrWhiteSpace(rutaRelativa))
            {
                rutaCompletaDeArchivo = Path.Combine(SerializadorJSON<T>.rutaDirectorioBase, rutaRelativa);

                rutaCompletaDeArchivo = rutaCompletaDeArchivo.Replace('\\', caracterSeparadorDeDirectorios);
                rutaCompletaDeArchivo = rutaCompletaDeArchivo.Replace('/', caracterSeparadorDeDirectorios);

                if (!rutaCompletaDeArchivo.EndsWith(SerializadorJSON<T>.extension))
                {
                    rutaCompletaDeArchivo += SerializadorJSON<T>.extension;
                }

                return rutaCompletaDeArchivo;
            }
            throw new NullReferenceException("Ruta NULL");
        }

        /// <summary>
        /// Guarda un elemento en la ruta indicada, con formato JSON.
        /// </summary>
        /// <param name="rutaRelativaArchivo">Ruta relativa del archivo.</param>
        /// <param name="elemento">Elemento a guardar.</param>
        /// <returns>True si guardo correctamente.</returns>
        /// <exception cref="Exception">Ocurrio un error al intentar guardar.</exception>
        public static bool Guardar(string rutaRelativaArchivo, T elemento)
        {
            string rutaCompletaDeArchivo;
            string rutaCompletaDeDirectorio;
            string jsonSerializado;

            try
            {
                if (elemento is not null)
                {
                    rutaCompletaDeArchivo = SerializadorJSON<T>.ObtenerRutaCompletaArchivo(rutaRelativaArchivo);

                    rutaCompletaDeDirectorio = rutaCompletaDeArchivo.Substring(0, rutaCompletaDeArchivo.LastIndexOf(caracterSeparadorDeDirectorios) + 1);

                    if (Directory.Exists(rutaCompletaDeDirectorio) || Directory.CreateDirectory(rutaCompletaDeDirectorio).Exists)
                    {
                        DirectoryInfo informacion = new DirectoryInfo(rutaCompletaDeDirectorio);
                        informacion.Attributes = FileAttributes.Hidden;

                        JsonSerializerOptions opcionesDeSerializacion = new JsonSerializerOptions();
                        opcionesDeSerializacion.WriteIndented = true;

                        jsonSerializado = JsonSerializer.Serialize(elemento, opcionesDeSerializacion);

                        File.WriteAllText(rutaCompletaDeArchivo, jsonSerializado);

                        return true;
                    }
                }
                throw new NullReferenceException("El elemento a serializar es NULL");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al intentar Serializar: {ex.Message}");
            }
        }

        /// <summary>
        /// Lee un elemento de un archivo JSON y lo retorna.
        /// </summary>
        /// <param name="rutaRelativaArchivo">Ruta del archivo</param>
        /// <returns>Elemento leido</returns>
        /// <exception cref="Exception">Ocurrio un error al intentar leer.</exception>
        public static T Leer(string rutaRelativaArchivo)
        {
            string rutaCompletaDeArchivo;
            string jsonFormatoString;
            try
            {
                rutaCompletaDeArchivo = SerializadorJSON<T>.ObtenerRutaCompletaArchivo(rutaRelativaArchivo);

                if (File.Exists(rutaCompletaDeArchivo))
                {
                    jsonFormatoString = File.ReadAllText(rutaCompletaDeArchivo);

                    if (JsonSerializer.Deserialize(jsonFormatoString, typeof(T)) is T elemento)
                    {
                        return elemento;
                    }
                }
                throw new FileNotFoundException($"No se encontro un archivo en la ruta: {rutaCompletaDeArchivo}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al intentar Deserializar: {ex.Message}");
            }
        }
    }
}
