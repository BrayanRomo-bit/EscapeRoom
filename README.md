# EscapeRoom

EscapeRoom es un juego de escape interactivo desarrollado en C# con Windows Forms. El proyecto demuestra el uso avanzado de conceptos de programación orientada a objetos y técnicas de desarrollo de software.

## Descripcion del Proyecto

El jugador asume el rol de un prisionero que debe escapar de una cárcel. A través de tres niveles progresivos, debe resolver acertijos, encontrar llaves, interactuar con personajes no jugables y esquivar guardias para lograr la libertad.

## Tecnologias y Conceptos Utilizados

### 1. Herencia, Interfaces y Polimorfismo

La arquitectura del proyecto utiliza herencia para crear una jerarquía de clases robusta:

- **Clase Base Personaje**: Define la estructura común para todos los personajes del juego (posición, velocidad, imagen).
- **Clases Derivadas**: Prisionero y Guardia heredan de Personaje y sobreescriben comportamientos específicos.
- **Interfaz INivel**: Define el contrato que deben cumplir todos los niveles del juego.
- **Clase NivelBase**: Implementa INivel e hereda de UserControl, proporcionando funcionalidad compartida entre niveles.

El polimorfismo permite que NivelBase pueda ser especializado en Nivel1, Nivel2 y Nivel3, cada uno con su propia lógica de juego.

### 2. Override de Métodos

Se utiliza override para personalizar el comportamiento base en clases derivadas:

- **Clase Nota**: Hereda de Objeto y sobrescribe el método ToString() para mostrar "Nota: {Titulo} - {Descripcion}".
- **Clase Llave**: Hereda de Objeto y personaliza la inicialización con recursos gráficos específicos.
- **Clase Prisionero**: Hereda de Personaje y reimplementa el método Actualizar() con lógica específica del jugador.
- **Clases de Nivel**: Cada nivel sobrescribe IniciarNivel() para configurar sus elementos específicos.

### 3. Eventos en Formularios

El juego utiliza eventos para comunicación entre componentes:

- **Eventos de NivelBase**: Define eventos como Reinicio, PedirPausa y PedirReanudar que son invocados cuando el jugador interactúa con elementos del nivel.
- **Eventos de Formularios**: Los botones del menú del juego utilizan Click para manejar guardado, carga e inventario.
- **Timer del Juego**: Genera eventos periódicos que actualizan el estado del nivel cada frame.

Los eventos se suscriben en la forma principal UCPantallaJuego para responder a cambios en el estado del juego.

### 4. Controles Dinámicos

Los controles de interfaz se crean y se agregan dinámicamente durante la ejecución:

- **Label de Dialogo**: En cada nivel se crea un Label dinámico para mostrar mensajes de diálogo y avisos.
- **Inventario Visual**: Se generan PictureBox dinámicamente para mostrar los iconos de los objetos del inventario.
- **Panel de Diálogo**: Se crea un panel con controles dinámicos para mostrar conversaciones con NPCs.

La clase NivelBase demuestra la creación de controles:
```csharp
lblDialogo = new Label();
lblDialogo.BackColor = Color.Black;
lblDialogo.Dock = DockStyle.Bottom;
this.Controls.Add(lblDialogo);
```

### 5. Persistencia con Archivos

El sistema de guardado utiliza serialización JSON para almacenar y recuperar el estado del juego:

- **Clase Guardar**: Proporciona métodos estáticos para guardar y cargar el estado del juego.
- **Clase EstadoJuego**: Define la estructura de datos que se serializa en formato JSON.
- **Carpeta de Partidas**: Los archivos se guardan en "Partidas Guardadas" con el nombre del prisionero como identificador.
- **Métodos Principales**:
  - `Guardado(EstadoJuego estado, string nombreUsuario)`: Serializa el estado a JSON y lo guarda en archivo.
  - `Cargar(string nombreUsuario)`: Lee el archivo JSON y deserializa el estado del juego.
  - `ObtenerRecords()`: Busca todos los archivos guardados para obtener el mayor puntaje.

El guardado incluye posición del jugador, nivel actual, inventario, llaves recogidas, puertas abiertas y código de la puerta final.

### 6. Manejo de Excepciones

El proyecto implementa try-catch para manejar errores en operaciones críticas:

- **Carga de Idioma**: En Traductor.cs se capturan excepciones al leer archivos JSON de idioma.
- **Lectura de Archivos Guardados**: En Guardar.cs se manejan excepciones al iterar archivos corruptos.
- **Operaciones de Archivo**: Se valida la existencia de directorios y archivos antes de acceder a ellos.

Ejemplo de manejo:
```csharp
try
{
    string json = File.ReadAllText(archivo);
    EstadoJuego estado = JsonSerializer.Deserialize<EstadoJuego>(json);
}
catch
{
    // Manejo de archivo corrupto
}
```

### 7. Uso de Estructuras de Control

El código utiliza diversas estructuras de control para lógica compleja:

