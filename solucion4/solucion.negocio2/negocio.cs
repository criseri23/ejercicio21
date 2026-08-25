using solucion.datos2;

namespace solucion.negocio2
{
        public class Libro
        {
            public string Isbn { get; set; }
            public string Titulo { get; set; }
            public string Autor { get; set; }
            public bool Disponible { get; set; }

            public Libro(string isbn, string titulo, string autor, bool disponible)
            {
                if (string.IsNullOrWhiteSpace(isbn))
                {
                    throw new ArgumentException("El ISBN no puede ser nulo ni estar vacío.");
                }

                Isbn = isbn;
                Titulo = titulo;
                Autor = autor;
                Disponible = disponible;
            }
        }
    }

