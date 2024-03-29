# ServerUDP
## Conectar Unity con un ESP32 vía UDP usando entorno Arduino

### Propósito
Este es un procedimiento template, lo más simple posible, para interconectar una placa basada en el módulo Espressif ESP32 con un programa desarrollado en Unity que se ejecute en una computadora conectada a la misma red de área local (LAN) que la placa mencionada.

### Características
El ejemplo plantea una comunicación bi-direccional mediante protocolo UDP de modo de poder controlar, mediante el extenso número de sensores de todo tipo pasibles de ser conectados al ESP32, cualquier entidad que viva en el programa de Unity, y simultáneamente, poder controlar motores y otros actuadores conectados al módulo, desde ese mismo programa. Dado el soporte de Espressif para la conexión WiFi, todo el intercambio puede ser inalámbrico.

El programa para el ESP32 se desarrolló en Arduino, utilizando la librería AsyncUDP que soporta los modos Brodcast y Multicast. El servidor Multicast planteado no requiere especificar de antemano la dirección IP de cada nodo, como sí sería el caso de una comunicación Unicast (punto a punto directa). De este modo, es posible comunicar simultáneamente múltiples nodos (tanto programas Unity como módulos ESP32) portados a cualquier red LAN, sin necesidad de conocer la IP que el DHCP haya asignado dinámicamente a cada uno. Más detalles sobre los modos de transmisión.

UNITY
### Funcionamiento del Script
Hay una pequeña rutina para detectar la pulsación de cada flecha del teclado, lo que permite trasladar el cubo sobre el plano (flechas Up y Down) o rotarlo sobre su propio eje (flechas Left y Right). Cada vez que se recibe una tecla de flecha, además mover el cubo, se llama a la función udpSend() que transmite las coordenadas de ese movimiento por UDP al grupo de direcciones IP 239.1.2.3, puerto 1234 al que estarán suscripto/s el/los ESP32 necesarios, así como a cualquier otro cliente UDP que se suscriba al mismo grupo y puerto.

A su vez, cuando el Script recibe un mensaje UDP, si este es un número (int o float) el cubo rotará tanto como ese número indique. La recepción es manejada por la función ReceiveData(). Si se recibe el mismo valor repetidas veces, en rápida sucesión el cubo rotará en forma constante. La idea es que el módulo ESP32 mande un valor repetidas veces mientras se esté tocando un control táctil, como se verá a continuación.

### Módulo ESP32
Requiere que se conecte al pin correspondiente AnalogIN
Cada vez que se detecta un input se envía un mensaje por UDP al grupo de direcciones IP 239.1.2.3, puerto 1234 al que estarán suscripta/s todas las instancias del programa Unity que se estén ejecutando. El mensaje que se envía es el número que esté contenido en la variable salto y la idea es que ese valor será interpretado por el programa que lo recibe para modificar xxx  presente en la escena.

El programa también retransmite al grupo UDP todo lo que recibe por el puerto serie del módulo (el que corresponde al USB, en el caso de los módulos NodeMCU). Esto es útil para pruebas y configuración, usando la ventana de puerto serie del entorno Arduino u otro medio similar. Si recibe un número, se guarda ese valor en la variable salto, y ese será el valor que envíará cada vez que se detecte input AnalogIN, hasta tanto llegue un nuevo valor por puerto serie. El valor de salto, por default es 1.
Adicionalmente, el programa recibe los mensajes del Script de Unity por UDP, que contienen las coordenadas del cubo, modificadas cada vez que este se mueve o rota por acción de las flechas de teclado. 

### Instalación y configuración
Para el módulo ESP32, si se replica el presente proyecto en Platformio, sólo es necesario modificar en el archivo src/main.cpp el SSID y la password por el que corresponda a la red WiFi utilizada.

Si en lugar de Platformio se quiere utilizar la plataforma Arduino clásica, basta con copiar el contenido del archivo src/main.cpp a un archivo .ino y descargarlo normalmente en el módulo ESP32, luego de configurar también SSID y password del WiFi. En ningun caso es necesario modificar la dirección IP (239.1.2.3) y puerto (1234) configurados.