- **Condicionales if-else**: Para verificar colisiones, interacciones y estados del juego.
- **Bucles foreach**: Para iterar sobre colecciones de objetos, NPCs y guardias.
- **Bucles while**: En animaciones y detección de colisiones.
- **Operador Ternario**: Para decisiones binarias como dirección de movimiento.
- **Switch-case**: En Objeto.cs para cargar imágenes según el ID del objeto.

Ejemplo complejo en Prisionero.cs:
```csharp
string mensajePeligro = VerificarPeligros(nivel, accion);
if (mensajePeligro != "") return mensajePeligro;

string mensajeLectura = ProcesarLecturasPendientes(accion);
if (mensajeLectura != "") return mensajeLectura;

if (accion == true && seguroSoltarTecla == true)
{
    string mensajeInteraccion = Interactuar(nivel);
    if (mensajeInteraccion != "") return mensajeInteraccion;
}
```

### 8. Uso de Colecciones

Las colecciones son fundamentales para gestionar múltiples entidades en el juego:

- **List<Personaje>**: Para almacenar NPCs, guardias y prisioneros.
- **List<Objeto>**: Para el inventario del jugador.
- **List<Llave>** y **List<Puerta>**: Para rastrear las llaves y puertas del nivel.
- **List<Rectangle>**: Para las paredes matemáticas de detección de colisiones.
- **List<Image>**: Para almacenar frames de animación.
- **Dictionary<string, string>**: En Traductor.cs para mapear claves de traducción a textos.

Guardia.cs utiliza listas de imágenes para animaciones:
```csharp
private List<Image> animacionDerecha;
private List<Image> animacionIzquierda;

animacionDerecha = new List<Image> { Properties.Resources.g_der_1, Properties.Resources.g_der_2 };
```

NivelBase utiliza múltiples listas para gestionar objetos del juego:
```csharp
protected List<Puerta> listaPuertas = new List<Puerta>();
protected List<Llave> listaLlaves = new List<Llave>();
protected List<NPC> listaNPCs = new List<NPC>();
protected List<Guardia> listaGuardias = new List<Guardia>();
```

### 9. Uso de Random

La generación de números aleatorios se utiliza para crear dinámicamente códigos de acceso y distribuir objetos:

- **Generación de Códigos**: En Nivel1.cs y Nivel2.cs se generan códigos de 3 dígitos aleatorios para las puertas finales.
- **Distribución de Pistas**: Se utiliza Random para distribuir aleatoriamente las pistas entre los escondites.

Ejemplo en Nivel1.cs:
```csharp
Random codigo = new Random();
int digito1 = codigo.Next(0, 10);
int digito2 = codigo.Next(0, 10);
int digito3 = codigo.Next(0, 10);
string codigoGenerado = $"{digito1}{digito2}{digito3}";
```

Distribución aleatoria de objetos:
```csharp
Random aleatorio = new Random();

foreach (Escondite cofreActual in EsconditeCod)
{
    int indiceRandom = aleatorio.Next(pistas.Count);
    cofreActual.ObjetoOculto = pistas[indiceRandom];
    pistas.RemoveAt(indiceRandom);
}
```

## Estructura del Proyecto

```
EscapeRoom/
├── Personajes/
│   ├── Personaje.cs          (Clase base)
│   └── Prisionero.cs         (Jugador principal)
├── Entidades/
│   ├── Guardia.cs            (Enemigos patrulleros)
│   ├── NPC.cs                (Personajes interactivos)
│   └── Autobus.cs            (NPC especial - nivel 3)
├── Objetos/
│   ├── Objeto.cs             (Clase base de items)
│   ├── Llave.cs              (Items para abrir puertas)
│   ├── Nota.cs               (Items de información)
│   ├── Puerta.cs             (Obstáculos interactivos)
│   ├── Escondite.cs          (Contenedores de items)
│   ├── Camara.cs             (Sistema de seguridad)
│   └── MonitorSeguridad.cs   (Control de cámaras)
├── Niveles/
│   ├── INivel.cs             (Interfaz)
│   ├── NivelBase.cs          (Clase base de niveles)
│   ├── Nivel1.cs             (Primer nivel)
│   ├── Nivel2.cs             (Segundo nivel)
│   └── Nivel3.cs             (Tercer nivel)
├── Persistencia/
│   ├── Guardar.cs            (Sistema de guardado)
│   └── EstadoJuego.cs        (Modelo de datos)
└── Controles de usuario/
    └── UCPantallaJuego.cs    (Interfaz principal del juego)
```

## Caracteristicas Principales

- Tres niveles con dificultad progresiva
- Sistema de puzzle con códigos aleatorios
- Interacción con NPCs mediante diálogos
- Enemigos que patrullan automáticamente
- Sistema de animación para personajes
- Inventario gráfico del jugador
- Guardado y carga de partidas
- Soporte multiidioma (Español e Inglés)
- Sistema de puntuación
- Detección de colisiones basada en rectángulos

## Conclusión

El proyecto EscapeRoom demuestra un dominio integral de los conceptos fundamentales de programación orientada a objetos en C#. La combinación de herencia, interfaces, polimorfismo, eventos y manejo de datos proporciona una base sólida y extensible para un juego interactivo completo.
