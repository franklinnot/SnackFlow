using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnackFlow
{
    public partial class frm_Snack : Form
    {
        // VARIABLE DE TIPO STRING QUE ALMACENAN LA INFORMACION DE LAS CARPETAS SIGUIENTES:
        /// PATH_RUTA: PARA LA CARPETA DE IMAGENES A CONVERTIR
        /// PAHT_DESTINO: PARA LA CARPETA DE IMAGENES YA CONVERTIDAS
        private string path_ruta, path_Destino;
        // SE CREA UN DICCIONARIO QUE ALMACENA EL VALOR PARA CADA ESTADO DE SELECCION DE LAS IMAGENES 
        private Dictionary<string, bool> imagenesSeleccionadas = new Dictionary<string, bool>();
        // SE UTILIZA UNA CONSTANTE PARA REDIMENSIONAR LA IMAGEN AL CONVERTIRLA
        private const int ImageSize = 100;
        // SE CREA UN DICCIONARIO PARA ALMACENAR Y MOSTRAR LAS IMAGENES
        private Dictionary<PictureBox, string> pictureBoxes = new Dictionary<PictureBox, string>();

        
        public frm_Snack()
        {
            InitializeComponent();
            Icon = Properties.Resources.iconito;
        }
        


        
        //SE SELECCIONA LA CARPETA DE DESTINO
        private void btn_PathDestino_Click(object sender, EventArgs e)
        {
            // Se crea una instancia de FolderBrowserDialog para seleccionar una carpeta
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                // Si se selecciona una carpeta y se hace clic en el botón "OK"
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    // Se guarda la ruta de la carpeta seleccionada en la variable 'path_Destino'
                    path_Destino = folderBrowserDialog.SelectedPath;

                    // Se muestra la ruta seleccionada en el campo de texto 'txt_PathDestino'
                    txt_PathDestino.Text = path_Destino;
                }
            }
        }




        //METODO QUE SE ENCARGA DE RECONOCER EL FORMATO DE COMPRESION DE CADA ARCHIVO DE IMAGEN
        private bool Formatos(string archivo)
        {
            // Obtiene la extensión del archivo y la convierte a minúsculas
            string extension = Path.GetExtension(archivo).ToLower();

            // Comprueba si la extensión del archivo es válida
            // COMO SE PUEDE VER AQUI ABAJO
            return extension == ".png" || extension == ".jpg" || extension == ".jpeg" || extension == ".gif" || extension == ".bmp";
        }
        


        //METODO QUE UTILIZA LOS CARACTERES ASIGNADOS PARA LA CONCERSION DE LA IMAGEN A ASCII
        private char ObtenerCaracter(int intensidad)
        {
            // Define una cadena de caracteres que se utilizarán para representar diferentes niveles de intensidad
            string caracteres = "@%#*+=-:. ";

            // Calcula el rango de intensidad para cada caracter basado en la cantidad de caracteres disponibles
            int rango = 256 / caracteres.Length;

            // Calcula el índice del caracter correspondiente a la intensidad recibida
            int indice = intensidad / rango;

            // Verifica si el índice está fuera de los límites de la cadena de caracteres
            if (indice >= caracteres.Length)
            {
                // Ajusta el índice para que esté dentro de los límites de la cadena de caracteres
                indice = caracteres.Length - 1;
            }

            // Devuelve el caracter correspondiente al índice calculado
            return caracteres[indice];
        }




        //METODO PARA CONVERTIR LA IMAGEN
        private string Conversor(Bitmap imagen)
        {
            // Obtenemos el ancho y alto de la imagen original
            int ancho = imagen.Width;
            int alto = imagen.Height;

            // Definimos el nuevo ancho deseado y calculamos el nuevo alto proporcionalmente
            int nuevoAncho = 150;
            int nuevoAlto = (int)(alto * (double)nuevoAncho / ancho);

            // Redimensionamos la imagen original al nuevo tamaño especificado
            Bitmap imagenRedimensionada = new Bitmap(imagen, nuevoAncho, nuevoAlto);

            // Calculamos la relación de aspecto entre la altura original y la altura redimensionada
            double relacionAspecto = (double)alto / nuevoAlto;

            // Creamos un objeto StringBuilder para almacenar los caracteres ASCII generados
            StringBuilder asciiBuilder = new StringBuilder();

            // Iteramos sobre cada fila de píxeles de la imagen redimensionada
            for (int y = 0; y < nuevoAlto; y++)
            {
                // Iteramos sobre cada columna de píxeles de la imagen redimensionada
                for (int x = 0; x < nuevoAncho; x++)
                {
                    // Calculamos las coordenadas originales correspondientes a la posición actual
                    int xOriginal = (int)(x * relacionAspecto);
                    int yOriginal = (int)(y * relacionAspecto);

                    // Obtenemos el color del píxel en la posición actual
                    Color pixelColor = imagenRedimensionada.GetPixel(x, y);

                    // Calculamos la intensidad del píxel tomando el promedio de los componentes RGB
                    int intensidad = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;

                    // Obtenemos el carácter ASCII correspondiente a la intensidad del píxel
                    char caracter = ObtenerCaracter(intensidad);

                    // Agregamos el carácter al StringBuilder 
                    asciiBuilder.Append(caracter);
                }

                // Agregamos una nueva línea al final de cada fila
                asciiBuilder.AppendLine();
            }

            // Devolvemos el arte ASCII generado como una cadena de texto
            return asciiBuilder.ToString();
        }




        //SE SELLECIONA LA CARPETA QUE SE QUIERE CONVERTIR
        private void btn_PathRuta_Click(object sender, EventArgs e)
        {
            // Se crea una instancia de FolderBrowserDialog para seleccionar una carpeta
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                // Si se selecciona una carpeta y se hace clic en el botón "OK"
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    // Se guarda la ruta de la carpeta seleccionada en la variable 'path_ruta'
                    path_ruta = folderBrowserDialog.SelectedPath;

                    // Se muestra la ruta seleccionada en el campo de texto 'txt_PathRuta'
                    txt_PathRuta.Text = path_ruta;

                    try
                    {
                        // Se limpian los recursos y la memoria ocupada por las imágenes y controles anteriores

                        // Iterar sobre la colección de PictureBox y sus rutas de archivo asociadas
                        foreach (KeyValuePair<PictureBox, string> kvp in pictureBoxes)
                        {
                            // Liberar los recursos de imagen y eliminar los PictureBox
                            kvp.Key.Image.Dispose();
                            kvp.Key.Dispose();
                        }

                        // Limpiar las colecciones de PictureBox y de imágenes seleccionadas
                        pictureBoxes.Clear();
                        imagenesSeleccionadas.Clear();

                        // Eliminar los controles de imágenes anteriores del contenedor 'imageFlowLayout'
                        imageFlowLayout.Controls.Clear();

                        // Obtener los archivos de la nueva carpeta seleccionada
                        string[] archivos = Directory.GetFiles(path_ruta);

                        // Calcular el número de columnas que caben en el tamaño del contenedor 'imageFlowLayout'
                        int columnas = imageFlowLayout.ClientSize.Width / ImageSize;

                        int x = 0;
                        int y = 0;

                        // Iterar sobre cada archivo de la carpeta seleccionada
                        foreach (string archivo in archivos)
                        {
                            // Obtener el nombre del archivo 
                            string extension = Path.GetFileName(archivo);

                            // Verificar si el archivo tiene una extensión válida utilizando la función 'Formatos'
                            if (Formatos(extension))
                            {
                                // Agregar el archivo a la lista de imágenes seleccionadas con un valor inicial de falso
                                imagenesSeleccionadas.Add(archivo, false);

                                // Crear un nuevo PictureBox y configurarlo
                                PictureBox pictureBox = new PictureBox();
                                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                                pictureBox.Image = Image.FromFile(archivo);
                                pictureBox.Click += PictureBox_Click;

                                // Establecer el tamaño del PictureBox
                                pictureBox.Width = ImageSize;
                                pictureBox.Height = ImageSize;

                                // Establecer la posición del PictureBox en el contenedor
                                pictureBox.Location = new Point(x, y);

                                // Agregar el PictureBox al contenedor 'imageFlowLayout'
                                imageFlowLayout.Controls.Add(pictureBox);

                                // Agregar el PictureBox y la ruta de archivo asociada a las colecciones correspondientes
                                pictureBoxes.Add(pictureBox, archivo);

                                // Actualizar la posición vertical para el próximo PictureBox
                                y += ImageSize;

                                // Si se alcanza el límite de altura del contenedor, reiniciar la posición vertical y aumentar la posición horizontal
                                if (y >= imageFlowLayout.ClientSize.Height)
                                {
                                    y = 0;
                                    x += ImageSize;
                                }
                            }
                        }
                    }

                    catch (OutOfMemoryException)
                    {
                        // Mostrar un mensaje de error si la carpeta seleccionada es demasiado grande
                        MessageBox.Show("La carpeta seleccionada es muy grande", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_PathRuta.Text = string.Empty;
                    }

                    // Configurar las propiedades del contenedor 'imageFlowLayout' para permitir el desplazamiento vertical
                    imageFlowLayout.AutoScroll = true;
                    imageFlowLayout.WrapContents = false;
                    imageFlowLayout.HorizontalScroll.Visible = false;
                    imageFlowLayout.VerticalScroll.Visible = true;
                    imageFlowLayout.VerticalScroll.Enabled = true;
                }
            }
        }


        private void btn_Convertir_Click(object sender, EventArgs e)
        {
            // Verificamos si los campos de ruta de origen y destino están vacíos
            if ((txt_PathDestino.Text == string.Empty) || (txt_PathRuta.Text == string.Empty))
            {
                // Mostramos un mensaje de error indicando que ambas carpetas deben ser seleccionadas correctamente
                MessageBox.Show("Debe seleccionar ambas carpetas correctamente", "Tonto usuario xd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Obtenemos la lista de nombres de las imágenes seleccionadas que tienen un valor verdadero en el diccionario 'imagenesSeleccionadas'
                List<string> imagenesMarcadas = imagenesSeleccionadas.Where(kv => kv.Value).Select(kv => kv.Key).ToList();

                // Verificamos si no se ha seleccionado ninguna imagen
                if (imagenesMarcadas.Count == 0)
                {
                    // Mostramos un mensaje de error indicando que al menos una imagen debe ser seleccionada para la conversión
                    MessageBox.Show("Debe seleccionar al menos una imagen para realizar la conversión.", "Tonto usuario xd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Iteramos sobre cada archivo seleccionado en la lista de imágenes marcadas
                foreach (string archivoSeleccionado in imagenesMarcadas)
                {
                    // Obtenemos el nombre del archivo sin la ruta y la extensión
                    string nombreArchivo = Path.GetFileName(archivoSeleccionado);

                    // Verificamos si el formato del archivo es válido para la conversión
                    if (Formatos(archivoSeleccionado))
                    {
                        // Creamos un nuevo objeto Bitmap a partir del archivo seleccionado
                        Bitmap imagen = new Bitmap(archivoSeleccionado);

                        // Convertimos la imagen en arte ASCII llamando al método 'Conversor'
                        string ascii = Conversor(imagen);

                        // Obtenemos la ruta de la carpeta destino especificada
                        string carpetaDestino = path_Destino;

                        // Verificamos si la carpeta destino no existe, y en caso contrario, la creamos
                        if (!Directory.Exists(carpetaDestino))
                        {
                            Directory.CreateDirectory(carpetaDestino);
                        }

                        // Obtenemos el nombre del archivo sin extensión
                        nombreArchivo = Path.GetFileNameWithoutExtension(archivoSeleccionado);

                        // Combinamos la carpeta destino con el nombre de archivo y la extensión .txt para obtener la ruta del archivo destino
                        string rutaArchivoDestino = Path.Combine(carpetaDestino, nombreArchivo + ".txt");

                        // Escribimos el arte ASCII en el archivo destino utilizando el método 'File.WriteAllText'
                        File.WriteAllText(rutaArchivoDestino, ascii);
                    }
                }

                // Mostramos un mensaje de éxito indicando que la conversión se ha completado satisfactoriamente
                MessageBox.Show("La conversión se ha completado satisfactoriamente", "Yupi Yupi!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //EVENTO CLICK PARA SELECCIONAR Y DESMARCAR LAS IMAGENES DENTRO DEL PANEL 
        private void PictureBox_Click(object sender, EventArgs e)
        {
            // Se obtiene el PictureBox que generó el evento
            PictureBox pictureBox = (PictureBox)sender;

            // Se obtiene la ruta de archivo asociada al PictureBox desde el diccionario 'pictureBoxes'
            string archivo = pictureBoxes[pictureBox];

            // Si la ruta de archivo existe en el diccionario 'imagenesSeleccionadas'
            if (imagenesSeleccionadas.ContainsKey(archivo))
            {
                // Se obtiene el valor de selección actual para la imagen
                bool seleccionada = imagenesSeleccionadas[archivo];

                // Se invierte el valor de selección (seleccionada -> no seleccionada, no seleccionada -> seleccionada)
                imagenesSeleccionadas[archivo] = !seleccionada;

                // Si la imagen estaba seleccionada previamente
                if (seleccionada)
                {
                    // Se quita el borde del PictureBox (ningún estilo de borde)
                    pictureBox.BorderStyle = BorderStyle.None;
                }
                else
                {
                    // Si la imagen no estaba seleccionada previamente, se agrega un borde al PictureBox (estilo de borde de un solo píxel)
                    pictureBox.BorderStyle = BorderStyle.FixedSingle;
                }
            }
        }








       

    }
}
